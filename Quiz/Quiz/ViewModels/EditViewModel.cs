using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;
using Quiz.Commands;
using Quiz.FileManager;
using Quiz.Models;

namespace Quiz.ViewModels
{
    public class EditViewModel : BaseViewModel
    {
        #region Fields
        private string _statement;
        private string _answer1;
        private string _answer2;
        private string _answer3;
        private string _category;
        private string _image;
        private int _correctAnswer;
        private string _quizName;
        private ObservableCollection<Models.Quiz> _quizList;
        private ObservableCollection<Models.Quiz> _allQuizzes;
        private Models.Quiz _selectedQuiz;
        private Question _selectedQuestion;
        private readonly JsonManager _saveAndLoad;
        #endregion

        #region Properties
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
        public string Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public string Image
        {
            get => _image;
            set
            {
                _image = value;
                OnPropertyChanged(nameof(Image));
            }
        }
        public string QuizName
        {
            get => _quizName;
            set
            {
                _quizName = value;
                OnPropertyChanged(nameof(QuizName));
            }
        }
        public ObservableCollection<Models.Quiz> QuizList
        {
            get => _quizList;
            set
            {
                _quizList = value;
                OnPropertyChanged(nameof(QuizList));
            }
        }
        public ObservableCollection<Models.Quiz> AllQuizzes
        {
            get => _allQuizzes;
            set
            {
                _allQuizzes = value;
                OnPropertyChanged(nameof(AllQuizzes));
            }
        }
        public Models.Quiz SelectedQuiz
        {
            get => _selectedQuiz;
            set
            {
                _selectedQuiz = value;
                OnPropertyChanged(nameof(SelectedQuiz));
            }
        }
        public Question SelectedQuestion
        {
            get => _selectedQuestion;
            set
            {
                _selectedQuestion = value;
                OnPropertyChanged(nameof(SelectedQuestion));

                if (_selectedQuestion != null)
                {
                    Statement = SelectedQuestion.Statement;
                    Answer1 = SelectedQuestion.Answers[0];
                    Answer2 = SelectedQuestion.Answers[1];
                    Answer3 = SelectedQuestion.Answers[2];
                    CorrectAnswer = SelectedQuestion.CorrectAnswer;
                    Category = SelectedQuestion.Category;
                }
            }
        }

        public string[] CategoryList { get; } = { "Sports", "Culture", "Nature", "Politics", "Geography", "General", "Music", "Food", "Science" };
        public bool QuizListLoaded { get; set; } = false;
        public RelayCommand CreateQuizCommand { get; set; }
        public RelayCommand AddQuestionCommand { get; set; }
        public RelayCommand SaveQuizToFileCommand { get; set; }
        public RelayCommand EditQuestionCommand { get; set; }
        public RelayCommand LoadQuizFromFileCommand { get; set; }
        public RelayCommand SaveSelectedQuizCommand { get; set; }
        public RelayCommand DeleteSelectedQuizCommand { get; set; }
        public RelayCommand AddImageCommand { get; set; }
        public RelayCommand ClearCommand { get; set; }
        public RelayCommand RemoveQuestionCommand { get; set; }

        #endregion

        #region Constructor
        public EditViewModel(JsonManager saveAndLoad, ObservableCollection<Models.Quiz> allQuizzes)
        {
            CreateQuizCommand = new RelayCommand(o => { CreateQuiz(); }, o => true);
            AddQuestionCommand = new RelayCommand(o => { AddQuestion(); }, o => CanAddQuestion());
            RemoveQuestionCommand = new RelayCommand(o => { RemoveQuestion(); }, o => IsQuestionSelected());
            SaveQuizToFileCommand = new RelayCommand(o => { _ = SaveQuizToFile(); }, o => CanSaveQuiz());
            LoadQuizFromFileCommand = new RelayCommand(o => { _ = LoadQuizFromFile(); }, o => CanLoadQuiz());
            SaveSelectedQuizCommand = new RelayCommand(o => { SaveSelectedQuiz(); }, o => CanSaveQuiz());
            DeleteSelectedQuizCommand = new RelayCommand(o => { DeleteSelectedQuiz(); }, o => IsQuizSelected());
            EditQuestionCommand = new RelayCommand(o => { EditQuestion(); }, o => IsQuestionSelected());
            AddImageCommand = new RelayCommand(o => { AddImageToQuestion(); }, o => IsQuestionSelected());
            ClearCommand = new RelayCommand(o => { ClearTextBoxes(); }, o => true);
            LoadQuizzes();
            this._saveAndLoad = saveAndLoad;
            AllQuizzes = allQuizzes;
        }
        #endregion

