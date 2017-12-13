using System.Linq;
using Steeltoe.Management.Endpoint.Health;
using static Steeltoe.Management.Endpoint.Health.HealthStatus;

namespace PalTracker
{
    public class TimeEntryHealthContributor : IHealthContributor
    {
        private readonly ITimeEntryRepository _repository;
        public const int MaxTimeEntries = 5;

        public TimeEntryHealthContributor(ITimeEntryRepository timeEntryRepository)
        {
            _repository = timeEntryRepository;
        }

        public string Id => "timeEntry";

        public Health Health()
        {
            var count = _repository.List().Count();
            var status = count < MaxTimeEntries ? UP : DOWN;

            var health = new Health {Status = status};

            health.Details.Add("threshold", MaxTimeEntries);
            health.Details.Add("count", count);
            health.Details.Add("status", status.ToString());

            return health;
        }
    }
}
