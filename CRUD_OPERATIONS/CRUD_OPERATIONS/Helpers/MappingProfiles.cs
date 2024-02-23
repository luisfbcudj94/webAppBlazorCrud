using AutoMapper;
using Blazorise;
using CRUD_OPERATIONS.Models;

namespace CRUD_OPERATIONS.Components.Helpers
{
    public class MappingProfiles: Profile
    {
        public MappingProfiles()
        {
            CreateMap<Employee, NewEmployeeDTO>().ReverseMap();
        }
    }
}
