using System.Text;

namespace Module3Homework4.LINQ.Models
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Company { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }
        public Contact(string firstName, string lastName, string company,string phone,string email, DateTime birthday)
        {
            Id = Guid.NewGuid();
            FirstName = firstName;
            LastName = lastName;
            Company = company;
            Phone = phone;
            Email = email;
            Birthday = birthday;
        }
        public void Print()
        {
            StringBuilder stringBuilder = new ();
            stringBuilder.AppendLine("Id: " + Id);
            stringBuilder.AppendLine("FirstName: " + FirstName);
            stringBuilder.AppendLine("LastName: " + LastName);
            stringBuilder.AppendLine("Company: " + Company);
            stringBuilder.AppendLine("Phone: " + Phone);
            stringBuilder.AppendLine("Email: " + Email);
            stringBuilder.AppendLine("Birthday: " + Birthday);
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
