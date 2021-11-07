using System.Windows;
using System.Windows.Controls;

namespace Quiz.Views
{
    /// <summary>
    /// Interaction logic for PlayView.xaml
    /// </summary>
    public partial class PlayView : UserControl
    {
        public PlayView()
        {
            InitializeComponent();
        }

        private void ButtonStart_click(object sender, RoutedEventArgs e)
        {
            PlayButton.Visibility = Visibility.Hidden;
            FirstStackPanel.Visibility = Visibility.Visible;
            SecondStackPanel.Visibility = Visibility.Visible;
            UserScoreTb.Visibility = Visibility.Visible;
            SlashSignTb.Visibility = Visibility.Visible;
            AmountOfQuestionsTb.Visibility = Visibility.Visible;
            PickQuizComboBox.Visibility = Visibility.Hidden;
            QuizTitleTb.Visibility = Visibility.Visible;
            CategoriesListBox.Visibility = Visibility.Hidden;
            QuestionImage.Visibility = Visibility.Visible;
        }
    }
}
