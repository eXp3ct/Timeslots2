using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.DeleteCompany
{
    public class DeleteCompanyRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<DeleteCompanyRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(DeleteCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = await _context.Companies.FindAsync([request.Id, cancellationToken], cancellationToken);

            if (company == null)
                return new OperationResult(StatusCodes.Status404NotFound, company);

            var deleted = _context.Companies.Remove(company);

            await _context.SaveChangesAsync(cancellationToken);

            return new OperationResult(StatusCodes.Status200OK, company);
        }
    }
}
