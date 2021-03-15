using System.Collections.Generic;

namespace WebApplication.Models
{
    public class IndexModel
    {
        public IList<Intern> Intrs { get; set; }
        public IList<User> Usrs { get; set; }
        public IList<Organization> Orgns { get; set; }
        public IList<Department> Depts { get; set; }

        public IndexModel() { }
        public IndexModel(IList<Intern> it, IList<User> ur, IList<Organization> or, IList<Department> dt)
        {
            Intrs = it;
            Usrs = ur;
            Orgns = or;
            Depts = dt;
        }


        #region Intern Property
        public string Avatar { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Phone { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string CreatedDate { get; set; }
        public string Duration { get; set; }
        public string Type { get; set; }
        public int Department { get; set; }
        public int Organization { get; set; }

        #endregion End Intern Property
    }
}
