using Microsoft.EntityFrameworkCore;
using Module4Homework5.Context;
using Module4Homework5.Contracts;
using Module4Homework5.Models;

namespace Module4Homework5.Repositories
{
    public class Repository : IRepository
    {
        private readonly ApplicationContext _context;
        public Repository()
        {
            _context = new ApplicationContext();
        }

        public void AddEmployee()
        {
            var employee = new Employee
            {
                FirstName = "Mike",
                LastName = "Tayson",
                HiredDate = new DateTime(2022, 12, 2),
                DateOfBirth = new DateTime(1997, 06, 12),
                OfficeId = 1,
                TitleId = 1
            };
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void DeleteEmployee()
        {
            var employee = _context.Employees.Where(e => e.FirstName == "Mike").FirstOrDefault();

            _context.Employees.Remove(employee!);
            _context.SaveChanges();
        }

        public void DifferenceBetweenCreatedDateAndToday()
        {
            var difference = _context.Database.SqlQueryRaw<int>(
                $"select Datediff(day,Employee.HiredDate,GETDATE()) as difference" +
                $"from Employee " +
                $"order by difference");

            Console.WriteLine(difference.ToQueryString() + Environment.NewLine);
        }

        public void GroupEmployeesByTitleName()
        {
            var empls = from emp in _context.Employees
                        where !EF.Functions.Like(emp.Title.Name, "%a%")
                        group emp by emp.Title.Name into employ
                        select new
                        {
                            Title = employ.Key
                        };


            Console.WriteLine(empls.ToQueryString() + Environment.NewLine);
        }

        public void JoinThreeTables()
        {
            var leftJoinThreeTables = from projects in _context.Projects
                                       join clients in _context.Clients
                                       on projects.ClientId equals clients.ClientId into projClient
                                       from projClients in projClient.DefaultIfEmpty()
                                       join emp in _context.EmployeeProjects
                                       on projClients.Project.ProjectId equals emp.Project.ProjectId into projEmp
                                       from prEmp in projEmp
                                       select new
                                       {
                                           prEmp.ProjectId,
                                           prEmp.Project.Name,
                                           projClients.ClientId,
                                           projClients.FirstName,
                                           projClients.LastName,
                                           prEmp.StartedDate
                                       };

            Console.WriteLine(leftJoinThreeTables.ToQueryString() + Environment.NewLine);
        }

        public void UpdateTwoEntities()
        {
            using var transaction = _context.Database.BeginTransaction();

            try
            {
                _context.Database.ExecuteSql($"UPDATE [Title] SET [Name] = 'NewTitle1' WHERE TitleId = 1");
                _context.SaveChanges();

                transaction.CreateSavepoint("SavePoint");

                _context.Database.ExecuteSql($"UPDATE [Title] SET [Name] = 'NewTitle2' WHERE TitleId = 2");
                _context.SaveChanges();

                
                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.RollbackToSavepoint("SavePoint");
            }
        }
    }
}
