using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace Expect.Timeslots.Infrastructure.Common.Queries.GetPlatform
{
    public class GetPlatformRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase(mapper, context), IRequestHandler<GetPlatformRequest, OperationResult>
    {
        public async Task<OperationResult> Handle(GetPlatformRequest request, CancellationToken cancellationToken)
        {
            var platform = await _context.Platforms.FindAsync(new object?[] { request.Id, cancellationToken }, cancellationToken: cancellationToken);

            if (platform == null)
                return new OperationResult(false, StatusCodes.Status404NotFound, platform);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(true, StatusCodes.Status200OK, platform);
        }
    }
}
