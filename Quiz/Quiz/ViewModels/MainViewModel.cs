using System.Collections.ObjectModel;
using Quiz.Commands;
using Quiz.FileManager;
using Quiz.Models;

namespace Quiz.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        public MainViewModel()
        {
            //Lista där alla quiz kommer läggas
            ObservableCollection<Models.Quiz> allQuizzes = new();
            //Instansiering av quiz som kommer agera default quiz
            Models.Quiz startQuiz = new() {Title = "StartQuiz"};
            //Startquizzet får sitt innehåll och läggs därefter i quizlistan
            CreateStartQuiz(startQuiz);
            allQuizzes.Add(startQuiz);
            JsonManager saveAndLoad = new();
            //De två vymodellerna instansieras
            PlayVM = new PlayViewModel(allQuizzes);
            EditVM = new EditViewModel(saveAndLoad, allQuizzes);

            //Commands för navigering mellan de två olika vymodellerna
            PlayViewCommand = new NavigateCommand(o =>
            {
                CurrentView = PlayVM;
            });
            EditViewCommand = new NavigateCommand(o =>
            {
                CurrentView = EditVM;
            });
        }

        public NavigateCommand PlayViewCommand { get; set; }
        public NavigateCommand EditViewCommand { get; set; }

        public PlayViewModel PlayVM { get; set; }
        public EditViewModel EditVM { get; set; }

        //Värdet på propertyn sätts beroende på vilket command som körts
        private object _currentView;
        public object CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged(nameof(CurrentView));
            }
        }

        //Programmets default quiz
        private static void CreateStartQuiz(Models.Quiz startQuiz)
        {
            Question first = new("Vad heter staden?", 2, "Geography", "/Images/paris.jpg", "Rom", "Tokyo", "Paris");
            Question second = new("Vad heter djuret?", 0, "Nature", "/Images/tiger.jpg", "Tiger", "Zebra", "Mus");
            Question third = new("Vad heter verktyget?", 1, "General", "/Images/skiftnyckel.jpg", "Polygrip", "Skiftnyckel", "Hammare");
            Question fourth = new("Vad heter artisten?", 1, "Music", "/Images/beyonce.jpg", "Rihanna", "Beyonce", "Pink");
            Question fifth = new("Vad är detta?", 2, "Food","/Images/kaffe.png", "Te", "Juice", "Vital del av programmering");
            Question sixth = new("Vad är ljudets hastighet vid 20°C?", 2, "Science", "/Images/speedofsound.jpg", "900 km/h", "1050 km/h", "1,200 km/h");
            Question seventh = new("Vilket lag spelar sina hemmamatcher här?", 0, "Sports", "/Images/anfield.jpg", "Liverpool", "Arsenal", "Manchester United");
            startQuiz.QuestionsList.Add(first);
            startQuiz.QuestionsList.Add(second);
            startQuiz.QuestionsList.Add(third);
            startQuiz.QuestionsList.Add(fourth);
            startQuiz.QuestionsList.Add(fifth);
            startQuiz.QuestionsList.Add(sixth);
            startQuiz.QuestionsList.Add(seventh);
        }
    }
}
