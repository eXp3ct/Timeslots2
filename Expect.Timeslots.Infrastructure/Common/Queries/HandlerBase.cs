using AutoMapper;
using Expect.Timeslots.Data.Interfaces;

namespace Expect.Timeslots.Infrastructure.Common.Queries
{
    public abstract class HandlerBase(IMapper mapper, IAppDbContext context)
    {
        protected readonly IMapper _mapper = mapper;
        protected readonly IAppDbContext _context = context;
    }
}
