using System.ComponentModel.DataAnnotations;

namespace WebApplication
{
    public class TrainingSchedule
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Data { get; set; }
    }
}