using SmartQuizSystem.Models;
using System;
using System.Linq;
using System.Web.Mvc;

public class QuizController : Controller
{
    QuizDbContext db = new QuizDbContext();

    // Start Quiz
    public ActionResult Start(string email)
    {
        if (string.IsNullOrEmpty(email))
            return View();

        Session["UserEmail"] = email;
        return RedirectToAction("Question");
    }

    // Show Question
    public ActionResult Question()
    {
        if (Session["UserEmail"] == null)
            return RedirectToAction("Start");

        string email = Session["UserEmail"].ToString();

        // answered questions
        var answeredIds = db.Answers
                            .Where(u => u.UserEmail == email)
                            .Select(u => u.QuestionId)
                            .ToList();

        // ✅ numbering
        ViewBag.QNumber = answeredIds.Count + 1;

        // next unanswered question
        var question = db.Questions
                         .Where(q => !answeredIds.Contains(q.Id))
                         .OrderBy(q => q.Id)
                         .FirstOrDefault();

        if (question == null)
        {
            return RedirectToAction("Result");
        }

        return View(question);
    }

    // Save Answer
    [HttpPost]
    public ActionResult SubmitAnswer(int questionId, int selectedAnswer)
    {
        if (Session["UserEmail"] == null)
            return RedirectToAction("Start");

        string email = Session["UserEmail"].ToString();

        var question = db.Questions.Find(questionId);
        if (question == null)
            return RedirectToAction("Question");

        bool isCorrect = (selectedAnswer == question.CorrectAnswer);

        // ✅ duplicate check
        bool alreadyAnswered = db.Answers
            .Any(a => a.UserEmail == email && a.QuestionId == questionId);

        if (!alreadyAnswered)
        {
            db.Answers.Add(new Answer
            {
                UserEmail = email,
                QuestionId = questionId,
                SelectedAnswer = selectedAnswer,
                IsCorrect = isCorrect
            });

            db.SaveChanges();
        }

        return RedirectToAction("Question");
    }

    // Result
    public ActionResult Result()
    {
        if (Session["UserEmail"] == null)
            return RedirectToAction("Start");

        string email = Session["UserEmail"].ToString();

        var answers = db.Answers
                        .Where(u => u.UserEmail == email)
                        .ToList();

        int total = answers.Count;
        int correct = answers.Count(a => a.IsCorrect);
        int wrong = total - correct;

        double percent = (total == 0) ? 0 : (correct * 100.0 / total);

        ViewBag.Total = total;
        ViewBag.Correct = correct;
        ViewBag.Wrong = wrong;
        ViewBag.Percent = percent;

        return View();
    }
}