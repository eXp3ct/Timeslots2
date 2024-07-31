using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Gates.GetGates
{
    public class GetGatesRequest : IRequest<OperationResult>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetGatesRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
