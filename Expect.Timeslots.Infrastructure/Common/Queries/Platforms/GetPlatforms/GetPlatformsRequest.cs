using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.GetPlatforms
{
    public class GetPlatformsRequest : IRequest<OperationResult>
    {
        public int Page { get; private set; }
        public int PageSize { get; private set; }

        public GetPlatformsRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
