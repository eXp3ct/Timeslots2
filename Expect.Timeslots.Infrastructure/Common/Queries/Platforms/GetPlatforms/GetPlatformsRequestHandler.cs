using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.GetPlatforms
{
    public class GetPlatformsRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetPlatformsRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetPlatformsRequest request, CancellationToken cancellationToken)
        {
            var platforms = await _context.Platforms.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .Include(x => x.Gates)
                .ToListAsync(cancellationToken);

            return new OperationResult(true, StatusCodes.Status200OK, platforms);
        }
    }
}
