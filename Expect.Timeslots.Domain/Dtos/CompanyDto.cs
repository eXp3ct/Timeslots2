using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Expect.Timeslots.Domain.Dtos
{
    public class CompanyDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        public Guid? PlatformId { get; set; }
    }
}
