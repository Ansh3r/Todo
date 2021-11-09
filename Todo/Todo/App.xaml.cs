using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Todo.ViewModels;
namespace Todo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.LoadCollectionPreferences();
            }
        }

        protected override void OnSleep()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.SaveCollectionPreferences();
            }
        }

        protected override void OnResume()
        {
            if (MainPage.BindingContext is MainViewModel viewModel)
            {
                viewModel.LoadCollectionPreferences();
            }
        }
    }
}
