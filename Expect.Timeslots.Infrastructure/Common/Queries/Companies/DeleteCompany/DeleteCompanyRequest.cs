using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.DeleteCompany
{
    public class DeleteCompanyRequest : IRequest<OperationResult>
    {
        public Guid Id { get; set; }

        public DeleteCompanyRequest(Guid id)
        {
            Id = id;
        }
    }
}
