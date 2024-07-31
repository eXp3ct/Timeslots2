using AutoMapper;
using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;

namespace Expect.Timeslots.Infrastructure.Mapping
{
    public class GateMappingProfile : Profile
    {
        public GateMappingProfile()
        {
            CreateMap<GateDto, Gate>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()));
        }
    }
}
