namespace Module4Homework5.Models
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; } 
        public string Location { get; set; } 
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
