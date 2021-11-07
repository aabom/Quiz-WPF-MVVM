using System.ComponentModel;

namespace Quiz.ViewModels
{
    //Denna klass fungerar som grund för övriga klasser som behöver implementera interfacet INotifyPropertyChanged
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
