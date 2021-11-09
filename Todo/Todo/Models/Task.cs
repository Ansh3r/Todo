using Xamarin.Forms;
using Todo.ViewModels;

namespace Todo.Models
{
    public class Task : BindableObject
    {
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

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private bool _ready;
        public bool Ready
        {
            get => _ready;
            set
            {
                _ready = value;
                OnPropertyChanged(nameof(Ready));
            }
        }
    }
}
