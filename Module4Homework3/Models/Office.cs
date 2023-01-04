namespace Module4Homework3.Models
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
