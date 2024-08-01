using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Timeslots.GetTimeslots
{
    public class GetTimeslotsRequest : IRequest<OperationResult>
    {
        public TimeslotsDto Dto { get; }

        public GetTimeslotsRequest(TimeslotsDto dto)
        {
            Dto = dto;
        }
    }
}
