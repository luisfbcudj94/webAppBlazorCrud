﻿namespace CRUD_API.Domain.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DisplayName { get; set; }
        public Guid RoleId { get; set; }
    }
}
