using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.AddGate
{
    public class AddGateRequest : IRequest<OperationResult>
    {
        public GateDto Dto { get; set; }

        public AddGateRequest(GateDto dto)
        {
            Dto = dto;
        }
    }
}
