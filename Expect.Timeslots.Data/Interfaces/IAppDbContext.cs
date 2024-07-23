using Expect.Timeslots.Domain.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Data.Interfaces
{
    public interface IAppDbContext
    {
        public DbSet<Platform> Platforms { get; }
        public DbSet<Gate> Gates { get; }
        public DbSet<Timeslot> Timeslots { get; }
        public DbSet<Company> Companys { get; }
        public DbSet<CompanySchedule> CompanySchedules { get; }
        public DbSet<GateSchedule> GateSchedules { get; }

        public DbSet<TEntity> Set<TEntity>() where TEntity : class;

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
