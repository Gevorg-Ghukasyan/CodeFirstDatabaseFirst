using DatabaseFirst;
using Microsoft.EntityFrameworkCore;

//Add values to DB
using (TestDBContext dBContext = new())
{
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

    //dBContext.Users.Add(user1);
    //dBContext.Users.Add(user2);

    dBContext.Users.AddRange(user1, user2);
    dBContext.SaveChanges();
}

//Get values from DB
using(TestDBContext dBContext = new())
{
    var users = dBContext.Users.ToList();
    Console.WriteLine("Getting all users........");

    foreach (var user in users)
    {
        Console.WriteLine($"UserId = {user.Id}, UserName = {user.Name}" +
            $" Age = {user.Age.ToString()} ");
    }
}

//Update value in DB
using (TestDBContext dbContext = new())
{
    var user = dbContext.Users.FirstOrDefault();

    if (user != null)
    {
        if (user.Id == 1)
        {
            user.Name = "Zavik";
            user.Age = 30;

            dbContext.Users.Update(user);
            dbContext.SaveChanges();


            var users = dbContext.Users.ToList();
            Console.WriteLine("Getting all users........");

            foreach (var item in users)
            {
                Console.WriteLine($"UserId = {item.Id}, UserName = {item.Name}" +
                    $" Age = {item.Age.ToString()} ");
            }
        }
    }
}


//Delete item from DB
using (TestDBContext dbcontext = new())
{
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
        Console.WriteLine($"UserId = {item.Id}, UserName = {item.Name}" +
            $" Age = {item.Age.ToString()} ");
    }
}


