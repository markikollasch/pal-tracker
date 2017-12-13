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
            _count[TrackedOperation.Create] = 0;
        }

        public string Name => $"{typeof(T).Name}Operations";

        public IReadOnlyDictionary<TrackedOperation, int> GetCounts() => _count.ToImmutableDictionary();

        public void Increment(TrackedOperation trackedOperation)
        {
            if (_count.TryGetValue(trackedOperation, out int count))
            {
                _count[trackedOperation] = count + 1;
            }
            else
            {
                _count[trackedOperation] = 1;
            }
        }
    }
}
