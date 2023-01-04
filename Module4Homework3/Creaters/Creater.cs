using Microsoft.EntityFrameworkCore;
using Module4Homework3.Context;
using Module4Homework3.Managers;

namespace Module4Homework3.Creaters
{
    public static class Creater
    {
        public static void CreateDatabase()
        {
            var configuration = new ConfigurationManager();
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString());

            using ApplicationContext db = new (optionsBuilder.Options);
            Console.WriteLine("The database has just been set up!");
        }
    }
}
