using System.Windows;
using Quiz.ViewModels;

namespace Quiz
{
    public partial class App : Application
    {
        //En override på OnStartup gör att programmet startar här och datacontexten för MainWindow sätts till MainViewModel
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
            MainWindow.Show();
            base.OnStartup(e);
        }
    }
}
