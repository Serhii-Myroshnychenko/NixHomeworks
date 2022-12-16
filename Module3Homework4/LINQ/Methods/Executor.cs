using Module3Homework4.LINQ.Models;

namespace Module3Homework4.LINQ.Methods
{
    public static class Executor
    {
        public static void Execute()
        {
            var contacts = new List<Contact>
            {
                new Contact("Ted", "Cress", "Google", "+380652341234", "ted@gmail.com", new DateTime(1987, 01, 14)),
                new Contact("Will", "Mallin", "Google", "+380545451234", "will@gmail.com", new DateTime(1990, 11, 20)),
                new Contact("Alaric", "Manning", "Apple", "+380652341265", "alaric@gmail.com", new DateTime(1991, 2, 13)),
                new Contact("Brigham", "Green", "Apple", "+380975671234", "brigham@gmail.com", new DateTime(1977, 11, 27)),
                new Contact("Cassian", "Barlow", "Samsung", "+380763458967", "cassian@gmail.com", new DateTime(1995, 05, 19))
            };

            var contactsSelectEmail = contacts.Select(c => c.Email);

            
            var contactsWhereGoogle = contacts.Where(c => c.Company != "Google");
            var contactsOrderByBirthday = contacts.OrderBy(c => c.Birthday);
            var contactsOrderByDescendingBirthday = contacts.OrderByDescending(c => c.Birthday);

            foreach (var elem in contactsOrderByDescendingBirthday)
            {
                elem.Print();
            }

        }
    }
}
