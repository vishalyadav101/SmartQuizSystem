using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;


namespace SmartQuizSystem.Models
{
    public class QuizDbContext : DbContext
    {
        public QuizDbContext() : base("QuizDb") { }

        public DbSet<User> Users { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
    }
}