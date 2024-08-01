using AutoMapper;
using Expect.Timeslots.Domain.Dtos;
using Expect.Timeslots.Domain.Models;

namespace Expect.Timeslots.Infrastructure.Mapping
{
    public class CompanyMappingProfile : Profile
    {
        public CompanyMappingProfile()
        {
            CreateMap<CompanyDto, Company>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => Guid.NewGuid()));
        }
    }
}
