using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace WebApplication
{
    public static class DataInitializer
    {
        public static void Initialize(DataContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Users.
            if (context.Users.Any()) return; // DB has been seeded

            SetupProcedure(context);
            SetupData(context);
        }

        private static void SetupData(DataContext context)
        {
            var Users = new User[]
                        {
                new User{FirstName="Nino",LastName="Olivetto",Email="nino@mail.com", PasswordHash="$2a$11$cP33dCpCwF6KKK5wzqcQGOjBEwfFjXRK.ZofYLw1lVtX5kr5nVZ2q"},
                new User{FirstName="Jaun",LastName="Oliveria",Email="Jaun@mail.com", PasswordHash="$2a$11$cP33dCpCwF6KKK5wzqcQGOjBEwfFjXRK.ZofYLw1lVtX5kr5nVZ2q"},
                        };

            context.Users.AddRange(Users);
            context.SaveChanges();
        }

        private static void SetupProcedure(DataContext context)
        {
            context.Database.ExecuteSqlRaw(
            @"EXEC ('CREATE PROCEDURE [dbo].[UserCreate]   
		        @FirstName nvarchar(50),
		        @LastName nvarchar(50),   
		        @Email varchar(100),
		        @PasswordHash varchar(100)
		    AS   
		        INSERT INTO Users (FirstName,LastName,Email,PasswordHash)
		        VALUES (@FirstName,@LastName,@Email,@PasswordHash);
		    ')");
        }
    }
}
