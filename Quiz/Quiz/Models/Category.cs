using Quiz.ViewModels;

namespace Quiz.Models
{
    public class Category : BaseViewModel
    {
        //Klassen kommer instansieras för att kunna implementera kategorier i frågor.
        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        //Propertyn kommer sättas till sann om objektet i fråga blivit markerat innan quizzet startar.
        private bool _isSelected;

        public bool IsSelected
        {
            get => _isSelected;
            set
            {
                _isSelected = value;
                OnPropertyChanged(nameof(IsSelected));
            }
        }
    }
}
