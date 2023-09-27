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