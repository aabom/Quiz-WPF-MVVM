using System.Text.Json.Serialization;

namespace Quiz.Models
{
    public class Question
    {
        public string Statement { get; set; }
        public string[] Answers { get; set; }
        public bool IsAsked { get; set; }
        public string Image { get; set; }
        public int CorrectAnswer { get; private set; }
        public string Category { get; set; }

        //Detta är konstruktorn som kommer köras när ett quiz läses in från FileManager.
        [JsonConstructor]
        public Question(string statement, int correctAnswer, string category, string image, params string[] answers)
        {
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
            IsAsked = false;
            Image = image;
            Category = category;
        }
        //Denna konstruktor körs när en fråga skapas i Edit/Create-vyn.
        public Question(string statement, int correctAnswer, string category, params string[] answers)
        {
            Statement = statement;
            CorrectAnswer = correctAnswer;
            Answers = answers;
            Category = category;
            IsAsked = false;
        }
        public Question()
        {

        }
        //Metod för att ändra det korrekta svaret som behövs pga att propertyn har en private set.
        public void ChangeCorrectAnswer(int newCorrectAnswer)
        {
            CorrectAnswer = newCorrectAnswer;
        }

    }
}
