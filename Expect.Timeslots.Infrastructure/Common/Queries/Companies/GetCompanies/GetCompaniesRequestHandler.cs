using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Companies.GetCompanies
{
    public class GetCompaniesRequestHandler(IMapper mapper, IAppDbContext context) : HandlerBase<GetCompaniesRequest>(mapper, context)
    {
        public override async Task<OperationResult> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companies = await _context.Companies.Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync(cancellationToken);

            await _context.SaveChangesAsync(cancellationToken);
            return new OperationResult(StatusCodes.Status200OK, companies);
        }
    }
}
