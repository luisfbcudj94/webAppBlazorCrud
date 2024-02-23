namespace CRUD_OPERATIONS.Models
{
    public class NewEmployeeDTO
    {
        public string Email { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
        public DateOnly JoiningDate { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public string DisplayName { get; set; }
    }
}
