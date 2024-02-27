using AutoMapper;
using FrontEnd.Application.DTOs;

namespace FrontEnd.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserDTO, UpdateUserDTO>().ReverseMap();
        }
    }
}
