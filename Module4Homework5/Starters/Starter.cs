
using Module4Homework5.Repositories;

namespace Module4Homework5.Starters
{
    public static class Starter
    {
        public static void Run()
        {
            Repository repository = new ();

            Console.WriteLine("1 - Join three tables:");
            repository.JoinThreeTables();

            Console.WriteLine(Environment.NewLine + "2 - Difference between CreatedDate and DateTime.Now():");
            repository.DifferenceBetweenCreatedDateAndToday();

            Console.WriteLine("3 - Update queries: " +
                "UPDATE[Title] SET[Name] = 'NewTitle1' WHERE TitleId = 1 " +
                "UPDATE [Title] SET [Name] = 'NewTitle2' WHERE TitleId = 2" +
                Environment.NewLine);
            repository.UpdateTwoEntities();

            Console.WriteLine(Environment.NewLine + "4 - Add query: " +
                "INSERT INTO Employee (FirstName, LastName, HiredDate, DateOfBirth, OfficeId, TitleId) " +
                "VALUES ('Mike','Tayson','2022-12-2','1997-05-12',1,1)" +
                Environment.NewLine);
            repository.AddEmployee();

            Console.WriteLine(Environment.NewLine + "5 - Delete query: " +
                "DELETE FROM Employee WHERE FirstName = 'Mike'" +
                Environment.NewLine);
            repository.DeleteEmployee();

            Console.WriteLine(Environment.NewLine + "6 - Group Employees by Title:");
            repository.GroupEmployeesByTitleName();
        }
    }
}
