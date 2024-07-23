using AutoMapper;
using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;

namespace Expect.Timeslots.Infrastructure.Mapping
{
    public class PlatformMappingProfile : Profile
    {
        public PlatformMappingProfile()
        {
            CreateMap<PlatformDto, Platform>()
                .ForMember(x => x.Id, opt => opt.MapFrom(d => Guid.NewGuid()));
        }
    }
}
