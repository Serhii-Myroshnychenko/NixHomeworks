namespace Module3Homework4.LINQ.Models
{
    public class Person
    {
        public Person(string name, double age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; set; }
        public double Age { get; set; }
    }
}
