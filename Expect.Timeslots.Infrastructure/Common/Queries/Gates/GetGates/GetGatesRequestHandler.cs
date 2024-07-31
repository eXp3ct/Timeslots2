using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGates
{
    public class GetGatesRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetGatesRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetGatesRequest request, CancellationToken cancellationToken)
        {
            var gates = await _context.Gates.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(true, StatusCodes.Status200OK, gates);
        }
    }
}
