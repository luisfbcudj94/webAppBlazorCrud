using AutoMapper;
using CRUD_API.Application.DTOs;
using CRUD_API.Domain.Models;

namespace CRUD_API.DataManager.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDTO>().ReverseMap();
        }
    }
}
