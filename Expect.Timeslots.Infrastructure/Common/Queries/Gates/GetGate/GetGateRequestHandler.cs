using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGate
{
    public class GetGateRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetGateRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetGateRequest request, CancellationToken cancellationToken)
        {
            var gate = await _context.Gates.FindAsync([request.Id, cancellationToken], cancellationToken);

            if (gate == null)
                return new OperationResult(false, StatusCodes.Status404NotFound, gate);

            return new OperationResult(true, StatusCodes.Status200OK, gate);
        }
    }
}
