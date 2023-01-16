namespace Module4Homework5.Models
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; } 
        public virtual List<Employee> Employees { get; set; } = new List<Employee>();
    }
}
