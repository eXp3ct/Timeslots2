using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompanies
{
    public class GetCompaniesRequest : IRequest<OperationResult>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }

        public GetCompaniesRequest(int page, int pageSize)
        {
            Page = page;
            PageSize = pageSize;
        }
    }
}
