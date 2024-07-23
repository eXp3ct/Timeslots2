namespace Expect.Timeslots.Domain.Dtos
{
    public class PlatformDto
    {
        public string Name { get; set; }

        public PlatformDto(string name)
        {
            Name = name;
        }
    }
}
