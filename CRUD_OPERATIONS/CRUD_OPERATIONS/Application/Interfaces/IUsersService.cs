using CRUD_OPERATIONS.Application.DTOs;

namespace CRUD_OPERATIONS.Application.Interfaces
{
    public interface IUsersService
    {
        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Returns a list of all users.</returns>
        Task<List<UserDTO>> GetAll();

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns the user with the specified ID.</returns>
        Task<UserDTO> GetById(Guid userId);

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="data">The data of the user to create.</param>
        /// <returns>Returns true if the user was created successfully, otherwise, false.</returns>
        Task<bool> CreateUser(UserDTO user);

        /// <summary>
        /// Updates an existing user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="data">The updated data of the user.</param>
        /// <returns>Returns true if the user was updated successfully; otherwise, false.</returns>
        Task<bool> UpdateById(Guid userId, UpdateUserDTO updateUser);

        /// <summary>
        /// Removes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to remove.</param>
        /// <returns>Returns true if the user was removed successfully; otherwise, false.</returns>
        Task<bool> RemoveById(Guid userId);
    }
}
