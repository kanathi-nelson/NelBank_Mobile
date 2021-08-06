using NelBank.Viewmodels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NelBank
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            var model = new LoginViewModel();
            MainPage = new NavigationPage(new LoginPage(model));
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
