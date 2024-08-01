using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.AddCompany
{
    public class AddCompanyRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<AddCompanyRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = _mapper.Map<Company>(request.Dto);

            var added = await _context.Companies.AddAsync(company, cancellationToken);

            if (added is null)
                return new OperationResult(StatusCodes.Status400BadRequest, company);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(StatusCodes.Status201Created, company);
        }
    }
}
