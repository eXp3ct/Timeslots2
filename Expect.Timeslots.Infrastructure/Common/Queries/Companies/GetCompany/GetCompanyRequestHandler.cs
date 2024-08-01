using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompany
{
    public class GetCompanyRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetCompanyRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync([request.Id, cancellationToken], cancellationToken);

            if (company == null)
                return new OperationResult(StatusCodes.Status404NotFound, company);

            return new OperationResult(StatusCodes.Status200OK, company);
        }
    }
}
