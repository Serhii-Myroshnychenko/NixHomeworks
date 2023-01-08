using Module4Homework4.Context;
using Module4Homework4.Models;

namespace Module4Homework4.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            using ApplicationContext db = new ();

            db.Clients.AddRange(
                new Client()
                {
                    FirstName = "Ivan",
                    LastName = "Korobov",
                    Email = "ivan@gmail.com",
                    Organization = "Black Friday"
                },
                new Client()
                {
                    FirstName = "Anatoliy",
                    LastName = "Filipenko",
                    Email = "aantoliy@gmail.com",
                    Organization = "Black Friday"
                },
                new Client()
                {
                    FirstName = "Anna",
                    LastName = "Smith",
                    Email = "anna@gmail.com",
                    Organization = "Black Friday"
                },
                new Client()
                {
                    FirstName = "Pavlo",
                    LastName = "Mooth",
                    Email = "pavlo@gmail.com",
                    Organization = "Black Friday"
                },
                new Client()
                {
                    FirstName = "Kate",
                    LastName = "White",
                    Email = "kate@gmail.com",
                    Organization = "Black Friday"
                });

            db.Projects.AddRange(
               new Project()
               {
                   Name = "Project1",
                   Budget = 1200,
                   StartedDate = DateTime.Now,
                   ClientId = 26
               },
               new Project()
               {
                   Name = "Project2",
                   Budget = 1400,
                   StartedDate = DateTime.Now,
                   ClientId = 27
               },
               new Project()
               {
                   Name = "Project3",
                   Budget = 4000,
                   StartedDate = DateTime.Now,
                   ClientId = 28
               },
               new Project()
               {
                   Name = "Project4",
                   Budget = 55400,
                   StartedDate = DateTime.Now,
                   ClientId = 29
               },
               new Project()
               {
                   Name = "Project5",
                   Budget = 55000,
                   StartedDate = DateTime.Now,
                   ClientId = 30
               });

            db.SaveChanges();

            var projects = db.Projects.ToList();
            var clients = db.Clients.ToList();

            Console.WriteLine("Projects:" + Environment.NewLine);
            foreach (var proj in projects)
            {
                Console.WriteLine("ProjectId: " + proj.ProjectId);
                Console.WriteLine("Name: " + proj.Name);
                Console.WriteLine("Budget: " + proj.Budget);
                Console.WriteLine("StartedDate: " + proj.StartedDate);
                Console.WriteLine("ClientId: " + proj.ClientId + Environment.NewLine);
            }

            Console.WriteLine("Clients:" + Environment.NewLine);
            foreach (var client in clients)
            {
                Console.WriteLine("ClientId: " + client.ClientId);
                Console.WriteLine("FirstName: " + client.FirstName);
                Console.WriteLine("LastName: " + client.LastName);
                Console.WriteLine("Email: " + client.Email);
                Console.WriteLine("Organization: " + client.Organization + Environment.NewLine);
            }
        }
    }
}
