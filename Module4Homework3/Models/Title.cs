namespace Module4Homework3.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
