using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class InternModel
    {
        public IList<Intern> Members { get; set; }

        public InternModel(IList<Intern> data)
        {
            Members = data;
        }

        #region Property
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Avatar { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public char Type { get; set; }

        [Required]
        public string Department { get; set; }

        [Required]
        public string Organization { get; set; }
        #endregion End Property
    }
}
