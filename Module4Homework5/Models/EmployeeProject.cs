namespace Module4Homework5.Models
{
    public class EmployeeProject
    {
        public int EmployeeProjectId { get; set; }
        public decimal Rate { get; set; }
        public DateTime StartedDate { get; set; }
        public int EmployeeId { get; set; }
        public int ProjectId { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; } 
    }
}
