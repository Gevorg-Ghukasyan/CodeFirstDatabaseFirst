# CodeFirstDatabaseFirst
# CodeFirst vs. DatabaseFirst in C# with Entity Framework Core

This README provides an overview of two different approaches for working with databases in a C# application using Entity Framework Core: Code-First and Database-First. Each approach has its own advantages and use cases.

## CodeFirst

### Setup

1. First, create a new migration using the following command in the Package Manager Console:
Add-Migration Name



2. Update the database schema based on the newly created migration:
Update-Database



### Code Example

```csharp
namespace CodeFirst
{
 internal class AppContext : DbContext
 {
     public DbSet<User> Users { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
     {
         optionsBuilder.UseSqlServer("server=.;database=TestDB;Trusted_Connection=True;");
     }
 }
}

namespace CodeFirst
{
 internal class User
 {
     public int Id { get; set; }
     public string Name { get; set; }
     public int Age { get; set; }
 }
}

// Adding a new user to the database
using CodeFirst;
using AppContext = CodeFirst.AppContext;

Console.WriteLine("Start...........");

using (AppContext context = new())
{
 context.Users.Add(new User()
 {
     Name = "Zavik",
     Age = 40
 });

 context.SaveChanges();
}

Console.WriteLine(".......Finish.......");
Console.ReadLine();
DatabaseFirst
Setup
Use the Scaffold-DbContext command to generate DbContext and entity classes based on an existing database schema:
arduino

scaffold-dbcontext "server=.;database=TestDB;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer
Code Example

using (TestDBContext dBContext = new())
{
    // Adding new users to the database
    User user1 = new User()
    {
        Name = "Valod",
        Age = 80
    };

    User user2 = new()
    {
        Name = "Sashik",
        Age = 70
    };

    dBContext.Users.AddRange(user1, user2);
    dBContext.SaveChanges();
}

using (TestDBContext dBContext = new())
{
    // Retrieving all users from the database
    var users = dBContext.Users.ToList();
    Console.WriteLine("Getting all users........");

    foreach (var user in users)
    {
        Console.WriteLine($"UserId = {user.Id}, UserName = {user.Name}, Age = {user.Age.ToString()}");
    }
}

using (TestDBContext dbContext = new())
{
    // Updating a user in the database
    var user = dbContext.Users.FirstOrDefault();

    if (user != null && user.Id == 1)
    {
        user.Name = "Zavik";
        user.Age = 30;

        dbContext.Users.Update(user);
        dbContext.SaveChanges();

        var users = dbContext.Users.ToList();
        Console.WriteLine("Getting all users........");

        foreach (var item in users)
        {
            Console.WriteLine($"UserId = {item.Id}, UserName = {item.Name}, Age = {item.Age.ToString()}");
        }
    }
}

using (TestDBContext dbcontext = new())
{
    // Deleting a user from the database
    var user = dbcontext.Users.FirstOrDefault();

    if (user != null)
    {
        dbcontext.Users.Remove(user);
        dbcontext.SaveChanges();
    }

    var users = dbcontext.Users.ToList();
    Console.WriteLine("Getting all users........");

    foreach (var item in users)
    {
        Console.WriteLine($"UserId = {item.Id}, UserName = {item.Name}, Age = {item.Age.ToString()}");
    }
}
In summary, Code-First allows you to define your database schema using C# classes, while Database-First is used when you have an existing database and need to generate C# classes to work with it. Choose the approach that best fits your project's requirements and database design preferences.

