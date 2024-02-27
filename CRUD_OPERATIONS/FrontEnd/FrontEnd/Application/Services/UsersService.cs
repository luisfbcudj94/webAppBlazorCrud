using FrontEnd.Application.DTOs;
using FrontEnd.Application.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http.Json;

namespace FrontEnd.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly HttpClient _http;

        public UsersService(HttpClient http)
        {
            _http = http;
        }

        public async Task<bool> CreateUser(UserDTO user)
        {
            user.RoleId = Guid.NewGuid();
            user.EmployeeId = Guid.NewGuid();

            try
            {
                var result = await _http.PostAsJsonAsync<UserDTO>("api/Users", user);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch 
            {
                return false;
            }

        }

        public async Task<List<UserDTO>> GetAll()
        {

            var result = await _http.GetFromJsonAsync<List<UserDTO>>("api/Users");

            return result;
        }

        public Task<UserDTO> GetById(Guid userId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveById(Guid userId)
        {
            try
            {
                var result = await _http.DeleteAsync($"api/Users/{userId}");

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateById(Guid userId, UpdateUserDTO updateUser)
        {
            try
            {
                var result = await _http.PutAsJsonAsync($"api/Users/{userId}", updateUser);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
