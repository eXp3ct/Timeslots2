using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.DeleteGate
{
    public class DeleteGateRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<DeleteGateRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(DeleteGateRequest request, CancellationToken cancellationToken)
        {
            var gate = await _context.Gates.FindAsync([request.Id, cancellationToken], cancellationToken);

            if (gate == null)
                return new OperationResult(StatusCodes.Status404NotFound, gate);

            var deleted = _context.Gates.Remove(gate);

            await _context.SaveChangesAsync(cancellationToken);

            return new OperationResult(StatusCodes.Status200OK, gate);
        }
    }
}
