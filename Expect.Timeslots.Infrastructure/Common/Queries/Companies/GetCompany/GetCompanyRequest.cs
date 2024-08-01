using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompany
{
    public class GetCompanyRequest : IRequest<OperationResult>
    {
        public Guid Id { get; set; }

        public GetCompanyRequest(Guid id)
        {
            Id = id;
        }
    }
}
