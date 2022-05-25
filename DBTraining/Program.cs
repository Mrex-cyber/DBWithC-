using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DBTraining
{
    class Program
    {        
        static void Main()
        {           
            using (ApplicationContext appContext = new ApplicationContext())
            {
                // CREATING
                User valentyna = new User() { FirstName = "Valentyna", LastName = "Legeta", FullAges = 17};
                User? vasyl = new User() { FirstName = "Vasyl", LastName = "Riabinchak", FullAges = 16 };

                Company redPanda = new Company("Red Panda");

                appContext.Companies.Add(redPanda);
                appContext.Users.Add(valentyna);
                appContext.SaveChanges();
                Console.WriteLine("Data after creating: ");

                // GETTING
                var listOfData = appContext.Users.ToList();
                foreach (var user in listOfData)
                {
                    Console.WriteLine("{0}. Name: {1}; Full ages: {2};", user.Id, user.FirstName, user.FullAges);
                }
                foreach(Company company in appContext.Companies)
                {
                    Console.WriteLine($"{company.Id} - {company.Name}");
                }
                // EDITING
                if (vasyl is not null)
                {
                    vasyl.FirstName = "Vasylynka";
                    appContext.SaveChanges();
                }                
                Console.WriteLine("Data after editing: ");                
                foreach (User user in listOfData)
                {
                    Console.WriteLine("{0}. Name: {1}; Full ages: {2};", user.Id, user.FirstName, user.FullAges);
                }

                // REMOVING   
                int counter = 0;
                
                foreach (User valikCheck in appContext.Users.ToList())
                {                    
                    if (valikCheck.FirstName == valentyna.FirstName)
                    {
                        counter++;
                        if (counter > 1) appContext.Users.Remove(valikCheck);
                        else continue;
                    }
                }
                appContext.SaveChanges();

                listOfData = appContext.Users.ToList();
                Console.WriteLine("Data after removing");                
                foreach (var user in listOfData)
                {
                    Console.WriteLine("{0}. Name: {1}; Full ages: {2};", user.Id, user.FirstName, user.FullAges);
                }

            }           
            
        }
    }

}