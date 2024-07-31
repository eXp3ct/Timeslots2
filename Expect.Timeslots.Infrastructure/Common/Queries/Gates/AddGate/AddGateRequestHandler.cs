using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.AddGate
{
    public class AddGateRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<AddGateRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(AddGateRequest request, CancellationToken cancellationToken)
        {
            var gate = _mapper.Map<Gate>(request.Dto);

            var added = await _context.Gates.AddAsync(gate, cancellationToken);

            if (added is null)
                return new OperationResult(false, StatusCodes.Status400BadRequest, gate);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(true, StatusCodes.Status201Created, gate);
        }
    }
}
