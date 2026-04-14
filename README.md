# SmartQuizSystem

## 📌 Project Description

SmartQuiz System is an ASP.NET MVC web application that allows users to attempt quiz questions one at a time. The system stores user answers in the database and enables users to resume the quiz from where they left off.

---

## 🚀 Features

* ✔ Displays one question at a time
* ✔ Multiple-choice questions (A, B, C, D)
* ✔ User must select an answer before proceeding
* ✔ Answers are stored in the database
* ✔ Resume quiz from last unanswered question
* ✔ Result page includes:

  * Total Questions Attempted
  * Correct Answers
  * Wrong Answers
  * Percentage Score
* ✔ Basic feedback:

  * Excellent
  * Good
  * Needs Improvement

---

## 🛠️ Technologies Used

* ASP.NET MVC (.NET Framework)
* C#
* Entity Framework (Code First)
* SQL Server
* HTML, CSS, Bootstrap

---

## 🗄️ Database Structure

### 🔹 Questions Table

* Id (Primary Key)
* QuestionText
* OptionA
* OptionB
* OptionC
* OptionD
* CorrectAnswer

### 🔹 Answers Table

* Id (Primary Key)
* UserEmail
* QuestionId
* SelectedAnswer
* IsCorrect

---

## 🔄 How It Works

1. User enters email to start the quiz
2. Email is stored in session
3. One question is displayed at a time
4. Selected answer is saved in the database
5. Already answered questions are skipped
6. After completing all questions, result is shown

---

## ▶️ How to Run the Project

1. Open the project in Visual Studio
2. Configure SQL Server connection string in `Web.config`
3. Run migrations or create the database
4. Insert questions into the database
5. Run the application
6. Open in browser:

   ```
   /Quiz/Start
   ```

---

## 📊 Result Calculation

* Correct Answers = count of correct responses
* Wrong Answers = total - correct
* Percentage = (Correct / Total) × 100

---

## 📌 Notes

* No login or password system (as per requirement)
* Email is used to track user progress
* No admin panel, timer, or advanced UI included

---

## 👨‍💻 Author

**Vishal Yadav**
BCA Graduate (2025)
ASP.NET MVC Developer (Fresher)

---

## ⭐ Conclusion

SmartQuiz System is a simple and efficient quiz application that demonstrates user progress tracking, database operations, and result calculation using ASP.NET MVC and Entity Framework.
