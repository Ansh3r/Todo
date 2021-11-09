using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Shapes;
using List = Todo.Models.Task;

namespace Todo.ViewModels
{
    public class MainViewModel : BindableObject
    {
        private readonly MainPage _page;

        private List Thiscase = null;

        public MainViewModel(ContentPage page)
        {
            _page = (MainPage)page;
            nameOfCase = "";
        }


        private Command _caseAddCollection;
        public Command CaseAddCollection => _caseAddCollection ?? (_caseAddCollection = new Command(() =>
        {
            if (nameOfCase.Length != 0)
            {
                TodoCollection.Insert(0, new List() { Name = nameOfCase, Description = "", Ready = false });
                nameOfCase = "";
            }
        }));

        private Command _caseDeleteCollection;
        public Command CaseDeleteCollection => _caseDeleteCollection ?? (_caseDeleteCollection = new Command<List>(item =>
        {
            TodoCollection.Remove(item);
            Thiscase = item;

        }));

        private ObservableCollection<List> _todoCollection { get; set; }

        public ObservableCollection<List> TodoCollection
        {
            get => _todoCollection;
            set
            {
                _todoCollection = value;
                OnPropertyChanged(nameof(TodoCollection));
            }
        }

        private string _nameofCase { get; set; }

        public string nameOfCase
        {
            get => _nameofCase;
            set
            {
                _nameofCase = value;
                OnPropertyChanged(nameof(nameOfCase));
            }
        }

        public void SaveCollectionPreferences()
        {
            Preferences.Set("Todo", JsonConvert.SerializeObject(TodoCollection));
        }

        public void LoadCollectionPreferences()
        {
            var itemJson = Preferences.Get("Todo", "[]");
            TodoCollection = JsonConvert.DeserializeObject<ObservableCollection<List>>(itemJson);
        }
    }
}
