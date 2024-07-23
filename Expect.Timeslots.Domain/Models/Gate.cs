using Expect.Timeslots.Domain.Interfaces;

namespace Expect.Timeslots.Domain.Models
{
    public class Gate : IEntity
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public Guid PlatformId { get; set; }
    }
}