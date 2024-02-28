using AutoMapper;
using CRUD_API.Application.DTOs;
using CRUD_API.Application.Interfaces;
using CRUD_API.DataManager.Paging;
using CRUD_API.Domain.Models;
using CRUD_API.Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CRUD_API.Application.Services
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _operationRepository;
        private readonly IMapper _mapper;


        public UsersService(
            IUsersRepository operationRepository,
            IMapper mapper
            )
        {
            _operationRepository = operationRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Returns a list of all users.</returns>
        public async Task<List<UserDTO>> GetAll()
        {
            var result = await _operationRepository.GetAll();

            return result;
        }

        /// <summary>
        /// Get all users paginated.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination. Defaults to 1.</param>
        /// <param name="pageSize">The number of records to retrieve per page. Defaults to 4.</param>
        /// <returns>Returns a list of all users paginated.</returns>
        public async Task<PaginatedList<UserDTO>> GetAll(int pageNumber, int pageSize)
        {
            var users = await _operationRepository.GetAll(pageNumber, pageSize);

            return users;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns the user with the specified ID.</returns>
        public async Task<UserDTO> GetById(Guid userId)
        {
            var result = await _operationRepository.GetById(userId);
            return result;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="data">The data of the user to create.</param>
        /// <returns>Returns true if the user was created successfully, otherwise, false.</returns>
        public async Task<bool> CreateUser(UserDTO employee)
        {
            await _operationRepository.CreateUser(employee);

            return true;
        }

        /// <summary>
        /// Updates an existing user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="data">The updated data of the user.</param>
        /// <returns>Returns true if the user was updated successfully; otherwise, false.</returns>
        public async Task<bool> UpdateById(Guid userId, UpdateUserDTO updatedEmployee)
        {
            var employee = await GetById(userId);

            if (employee != null)
            {
                employee.DateOfBirth = updatedEmployee.DateOfBirth;
                employee.JoiningDate = updatedEmployee.JoiningDate;
                employee.Designation = updatedEmployee.Designation;
                employee.DisplayName = updatedEmployee.DisplayName;
                employee.Email = updatedEmployee.Email;
                employee.ReportingManager = updatedEmployee.ReportingManager;

                await _operationRepository.UpdateById(employee);

                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Removes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to remove.</param>
        /// <returns>Returns true if the user was removed successfully; otherwise, false.</returns>
        public async Task<bool> RemoveById(Guid userId)
        {
            var employee = await _operationRepository.GetById(userId);

            if (employee != null)
            { 
                await _operationRepository.RemoveById(employee);
                return true;
            }
            else
            {
                return false;
            }
        }

        //public async Task<bool> InitDatabase()
        //{
        //    await _operationRepository.InitDatabase();

        //    return true;
        //}
    }
}
