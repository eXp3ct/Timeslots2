using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using MediatR;
using System.Net;

namespace Expect.Timeslots.Infrastructure.Common.Queries.AddPlatform
{
    public class AddPlatformHandler(IMapper mapper, IAppDbContext context) : HandlerBase(mapper, context), IRequestHandler<AddPlatform, OperationResult>
    {
        public async Task<OperationResult> Handle(AddPlatform request, CancellationToken cancellationToken)
        {
            var platform = _mapper.Map<Platform>(request.PlatformDto);

            var added = await _context.Platforms.AddAsync(platform, cancellationToken);

            if(added is null)
                return new OperationResult(false, (int)HttpStatusCode.BadRequest, platform);

            return new OperationResult(true, (int)HttpStatusCode.Created, platform);
        }
    }
}
