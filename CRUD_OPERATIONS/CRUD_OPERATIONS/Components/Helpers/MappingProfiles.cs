using AutoMapper;
using Blazorise;
using CRUD_OPERATIONS.Components.Models;

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
