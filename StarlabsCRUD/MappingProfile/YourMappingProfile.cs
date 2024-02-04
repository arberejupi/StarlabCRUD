using AutoMapper;
using StarlabsCRUD.Model;

namespace StarlabsCRUD.MappingProfile
{
    // Example mapping profile
    public class YourMappingProfile : Profile
    {
        public YourMappingProfile()
        {
            CreateMap<Person, PersonDto>().ReverseMap();
        }
    }

}
