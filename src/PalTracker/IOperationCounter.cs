using System.Collections.Generic;

namespace PalTracker
{
    public interface IOperationCounter<T>
    {
        string Name { get; }

        void Increment(TrackedOperation trackedOperation);
        IReadOnlyDictionary<TrackedOperation, int> GetCounts();
    }
}