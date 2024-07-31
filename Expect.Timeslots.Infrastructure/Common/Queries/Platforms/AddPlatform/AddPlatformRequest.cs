using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;
using MediatR;

namespace Expect.Timeslots.Infrastructure.Common.Queries.Platforms.AddPlatform
{
    public class AddPlatformRequest(PlatformDto dto) : IRequest<OperationResult>
    {
        public PlatformDto PlatformDto { get; private set; } = dto;
    }
}
