using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class IndexModel
    {
        public IList<Intern> Interns { get; set; }

        public IndexModel() { }
        public IndexModel(IList<Intern> data)
        {
            Interns = data;
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
        public string Duration { get; set; }

        [Required]
        public string Type { get; set; }

        [Required]
        public string DepartmentName { get; set; }

        [Required]
        public string OrganizationName { get; set; }

        public string DateCreated { get; set; }

        public string WhoCreated { get; set; }

        #endregion End Property
    }
}