using System;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : Controller
    {
        private ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
            if (_timeEntryRepository.Contains(id))
            {
                return Ok(_timeEntryRepository.Find(id));
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            var created = _timeEntryRepository.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new { id = created.Id }, created);
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(_timeEntryRepository.List());
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
            if (!_timeEntryRepository.Contains(id))
            {
                return NotFound();
            }

            return Ok(_timeEntryRepository.Update(id, timeEntry));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (!_timeEntryRepository.Contains(id))
            {
                return NotFound();
            }

            _timeEntryRepository.Delete(id);
            return NoContent();
        }
    }
}