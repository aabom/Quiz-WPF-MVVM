using System.Windows;

namespace Quiz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonPlay_Click(object sender, RoutedEventArgs e)
        {
            BackgroundImage.Visibility = Visibility.Collapsed;
        }

        private void ButtonEdit_Click(object sender, RoutedEventArgs e)
        {
            BackgroundImage.Visibility = Visibility.Collapsed;
        }

    }
}
