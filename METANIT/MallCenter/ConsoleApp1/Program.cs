using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    public class User
    {
        public int Id { get; set; }
      
        public int age { get; set; }
        public string Name { get; set; }
    }
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users => Set<User>();
        public ApplicationContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=adonetdb;Trusted_Connection=True;");
        }
    }
    class ConsoleApp1
    {
        static void Main(string[] args)
        {   
           /* using (ApplicationContext context = new ApplicationContext())
            {
                User user1 = new User { Name = "Tom", age = 22 };
                User user2 = new User { Name = "Klaus", age = 4423 };
                context.Users.AddRange(user1, user2);
                context.SaveChanges();
            }*/
            using (MallCenterContext context = new MallCenterContext())
            {
                var Клиентs = context.Клиентs.ToList();
                Console.WriteLine("Users list:");
                foreach(Клиент клиент in Клиентs)
                {
                    Console.WriteLine($"{ клиент.IdКлиента}\t");
                    Console.WriteLine($"{ клиент.Имя}\t");
                    Console.WriteLine($"{ клиент.Пол}\t");
                }
            }
        }
    }
}
