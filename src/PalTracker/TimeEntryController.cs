using System;
using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    public class TimeEntryController : Controller
    {
        private ITimeEntryRepository _timeEntryRepository;

        public TimeEntryController(ITimeEntryRepository timeEntryRepository)
        {
            _timeEntryRepository = timeEntryRepository;
        }

        public IActionResult Read(int id)
        {
            throw new NotImplementedException();
        }

        public IActionResult Create(TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }

        public IActionResult List()
        {
            throw new NotImplementedException();
        }

        public IActionResult Update(long id, TimeEntry timeEntry)
        {
            throw new NotImplementedException();
        }

        public IActionResult Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}