        #region Methods
        //Ett nytt quiz skapas
        public void CreateQuiz()
        {
            SelectedQuiz = new Models.Quiz { Title = QuizName, QuestionsList = new ObservableCollection<Question>() };
            QuizList.Add(SelectedQuiz);
            ClearTextBoxes();
            MessageBox.Show("A new quiz has been saved within the program");
        }

        //Om det markerade quizzet har mer än 0 frågor returnerar metoden true och quizzet kan sparas
        public bool CanSaveQuiz()
        {
            if (_selectedQuiz?.QuestionsList.Count > 0)
            {
                return true;
            }
            return false;
        }

        //En fråga skapas till det markerade quizzet med värden properties
        public void AddQuestion()
        {
            SelectedQuiz.AddQuestion(Statement, CorrectAnswer, Category, Answer1, Answer2, Answer3);
            ClearTextBoxes();
            MessageBox.Show("Question has been saved to the quiz");
        }

        //Den markerade frågan av det markerade quizzet tas bort med hjälp av index. Står quizzet utan frågor tas det bort ur listan för alla spelbara quiz
        public void RemoveQuestion()
        {
            int index = SelectedQuiz.QuestionsList.ToList().IndexOf(SelectedQuestion);
            SelectedQuiz.RemoveQuestion(index);
            if (SelectedQuiz.QuestionsList.Count <= 0)
            {
                AllQuizzes.Remove(SelectedQuiz);
            }
            ClearTextBoxes();
        }
        
        //Den markerade frågan redigeras
        public void EditQuestion()
        {
            SelectedQuestion.Statement = Statement;
            SelectedQuestion.Answers[0] = Answer1;
            SelectedQuestion.Answers[1] = Answer2;
            SelectedQuestion.Answers[2] = Answer3;
            SelectedQuestion.ChangeCorrectAnswer(CorrectAnswer);
            SelectedQuestion.Category = Category;
            ClearTextBoxes();
            MessageBox.Show("The selected question has been edited");
        }

        //Tömmer textboxarna på innehåll
        public void ClearTextBoxes()
        {
            Statement = null;
            Answer1 = null;
            Answer2 = null;
            Answer3 = null;
            Category = null;
            SelectedQuestion = null;
            QuizName = null;
        }

        //Returnerar true om en fråga är markerad
        public bool IsQuestionSelected() { return SelectedQuestion != null; }

        //Returnerar true om ett quiz är markerat
        public bool IsQuizSelected() { return SelectedQuiz != null; }

        //Kontrollerar att alla properties har ett värde och att ett quiz är markerat
        public bool CanAddQuestion()
        {
            return Statement != null && Answer1 != null && Answer2 != null && Answer3 != null && Category != null && IsQuizSelected();
        }

        //Returnerar true om QuizList inte laddats
        public bool CanLoadQuiz()
        {
            return QuizListLoaded == false;
        }

        //Sparar över det markerade quizzet
        public void SaveSelectedQuiz()
        {
            AllQuizzes.Remove(SelectedQuiz);
            AllQuizzes.Add(SelectedQuiz);
            MessageBox.Show("The current quiz has been saved and is now playable");
        }

        //Tar bort det markerade quizzet från spelbara quiz och listvyn 
        public void DeleteSelectedQuiz()
        {
            AllQuizzes.Remove(SelectedQuiz);
            QuizList.Remove(SelectedQuiz);
            MessageBox.Show("The selected quiz has been removed");
        }

        //Sparar alla quiz till json-fil
        public async Task SaveQuizToFile()
        {
            await _saveAndLoad.SaveQuiz(QuizList);
            MessageBox.Show("The selected quiz has been saved to file");
        }

        //Laddar quiz från fil
        public async Task LoadQuizFromFile()
        {
            foreach (var quiz in await _saveAndLoad.LoadQuiz())
            {
                QuizList.Add(quiz);
                AllQuizzes.Add(quiz);
            }
            QuizListLoaded = true;
        }

        //Sparar en bild till markerad fråga
        public void AddImageToQuestion()
        {
            var openFileDialog = new OpenFileDialog()
            {
                Filter = "Image Files(*.PNG;*.JPG;*.JPEG)|*.PNG;*.JPG;*.JPEG|All files (*.*) | *.*"
            };
            if (openFileDialog.ShowDialog() == true)
            {
                SelectedQuestion.Image = openFileDialog.FileName;
            }
        }

        //Sätter QuizList till en observableCollection
        private void LoadQuizzes()
        {
            QuizList = new ObservableCollection<Models.Quiz>();
        }

        #endregion
    }
}
