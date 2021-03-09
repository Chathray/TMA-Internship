using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class QuestionModel
    {
        public IList<Question> QA { get; set; }

        public QuestionModel(IList<Question> data)
        {
            QA = data;
        }
    }
}
