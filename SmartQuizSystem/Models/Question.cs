using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQuizSystem.Models
{
    public class Question
    {
        public int Id { get; set; }
        public string QuestionText { get; set; }

        public string OptionA { get; set; }
        public string OptionB { get; set; }
        public string OptionC { get; set; }
        public string OptionD { get; set; }

        public int CorrectAnswer { get; set; }
    }
}