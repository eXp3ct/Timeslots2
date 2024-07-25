using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.GetPlatforms
{
    public class GetPlatformsRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase(mapper, context), IRequestHandler<GetPlatformsRequest, OperationResult>
    {
        public async Task<OperationResult> Handle(GetPlatformsRequest request, CancellationToken cancellationToken)
        {
            var platforms = await _context.Platforms.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(true, StatusCodes.Status200OK, platforms);
        }
    }
}
