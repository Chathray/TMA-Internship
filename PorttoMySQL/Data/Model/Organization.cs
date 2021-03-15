using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class Organization
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
    }
}