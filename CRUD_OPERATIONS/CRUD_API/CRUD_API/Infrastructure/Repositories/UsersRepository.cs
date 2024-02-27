using AutoMapper;
using CRUD_API.Application.DTOs;
using CRUD_API.Domain.Models;
using CRUD_API.Infrastructure.Interfaces;
using CRUD_API.Persistence;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUD_API.Infrastructure.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly DatabaseContext _db;
        private readonly IMapper _mapper;


        public UsersRepository(
            DatabaseContext db,
            IMapper mapper)
        {
            _db = db ?? throw new ArgumentNullException(nameof(db));
            _db.Database.EnsureCreated();

            _mapper = mapper;
        }

        /// <summary>
        /// Get all users.
        /// </summary>
        /// <returns>Returns a list of all users.</returns>
        public async Task<List<UserDTO>> GetAll()
        {
            var result = await _db.Employees.ToListAsync();
            _db.Dispose();

            return _mapper.Map<List<UserDTO>>(result);
        }

        /// <summary>
        /// Retrieves a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        /// <returns>Returns the user with the specified ID.</returns>
        public async Task<UserDTO> GetById(Guid employeeId)
        {
            var result = await _db.Employees.FindAsync(employeeId);

            return _mapper.Map<UserDTO>(result);
        }

        /// <summary>
        /// Creates a new user.
        /// </summary>
        /// <param name="data">The data of the user to create.</param>
        /// <returns>Returns true if the user was created successfully, otherwise, false.</returns>
        public async Task<bool> CreateUser(UserDTO employee)
        {

            _db.Employees.Add(_mapper.Map<User>(employee));
            await _db.SaveChangesAsync();

            return true;
        }

        /// <summary>
        /// Updates an existing user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="data">The updated data of the user.</param>
        /// <returns>Returns true if the user was updated successfully; otherwise, false.</returns>
        public async Task<bool> UpdateById(UserDTO updateUser)
        {
            var user = _mapper.Map<User>(updateUser);
            _db.Employees.Update(user);
            await _db.SaveChangesAsync();
            _db.Dispose();

            return true;
        }

        /// <summary>
        /// Removes a user by ID.
        /// </summary>
        /// <param name="id">The ID of the user to remove.</param>
        /// <returns>Returns true if the user was removed successfully; otherwise, false.</returns>
        public async Task<bool> RemoveById(UserDTO employee)
        {
            _db.Employees.Remove(_mapper.Map<User>(employee));
            await _db.SaveChangesAsync();
            

            return true;
        }


        //public async Task<bool> InitDatabase()
        //{
        //    using (var db = new DatabaseContext())
        //    {
        //        await db.Database.EnsureCreatedAsync();

        //        var user_1 = new User()
        //        {
        //            UserId = Guid.NewGuid(),
        //            EmployeeId = Guid.NewGuid(),
        //            Email = "example@example.com",
        //            Designation = "Software Engineer",
        //            ReportingManager = "John Doe",
        //            JoiningDate = DateTime.UtcNow,
        //            DateOfBirth = DateTime.UtcNow,
        //            DisplayName = "Jane Doe",
        //            RoleId = Guid.NewGuid()
        //        };

        //        db.Employees.Add(user_1);

        //        var test = await db.SaveChangesAsync();
        //    }

        //    return true;

        //}
    }
}
