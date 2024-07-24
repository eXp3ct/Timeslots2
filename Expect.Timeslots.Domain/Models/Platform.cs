using Expect.Timeslots.Domain.Interfaces;
using Newtonsoft.Json;

namespace Expect.Timeslots.Domain.Models
{
    public class Platform : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public IQueryable<Gate>? Gates { get; set; }
    }
}
