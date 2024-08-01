using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.AddCompany
{
    public class AddCompanyRequest : IRequest<OperationResult>
    {
        public CompanyDto Dto { get; set; }

        public AddCompanyRequest(CompanyDto dto)
        {
            Dto = dto;
        }
    }
}
