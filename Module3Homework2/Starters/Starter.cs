using System.Globalization;
using Module3Homework2.Collections;
using Module3Homework2.Models;

namespace Module3Homework2.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Contacts contactsEn = new (new CultureInfo("en-US"));
            contactsEn.AddRecordToContacts(new Contact("Mike", "Tayson", "+3809845244", "tayson@gmail.com", "Google"));
            contactsEn.AddRecordToContacts(new Contact("Anna", "White", "+3809853454", "anna@gmail.com", "Apple"));
            contactsEn.AddRecordToContacts(new Contact("8Anna", "White", "+3809853454", "anna8@gmail.com", "Google"));
            contactsEn.AddRecordToContacts(new Contact("3Mike", "Tayson", "+3809853454", "tayson3@gmail.com", "Apple"));
            contactsEn.AddRecordToContacts(new Contact("Василь", "Молвець", "+3809853454", "vasul@gmail.com", "Samsung"));
            contactsEn.AddRecordToContacts(new Contact("Оксана", "Писанка", "+3809853454", "oksana@gmail.com", "Apple"));

            Console.WriteLine("Contacts en-US");
            contactsEn.PrintAllContacts();

            Contacts contactsUa = new (new CultureInfo("ua-UA"));
            contactsUa.AddRecordToContacts(new Contact("Mike", "Tayson", "+3809845244", "tayson@gmail.com", "Google"));
            contactsUa.AddRecordToContacts(new Contact("Anna", "White", "+3809853454", "anna@gmail.com", "Apple"));
            contactsUa.AddRecordToContacts(new Contact("8Anna", "White", "+3809853454", "anna8@gmail.com", "Google"));
            contactsUa.AddRecordToContacts(new Contact("3Mike", "Tayson", "+3809853454", "tayson3@gmail.com", "Apple"));
            contactsUa.AddRecordToContacts(new Contact("Василь", "Молвець", "+3809853454", "vasul@gmail.com", "Samsung"));
            contactsUa.AddRecordToContacts(new Contact("Оксана", "Писанка", "+3809853454", "oksana@gmail.com", "Apple"));

            Console.WriteLine(Environment.NewLine + "Contacts ua-UA");
            contactsUa.PrintAllContacts();
        }
    }
}
