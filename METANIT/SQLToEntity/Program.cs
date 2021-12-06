using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace SQLToEntity
{
    class SQLToEntity {
        static void Main(string[] args)
        {
            using (helloappdbContext context = new helloappdbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                Country usa = new Country { Name = "USA" };

                Company micro = new Company { Name = "microsoft", Country = usa };
                Company yan = new Company { Name = "Yandex", Country = usa };
                context.Companies.AddRange(micro, yan);

                User tom = new User { Name = "Tom", Age = 36, Company = micro };
                User bob = new User { Name = "Bob", Age = 39, Company = yan };
                User alice = new User { Name = "Alice", Age = 28, Company = micro };
                User kate = new User { Name = "Kate", Age = 25, Company = yan };
                context.Users.AddRange(tom, bob, alice, kate);

                context.SaveChanges();
            }
            //Cтандартные выборки
            static void Where(int num)
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.Include(p => p.Company).Where(p => p.CompanyId == num);
                    foreach (User user in users)
                    {
                        Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company?.Name}");
                    }
                }
            }
            static void WhereLINQ(int num)
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = (from user in context.Users.Include(p => p.Company)
                                 where user.CompanyId == num
                                 select user).ToList();
                    foreach (User user in users)
                    {
                        Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company?.Name}");
                    }
                }
            }
            //Выборка "Содержит"
            static void Like(string name)
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.Where(p => EF.Functions.Like(p.Name!, $"%{name}%"));
                    foreach (User user in users)
                    {
                        Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company?.Name}");
                    }
                }
            }
            static void LikeLINQ(string name)
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = from user in context.Users
                                where EF.Functions.Like(user.Name!, $"%{name}%")
                                select user;
                }
            }
            //SELECT
            static void Proection()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.Select(p => new
                    {
                        Name = p.Name,
                        Age = p.Age,
                        Company = p.Company!.Name,
                    });
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.Name} ({user.Age}) - {user.Company}");
                    };
                }
            }
            //Сортировка
            static void OrderBy()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.OrderBy(p => p.Name);
                }
            }
            static void OrderByLINQ()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = from user in context.Users
                                orderby user.Name
                                select user;
                }
            }
            //Соединение таблиц
            static void Join()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.Join(
                        context.Companies,
                        u => u.CompanyId,
                        c => c.Id,
                        (u, c) => new
                        {
                            Name = u.Name,
                            Age = u.Age,
                            Company=c.Name
                        }
                        );
                }
            }
            static void JoinLINQ()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = from user in context.Users
                                join company in context.Companies on user.CompanyId equals company.Id
                                join country in context.Countries on company.CountryId equals country.Id
                                select new
                                {
                                    Name = user.Name,
                                    Age = user.Age,
                                    Company = company.Name,
                                    Country = country.Name
                                };
                }
            }
            //Группировка
            static void GroupBy()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var groups = context.Users.GroupBy(u => u.Company!.Name).Select(g => new
                    {
                        g.Key,
                        Count = g.Count()
                    });
                }
            }
            static void GroupByLINQ()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var groups = from user in context.Users
                                 group user by user.Company!.Name into grp
                                 select new
                                 {
                                     grp.Key,
                                     Count = grp.Count()
                                 };

                }
            }
            //Пересечение
            static void Union()
            {
                
                   using (helloappdbContext context = new helloappdbContext())
                    {
                    var users = context.Users.Where(p => p.Age < 30)
                        .Union(context.Users.Where(p => p.Name!.Contains("Tom")));

                    }
               
            }
            static void Intersect()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var users = context.Users.Where(p => p.Age < 30)
                        .Intersect(context.Users.Where(p => p.Name.Contains("Tom")));

                }
            }
            //Елементы первой, которые отсутствуют у второй
            static void Excpect()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    var selector1 = context.Users.Where(p => p.Age < 30);
                    var selector2 = context.Users.Where(p => p.Name.Contains("Alice"));
                    var users = selector1.Except(selector2).ToList();
                }
            }
            //булевое Или
            static void Any() 
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    bool result = context.Users.Any(p=>p.Company!.Name=="Yandex");
                }
            }
            //Булевое И
            static void All() 
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    bool result = context.Users.All(p => p.Company!.Name == "Yandex");
                }
            }
            static void MinMaxAverage()
            {
                using (helloappdbContext context = new helloappdbContext())
                {
                    int minAge = context.Users.Min(p => p.Age);
                    int maxAge = context.Users.Max(p => p.Age);
                    double averageAge = (double)minAge / maxAge;
                }
            }
        }
    
}
}