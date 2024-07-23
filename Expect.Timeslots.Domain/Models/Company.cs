using Expect.Timeslots.Domain.Interfaces;

namespace Expect.Timeslots.Domain.Models
{
    public class Company : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid? PlatformId { get; set; }
    }
}
