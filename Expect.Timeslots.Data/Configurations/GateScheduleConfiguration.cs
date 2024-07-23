using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Timeslots.Data.Configurations
{
    public class GateScheduleConfiguration : IEntityTypeConfiguration<GateSchedule>
    {
        public void Configure(EntityTypeBuilder<GateSchedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasOne<Gate>()
                .WithMany()
                .HasForeignKey(x => x.GateId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
