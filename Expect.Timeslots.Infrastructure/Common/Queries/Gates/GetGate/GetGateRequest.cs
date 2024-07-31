using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGate
{
    public class GetGateRequest : IRequest<OperationResult>
    {
        public Guid Id { get; set; }

        public GetGateRequest(Guid id)
        {
            Id = id;
        }
    }
}
