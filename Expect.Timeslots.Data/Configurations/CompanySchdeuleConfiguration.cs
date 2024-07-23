using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Timeslots.Data.Configurations
{
    public class CompanySchdeuleConfiguration : IEntityTypeConfiguration<CompanySchedule>
    {
        public void Configure(EntityTypeBuilder<CompanySchedule> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MaxTaskCount).IsRequired();
            builder.HasOne<Company>()
                .WithMany()
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
