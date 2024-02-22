namespace CRUD_OPERATIONS.Components.Models
{
    public class Employee
    {
        public Guid UserId { get; set; }
        public Guid EmployeeId { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
        public DateOnly JoiningDate { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string DisplayName { get; set; }
        public Guid RoleId { get; set; }
    }
}
