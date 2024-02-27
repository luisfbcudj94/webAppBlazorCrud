namespace FrontEnd.Application.DTOs
{
    public class UpdateUserDTO
    {
        public string Email { get; set; }
        public string Designation { get; set; }
        public string ReportingManager { get; set; }
        public DateTime JoiningDate { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DisplayName { get; set; }
    }
}
