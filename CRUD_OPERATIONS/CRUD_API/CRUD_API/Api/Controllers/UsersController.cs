using CRUD_API.Application.DTOs;
using CRUD_API.Application.Interfaces;
using CRUD_API.DataManager.Paging;
using CRUD_API.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Reflection.Metadata.Ecma335;
namespace CRUD_API.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _operationService;

        public UsersController(IUsersService operationService)
        {
            _operationService = operationService;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Returns a list of all users.</returns>
        [HttpGet]
        [SwaggerOperation(Summary = "Get all users.")]
        public async Task<List<UserDTO>> GetAllAsync()
        {
            var result = await _operationService.GetAll();

            return result;
        }

        /// <summary>
        /// Get all users paginated.
        /// </summary>
        /// <param name="pageNumber">The page number for pagination. Defaults to 1.</param>
        /// <param name="pageSize">The number of records to retrieve per page. Defaults to 4.</param>
        /// <returns>Returns a list of all users paginated.</returns>
        [HttpGet("paginated")]
        [SwaggerOperation(Summary = "Get all users paginated.")]
        public async Task<PaginatedList<UserDTO>> GetAllPaginatedAsync(
            [SwaggerParameter("Page number for pagination.")]
            int pageNumber = 1,
            [SwaggerParameter("Number of records per page.")]
            int pageSize = 4
            )
        {
            var result = await _operationService.GetAll(pageNumber, pageSize);

            return result;
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns the user with the specified ID.</returns>
        [HttpGet("{id}")]
        [SwaggerOperation(Summary = "Retrieve a user by ID.")]
        public async Task<UserDTO> GetByIdAsync(
            [FromRoute] [SwaggerParameter("The ID Guid of the user to retrieve.")] 
            Guid id
            )
        {
            var result = await _operationService.GetById(id);

            return result;
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="data">The data of the user to create.</param>
        /// <returns>Returns true if the user was created successfully, otherwise, false.</returns>
        [HttpPost]
        [SwaggerOperation(Summary = "Create a new user.")]
        public async Task<bool> CreateUserAsync(
            [FromBody][SwaggerRequestBody("The data of the user to create.")] 
            UserDTO data
            )
        {
            var result = await _operationService.CreateUser(data);

            return result;
        }

        /// <summary>
        /// Updates an existing user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="data">The updated data of the user.</param>
        /// <returns>Returns true if the user was updated successfully; otherwise, false.</returns>
        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update an existing user by ID.")]
        public async Task<bool> UpdateUserByIdAsync(
            [FromRoute] [SwaggerParameter("The ID of the user to update.")] 
            Guid id,
            [FromBody] [SwaggerRequestBody("The updated data of the user.")] 
            UpdateUserDTO data
            )
        {
            var result = await _operationService.UpdateById(id, data);

            return result;
        }

        /// <summary>
        /// Removes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to remove.</param>
        /// <returns>Returns true if the user was removed successfully; otherwise, false.</returns>
        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Remove a user by ID.")]
        public async Task<bool> RemoveByIdAsync(
            [FromRoute] [SwaggerParameter("The ID of the user to remove.")] 
            Guid id)
        {
            var result = await _operationService.RemoveById(id);

            return result;
        }

        //[HttpGet("init")]
        //public async Task<bool> InitDatabaseAsync()
        //{
        //    await _operationService.InitDatabase();

        //    return true;
        //}
    }
}
