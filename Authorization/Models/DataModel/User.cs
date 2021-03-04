using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Key]
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }
}
