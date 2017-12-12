using System.Collections.Generic;
using System.Linq;

namespace PalTracker
{
    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private Dictionary<long, TimeEntry> _entries;

        public InMemoryTimeEntryRepository()
        {
            _entries = new Dictionary<long, TimeEntry>();
        }

        public bool Contains(long id)
        {
            return _entries.ContainsKey(id);
        }

        public TimeEntry Create(TimeEntry timeEntry)
        {
            var id = _entries.Keys.DefaultIfEmpty(0).Max() + 1;
            timeEntry.Id = id;
            _entries.Add(id, timeEntry);
            return timeEntry;
        }

        public void Delete(long id)
        {
            _entries.Remove(id);
        }

        public TimeEntry Find(long id)
        {
            return _entries[id];
        }

        public IEnumerable<TimeEntry> List()
        {
            return _entries.Values;
        }

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            timeEntry.Id = id;
            _entries[id] = timeEntry;
            return timeEntry;
        }
    }
}