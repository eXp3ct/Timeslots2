using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.GetPlatform
{
    public class GetPlatformRequest : IRequest<OperationResult>
    {
        public Guid Id { get; private set; }

        public GetPlatformRequest(Guid id)
        {
            Id = id;
        }
    }
}
