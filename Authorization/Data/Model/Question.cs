using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication
{
    public class Question
    {
        public int Index { get; set; }
        public string Group { get; set; }
        public string InData { get; set; }
        public string OutData { get; set; }
    }
}