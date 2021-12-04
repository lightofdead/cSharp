using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UsersEntity
{
    class UsersEntity
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionBuilder = new DbContextOptionsBuilder<helloappdbContext>();
            //optionBuilder.LogTo(message => Console.WriteLine(message));
            //optionBuilder.UseLoggerFactory(helloappdbContext.MyLoggerFactory);
            var option = optionBuilder.UseSqlServer(connectionString).Options;

            using (helloappdbContext context = new helloappdbContext(option))
            {
                bool isAvalaible = context.Database.CanConnect();
                if (isAvalaible) { Console.WriteLine("Database is Avalaible"); }
                else { Console.WriteLine("database is not Avalaible"); };

                var Users = context.Users.ToList();
                Console.WriteLine("Database before the changes");
                foreach (User user in Users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name}-{user.Age}");
                }

                User use = new User
                {
                    Name = "Bob",
                    Age = 33
                };
                context.Users.Add(use);
                context.SaveChanges();
            }

            using (helloappdbContext context = new helloappdbContext(option))
            {
                var Users = context.Users.ToList();
                Console.WriteLine("\nDatabase after added Bob");
                foreach (User user in Users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name}-{user.Age}");
                }
            }

            using (helloappdbContext context = new helloappdbContext(option))
            {
                User? user = context.Users.FirstOrDefault();
                if (user != null) 
                {
                    user.Name = "Hank";
                    user.Age = 22;
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                Console.WriteLine("\nDatabase rename first User");
                var Users = context.Users.ToList();
                foreach (User user1 in Users)
                {
                    Console.WriteLine($"{user1.Id}.{user1.Name}-{user1.Age}");
                }
            }
            using(helloappdbContext context = new helloappdbContext(option))
            {
                var users = context.Users.ToList();
                foreach(var user in users)
                {
                    if (user.Name == "Bob")
                    {
                        context.Remove(user);
                        context.SaveChanges();
                    }
                }
                Console.WriteLine("\nDatabase after delete Bob");
                
            }

            using (helloappdbContext context = new helloappdbContext(option)) 
            {
                var users = context.Users.ToList();
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.Id}.{user.Name}-{user.Age}");
                }
            }
        }
    }
}