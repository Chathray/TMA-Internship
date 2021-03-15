using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
    }
}