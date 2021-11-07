using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace Quiz.Models
{
    public class Quiz
    {
        public ICollection<Question> QuestionsList { get; set; }

        private string _title;
        public string Title
        {
            get => _title;
            set => _title = value ?? "New Quiz";
        }
        public Quiz()
        {
            QuestionsList = new ObservableCollection<Question>();
        }

        #region Methods

        //Metoden går igenom listan av frågor, kontrollerar om frågan som blivit randomized har ställts tidigare, därefter kontrollerar om frågans kategori är någon av de som spelas.
        public Question GetRandomQuestion(List<string> categories)
        {
            while (true)
            {
                Random r = new();
                var index = r.Next(0, QuestionsList.Count);

                if (QuestionsList.ToList()[index].IsAsked)
                {
                }
                else
                {
                    foreach (var category in categories)
                    {
                        if (QuestionsList.ToList()[index].Category == category)
                        {
                            QuestionsList.ToList()[index].IsAsked = true;
                            return QuestionsList.ToList()[index];
                        }
                    }
                }
            }
        }

        //Metoden återställer värdet på IsAsked så att frågorna kan ställas en gång till.
        public void ResetQuiz()
        {
            foreach (var question in QuestionsList)
            {
                question.IsAsked = false;
            }
        }

        //Metoden tar emot nödvändiga parametrar för att skapa och lägga till en fråga i listan av frågor.
        public void AddQuestion(string statement, int correctAnswer, string category, params string[] answers)
        {
            Question newQuestion = new(statement, correctAnswer, category, answers);
            QuestionsList.Add(newQuestion);
        }

        //Metoden tar bort frågan på indexet som parametern pekar på. Felhantering för om en fråga som redan är borttagen försöks ta bort.
        public void RemoveQuestion(int index)
        {
            try
            {
                List<Question> tempList = QuestionsList.ToList();
                Question tempQ = tempList[index];
                QuestionsList.Remove(tempQ);
            }
            catch
            {
                MessageBox.Show("Question already removed");
            }
        }

        #endregion

    }
}
