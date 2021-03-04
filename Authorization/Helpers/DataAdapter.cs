using Microsoft.EntityFrameworkCore;
using BC = BCrypt.Net.BCrypt;
using System.Linq;
using WebApplication.Models;

namespace WebApplication
{
    public class DataAdapter
    {
        private readonly DataContext _context;

        public DataAdapter(DataContext context)
        {
            _context = context;
        }

        public User UserCheck(string eml, string pas)
        {
            if (string.IsNullOrEmpty(eml) || string.IsNullOrEmpty(pas))
                return null;

            //var user = _context.Users.SingleOrDefault(x => x.Email == email);
            
            var user = _context.Users
                .FromSqlRaw($"EXECUTE dbo.UserCheck '{eml}'")
                .ToList();

            // check if username exists
            if (user.Count < 1)
                return null;

            // check if password is correct
            if (!BC.Verify(pas, user[0].PasswordHash))
                return null;

            // authentication successful
            return user[0];
        }

        public User UserCreate(User user, string pas)
        {
            // validation
            if (string.IsNullOrWhiteSpace(pas))
                throw new AppException("Password is required");

            if (_context.Users.Any(x => x.Email == user.Email))
                throw new AppException("Email \"" + user.Email + "\" is already taken");

            user.PasswordHash = BC.HashPassword(pas);

            //_context.Users.Add(user);
            //_context.SaveChanges();

            var rowsAffected = _context.Database
                .ExecuteSqlRaw($"EXECUTE dbo.UserCreate " +
                $"'{user.FirstName}', " +
                $"'{user.LastName}', " +
                $"'{user.Email}', " +
                $"'{user.PasswordHash}'");
            return user;
        }
    }
}