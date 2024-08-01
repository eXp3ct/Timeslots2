using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.AddPlatform
{
    public class AddPlatformRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<AddPlatformRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(AddPlatformRequest request, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(request.PlatformDto);

            var added = await _context.Platforms.AddAsync(platform, cancellationToken);

            if (added is null)
                return new OperationResult(StatusCodes.Status400BadRequest, platform);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(StatusCodes.Status201Created, platform);
        }
    }
}
