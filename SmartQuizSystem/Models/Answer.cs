using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQuizSystem.Models
{
    public class Answer
    {
        public int Id { get; set; }

        public string UserEmail { get; set; }   // 🔥 change here

        public int QuestionId { get; set; }

        public int SelectedAnswer { get; set; }
        public bool IsCorrect { get; set; }
    }
}