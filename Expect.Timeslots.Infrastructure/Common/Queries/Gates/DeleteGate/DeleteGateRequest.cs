using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.DeleteGate
{
    public class DeleteGateRequest : IRequest<OperationResult>
    {
        public Guid Id { get; set; }

        public DeleteGateRequest(Guid id)
        {
            Id = id;
        }
    }
}
