using System;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : Controller
    {
        private readonly ITimeEntryRepository _timeEntryRepository;
        private readonly IOperationCounter<TimeEntry> _timeEntryOperationCounter;

        public TimeEntryController(
            ITimeEntryRepository timeEntryRepository,
            IOperationCounter<TimeEntry> timeEntryOperationCounter
        )
        {
            _timeEntryRepository = timeEntryRepository;
            _timeEntryOperationCounter = timeEntryOperationCounter;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
            _timeEntryOperationCounter.Increment(TrackedOperation.Read);
            if (_timeEntryRepository.Contains(id))
            {
                return Ok(_timeEntryRepository.Find(id));
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            _timeEntryOperationCounter.Increment(TrackedOperation.Create);
            var created = _timeEntryRepository.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new { id = created.Id }, created);
        }

        [HttpGet]
        public IActionResult List()
        {
            _timeEntryOperationCounter.Increment(TrackedOperation.List);
            return Ok(_timeEntryRepository.List());
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
            _timeEntryOperationCounter.Increment(TrackedOperation.Update);
            if (!_timeEntryRepository.Contains(id))
            {
                return NotFound();
            }

            return Ok(_timeEntryRepository.Update(id, timeEntry));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _timeEntryOperationCounter.Increment(TrackedOperation.Delete);
            if (!_timeEntryRepository.Contains(id))
            {
                return NotFound();
            }

            _timeEntryRepository.Delete(id);
            return NoContent();
        }
    }
}