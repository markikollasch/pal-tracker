using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Immutable;

namespace PalTracker
{
    public class OperationCounter<T> : IOperationCounter<T>
    {
        private readonly Dictionary<TrackedOperation, int> _count;

        public OperationCounter()
        {
            _count = new Dictionary<TrackedOperation, int>();
            foreach (TrackedOperation op in Enum.GetValues(typeof(TrackedOperation))) {
                _count.Add(op, 0);
            }
        }

        public string Name => $"{typeof(T).Name}Operations";

        public IReadOnlyDictionary<TrackedOperation, int> GetCounts() => _count.ToImmutableDictionary();

        public void Increment(TrackedOperation trackedOperation)
        {
            ++_count[trackedOperation];
        }
    }
}
