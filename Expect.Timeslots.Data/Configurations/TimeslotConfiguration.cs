using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Timeslots.Data.Configurations
{
    public class TimeslotConfiguration : IEntityTypeConfiguration<Timeslot>
    {
        public void Configure(EntityTypeBuilder<Timeslot> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Date).IsRequired();
            builder.Property(x => x.From).IsRequired();
            builder.Property(x => x.To).IsRequired();
            builder.HasOne<Gate>()
                .WithMany()
                .HasForeignKey(x => x.GateId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Property(x => x.TaskType).IsRequired();
        }
    }
}
