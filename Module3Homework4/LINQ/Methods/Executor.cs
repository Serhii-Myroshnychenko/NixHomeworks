using Module3Homework4.LINQ.Models;

namespace Module3Homework4.LINQ.Methods
{
    public static class Executor
    {
        public static void Execute()
        {
            var contacts = new List<Contact>
            {
                new Contact(
                            "Ted",
                            "Cress",
                            "Google",
                            "+380652341234",
                            "ted@gmail.com",
                            new DateTime(1987, 01, 14)),
                new Contact(
                            "Will",
                            "Mallin",
                            "Google",
                            "+380545451234",
                            "will@gmail.com",
                            new DateTime(1990, 11, 20)),
                new Contact(
                            "Alaric",
                            "Manning",
                            "Apple",
                            "+380652341265",
                            "alaric@gmail.com",
                            new DateTime(1991, 2, 13)),
                new Contact(
                            "Brigham",
                            "Green",
                            "Apple",
                            "+380975671234",
                            "brigham@gmail.com",
                            new DateTime(1977, 11, 27)),
                new Contact(
                            "Cassian",
                            "Barlow",
                            "Samsung",
                            "+380763458967",
                            "cassian@gmail.com",
                            new DateTime(1995, 05, 18))
            };

            var persons = new List<Person>
            {
                new Person("Ted", 26.1),
                new Person("Brigham", 33.5),
                new Person("Alaric", 56.7)
            };

            var persons1 = new List<Person>
            {
                new Person("John", 33.1),
                new Person("Mike", 32.6),
                new Person("Sally", 21.2)
            };

            var contactsSelectEmail = contacts.
                                        Select(c => c.Email);
            var contactsWhereGoogle = contacts.
                                        Where(c => c.Company != "Google");
            var contactsOrderByBirthday = contacts.
                                        OrderBy(c => c.Birthday);
            var contactsOrderByDescendingBirthday = contacts.
                                        OrderByDescending(c => c.Birthday);
            var contactsJoinPersons = contacts.
                                        Join(
                                            persons,
                                            contact => contact.FirstName,
                                            person => person.Name,
                                            (contact, person) => new
                                            {
                                                contact.LastName,
                                                person.Age
                                            });
            var contactsGroupBy = persons.
                                        GroupBy(p => Math.Floor(p.Age)).
                                        Select(s => new { Age = s.Key });
            var areAllContactsOlderThen = contacts.
                                        All(c => c.Birthday <
                                        new DateTime(1995, 05, 19));
            var isThereOnePersonWithSuchName = persons.
                                        Any(p => p.Name == "Ted");
            var countOfPersons = persons.Count();
            var getTwoPersons = persons.Take(2);
            var skipFirstPerson = persons.Skip(1);
            var isThereSuchContact = contacts.
                                        Contains(new Contact(
                                        "John",
                                        "Snow",
                                        "Allpe",
                                        "+380763458967",
                                        "john@gmail.com",
                                        new DateTime(1995, 05, 18)));
            var exceptPersons1 = persons.Except(persons1);
            var unionPersons1 = persons.Union(persons1);
            var intersectPersons1 = persons.Intersect(persons1);
            var concatPersonsAndPersons1 = persons.Concat(persons1);
            var firstElemInPersons = persons.First();
            var firstOrDefaultElemeInContacts = contacts.FirstOrDefault();
            var elemAtFirstPosition = persons.ElementAt(0);
            var elemAtFirstOrDefaultPosition = persons.ElementAtOrDefault(0);
            var lastElemInContacts = contacts.Last();
            var lastElemInContactsOrDefault = contacts.LastOrDefault();

            Console.WriteLine("Select method(Email): " + Environment.NewLine);
            foreach (var email in contactsSelectEmail)
            {
                Console.WriteLine(email);
            }

            Console.WriteLine(Environment.NewLine +
                                "Where method(Company != Google): "
                                 + Environment.NewLine);
            foreach (var contact in contactsWhereGoogle)
            {
                contact.Print();
            }

            Console.WriteLine(Environment.NewLine +
                                "FirstOrDefaultMethod method(contact): "
                                 + Environment.NewLine);
            firstOrDefaultElemeInContacts!.Print();
        }
    }
}
