using Module3Homework2.Abstractions;

namespace Module3Homework2.Models
{
    public class Contact : IRecord
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly string _phone;
        public Contact(
            string firstName,
            string lastName,
            string phone,
            string? email,
            string? company)
        {
            _firstName = firstName;
            _lastName = lastName;
            _phone = phone;
            Email = email;
            Company = company;
        }

        public string FirstName
        {
            get { return _firstName; }
        }

        public string LastName
        {
            get { return _lastName; }
        }

        public string Phone
        {
            get { return _phone; }
        }

        public string? Email { get; set; }
        public string? Company { get; set; }
    }
}
