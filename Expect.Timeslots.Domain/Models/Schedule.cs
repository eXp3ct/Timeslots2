using Expect.Timeslots.Domain.Enums;
using Expect.Timeslots.Domain.Interfaces;

namespace Expect.Timeslots.Domain.Models
{
    public class Schedule : IEntity
    {
        public Guid Id { get; set; }
        public IEnumerable<DayOfWeek> DayOfWeeks { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
        public IEnumerable<TaskType> TaskTypes { get; set; }
    }
}
