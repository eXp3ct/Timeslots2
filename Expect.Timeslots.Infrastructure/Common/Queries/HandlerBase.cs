using AutoMapper;
using Expect.Timeslots.Data.Interfaces;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries
{
    public abstract class HandlerBase<TRequest>(IMapper mapper, IAppDbContext context) : IRequestHandler<TRequest, OperationResult>
        where TRequest : IRequest<OperationResult>
    {
        protected readonly IMapper _mapper = mapper;
        protected readonly IAppDbContext _context = context;

        public abstract Task<OperationResult> Handle(TRequest request, CancellationToken cancellationToken);
    }
}
