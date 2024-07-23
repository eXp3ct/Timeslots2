namespace Expect.Timeslots.Domain.Models
{
    public class CompanySchedule : Schedule
    {
        public Guid CompanyId { get; set; }
        public int MaxTaskCount { get; set; }
    }
}
