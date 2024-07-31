using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.DeletePlatform
{
    public class DeletePlatformRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<DeletePlatformRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(DeletePlatformRequest request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FindAsync([request.Id, cancellationToken], cancellationToken: cancellationToken);

            if (platform == null)
                return new OperationResult(false, StatusCodes.Status404NotFound, platform);

            var deleted = _context.Platforms.Remove(platform);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(true, StatusCodes.Status200OK, deleted.Entity);
        }
    }
}
