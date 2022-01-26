using AutoMapper;
using bmiwebApi.Dtos;

namespace bmiwebApi.AutoMapper
{
    public class BodyMappingProfiles : Profile
    {
        public BodyMappingProfiles()
        {
            CreateMap<BodyCreateDto, Body>();
            CreateMap<Body, BodyGetDto>();
        }
    }
}
