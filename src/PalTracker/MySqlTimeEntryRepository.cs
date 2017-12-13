using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace PalTracker
{
    public class MySqlTimeEntryRepository : ITimeEntryRepository
    {
        private TimeEntryContext _context;

        public MySqlTimeEntryRepository(TimeEntryContext dbContext)
        {
            _context = dbContext;
        }

        public bool Contains(long id)
        {
            return _context.TimeEntryRecords.AsNoTracking().Any(r => r.Id == id);
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var record = timeEntry.ToRecord();
            _context.TimeEntryRecords.Add(record);
            _context.SaveChanges();
            return record.ToEntity();
        }

        public void Delete(long id)
        {
            var toDelete = _context.TimeEntryRecords.Where(r => r.Id == id);
            _context.TimeEntryRecords.RemoveRange(toDelete);
            _context.SaveChanges();
        }

        public TimeEntry Find(long id)
        {
            return _context.TimeEntryRecords.AsNoTracking().FirstOrDefault(r => r.Id == id).ToEntity();
        }

        public IEnumerable<TimeEntry> List()
        {
            return _context.TimeEntryRecords.AsNoTracking().Select(r => r.ToEntity()).ToList();
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            var record = timeEntry.ToRecord();
            record.Id = id;
            var saved = _context.TimeEntryRecords.Update(record).Entity.ToEntity();
            _context.SaveChanges();
            return saved;
        }
    }
}