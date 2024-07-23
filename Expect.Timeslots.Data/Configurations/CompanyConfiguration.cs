using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Expect.Timeslots.Data.Configurations
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.HasOne<Platform>()
                .WithMany()
                .HasForeignKey(x => x.PlatformId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
