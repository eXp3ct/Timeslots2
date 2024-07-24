using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.AddPlatform
{
    public class AddPlatform(PlatformDto dto) : IRequest<OperationResult>
    {
        public PlatformDto PlatformDto { get; private set; } = dto;
    }
}
