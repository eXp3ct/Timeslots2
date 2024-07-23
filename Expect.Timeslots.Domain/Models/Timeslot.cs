using Expect.Timeslots.Domain.Enums;
using Expect.Timeslots.Domain.Interfaces;

namespace Expect.Timeslots.Domain.Models
{
    public class Timeslot : IEntity
    {
        public Guid Id { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly From { get; set; }
        public TimeOnly To { get; set; }
        public Guid GateId { get; set; }
        public TaskType TaskType { get; set; }
    }
}
