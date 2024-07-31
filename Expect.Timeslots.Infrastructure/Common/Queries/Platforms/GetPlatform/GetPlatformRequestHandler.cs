using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.GetPlatform
{
    public class GetPlatformRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetPlatformRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetPlatformRequest request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms
                .Include(x => x.Gates)
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

            if (platform == null)
                return new OperationResult(false, StatusCodes.Status404NotFound, platform);

            return new OperationResult(true, StatusCodes.Status200OK, platform);
        }
    }
}
