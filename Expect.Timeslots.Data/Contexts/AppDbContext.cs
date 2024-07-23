using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Expect.Timeslots.Data.Contexts
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options), IAppDbContext
    {
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Gate> Gates { get; set; }
        public DbSet<Timeslot> Timeslots { get; set; }
        public DbSet<Company> Companys { get; set; }
        public DbSet<CompanySchedule> CompanySchedules { get; set; }
        public DbSet<GateSchedule> GateSchedules { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}
