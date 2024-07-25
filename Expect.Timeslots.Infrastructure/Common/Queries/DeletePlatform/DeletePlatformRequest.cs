using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.DeletePlatform
{
    public class DeletePlatformRequest : IRequest<OperationResult>
    {
        public Guid Id { get; set; }

        public DeletePlatformRequest(Guid id)
        {
            Id = id;
        }
    }
}
