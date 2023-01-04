namespace Module4Homework3.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public int OfficeId { get; set; }
        public int TitleId { get; set; }
        public Office Office { get; set; } = new Office();
        public Title Title { get; set; } = new Title();
        public List<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
    }
}
