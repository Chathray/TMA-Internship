using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication
{
    public class User
    {
        [Key]
        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }
    }
}