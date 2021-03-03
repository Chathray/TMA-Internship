using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication.Models
{
    public class User
    {
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        [Key]
        public string Email { get; set; }
        public byte[] Salt_Code { get; set; }
        public byte[] Hashed_Code { get; set; }
    }
}
