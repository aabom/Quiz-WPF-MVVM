using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using Quiz.Models;
using Quiz.Commands;

namespace Quiz.ViewModels
{
    public class PlayViewModel : BaseViewModel
    {
        #region Fields
        private string _title;
        private string _statement;
        private int _amountOfQuestions;
        private int _userScore;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private bool _quizActive = true;
        private int _correctAnswer;
        private ObservableCollection<Category> _categories = new();
        private readonly Category _categoriesToPlay;
        private string _image;
        private Models.Quiz _quizToPlay;
        #endregion

        #region Properties
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public int UserScore
        {
            get => _userScore;
            set
            {
                _userScore = value;
                OnPropertyChanged(nameof(UserScore));
            }
        }
        public int AmountOfQuestions
        {
            get => _amountOfQuestions;
            set
            {
                _amountOfQuestions = value;
                OnPropertyChanged(nameof(AmountOfQuestions));
            }
        }
        public string Statement
        {
            get => _statement;
            set
            {
                _statement = value;
                OnPropertyChanged(nameof(Statement));
            }
        }
        public string Answer1
        {
            get => _answer1;
            set
            {
                _answer1 = value;
                OnPropertyChanged(nameof(Answer1));
            }
        }
        public string Answer2
        {
            get => _answer2;
            set
            {
                _answer2 = value;
                OnPropertyChanged(nameof(Answer2));
            }
        }
        public string Answer3
        {
            get => _answer3;
            set
            {
                _answer3 = value;
                OnPropertyChanged(nameof(Answer3));
            }
        }
        public int CorrectAnswer
        {
            get => _correctAnswer;
            set
            {
                _correctAnswer = value;
                OnPropertyChanged(nameof(CorrectAnswer));
            }
        }
        public ObservableCollection<Category> Categories
        {
            get => _categories;
            set
            {
                _categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public Category CategoriesToPlay
        {
            get => _categoriesToPlay;
            set
            {
                var selectedItems = Categories.Where(x => x.IsSelected).Count();
                OnPropertyChanged(nameof(CategoriesToPlay));
            }
        }
        public List<string> PlayableCategories = new();
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public Models.Quiz QuizToPlay
        {
            get => _quizToPlay;
            set
            {
                _quizToPlay = value;
                OnPropertyChanged(nameof(QuizToPlay));
            }
        }
        public ObservableCollection<Models.Quiz> AllQuizzes { get; }
        public int QuestionCount { get; set; } = 0;
        public bool QuizActive
        {
            get => _quizActive;
            set
            {
                _quizActive = value;
                OnPropertyChanged(nameof(QuizActive));
            }
        }
        public RelayCommand Answer1Command { get; set; }
        public RelayCommand Answer2Command { get; set; }
        public RelayCommand Answer3Command { get; set; }
        public RelayCommand StartCommand { get; set; }
        #endregion

        #region Constructor
        public PlayViewModel(ObservableCollection<Models.Quiz> allQuizzes)
        {
            Answer1Command = new RelayCommand(o => { UserAnswer(0); }, o => true);
            Answer2Command = new RelayCommand(o => { UserAnswer(1); }, o => true);
            Answer3Command = new RelayCommand(o => { UserAnswer(2); }, o => true);
            StartCommand = new RelayCommand(o => { StartQuiz(); }, o => IsQuizPlayable());
            AllQuizzes = allQuizzes;
            AddCategories();
        }
        #endregion


        #region Methods
        //Användarens svar kontrolleras i metoden. Är svaret rätt inkrementeras UserScore. Är frågan den sista avslutas quizzet och nollställer frågornas IsAsked property. Annars inkrementeras bara antalet ställda frågor
        private void UserAnswer(int answer)
        {
            AmountOfQuestions++;
            if (CorrectAnswer == answer)
            {
                UserScore++;
            }
            if (QuestionCount == NumberOfQuestionsInQuiz())
            {
                QuizActive = false;
                MessageBox.Show("Good Job! Thank you for playing.");
                
                QuizToPlay.ResetQuiz();
                ResetCategories();
            }
            else
            {
                QuestionCount++;
                ShowQuestion(QuestionCount);
            }
        }

        //En slumpmässig fråga skapas och värdena hämtas från metoden i quiz-klassen. Frågor med kategorier som ligger i listan för spelbara kategorier kommer visas
        private void ShowQuestion(int number)
        {
            Question randomQuestion = QuizToPlay.GetRandomQuestion(PlayableCategories);
            Statement = randomQuestion.Statement;
            Answer1 = randomQuestion.Answers[0];
            Answer2 = randomQuestion.Answers[1];
            Answer3 = randomQuestion.Answers[2];
            CorrectAnswer = randomQuestion.CorrectAnswer;
            Image = randomQuestion.Image;
        }

        //Quizzet startar
        private void StartQuiz()
        {
            PlayableCategories.Clear();
            QuizActive = true;
            UserScore = 0;
            AmountOfQuestions = 0;
            QuestionCount = 1;
            QuizToPlay.ResetQuiz();
            Title = QuizToPlay.Title;
            //Kategorierna som användaren markerat läggs till i listan för spelbara quiz
            foreach (var chosenCategory in Categories)
            {
                if (chosenCategory.IsSelected)
                {
                    PlayableCategories.Add(chosenCategory.Name);
                }
            }
            ShowQuestion(QuestionCount);
        }
        
        //Räknar ut och returnerar antalet frågor i valt quiz
        public int NumberOfQuestionsInQuiz()
        {
            int questions = 0;
            foreach (var chosenCategory in Categories)
            {
                if (chosenCategory.IsSelected)
                {
                    for (int i = 0; i < QuizToPlay.QuestionsList.Count; i++)
                    {
                        if (QuizToPlay.QuestionsList.ToList()[i].Category == chosenCategory.Name)
                        {
                            questions++;
                        }
                    }
                }
            }
            return questions;
        }

        //Kontrollerar att valt quiz har minst en fråga
        public bool IsQuizPlayable()
        {
            return NumberOfQuestionsInQuiz() > 0;
        }

        //Nollställer värdet på kategoriernas IsSelected variabel så det inte blir dubletter om man spelar igen eller går in och ur vyerna
        public void ResetCategories()
        {
            foreach (var category in Categories)
            {
                category.IsSelected = false;
                PlayableCategories.Clear();
            }
        }

        //Kategorierna adderas
        private void AddCategories()
        {
            Category sports = new() {Name = "Sports"};
            Category culture = new() {Name = "Culture"};
            Category nature = new() {Name = "Nature"};
            Category politics = new() {Name = "Politics"};
            Category geography = new() {Name = "Geography" };
            Category general = new() {Name = "General" };
            Category music = new() {Name = "Music" };
            Category food = new() {Name = "Food" };
            Category science = new() {Name = "Science" };
            Categories.Add(sports);
            Categories.Add(culture);
            Categories.Add(nature);
            Categories.Add(politics);
            Categories.Add(geography);
            Categories.Add(general);
            Categories.Add(music);
            Categories.Add(food);
            Categories.Add(science);
        }
        #endregion

    }
}
