using Expect.Timeslots.Domain.Enums;

namespace Expect.Timeslots.Domain.Dtos
{
    public class TimeslotsDto
    {
        public int Pallets { get; }
        public DateOnly Date { get; }
        public TaskType TaskType { get; }

        public TimeslotsDto(int pallets, DateOnly date, TaskType taskType)
        {
            Pallets = pallets;
            Date = date;
            TaskType = taskType;
        }
    }
}
