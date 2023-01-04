namespace Module4Homework3.Models
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public Employee Employee { get; set; } = new Employee();
        public Project Project { get; set; } = new Project();
    }
}
