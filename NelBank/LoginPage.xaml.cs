using NelBank.Viewmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NelBank
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class LoginPage : ContentPage
    {
        public LoginViewModel ViewModel;
        public LoginPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = viewModel;

        }
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = new LoginViewModel();
        }

       

        void LoginClicked(System.Object sender, System.EventArgs e)
        {
            //if (ViewModel.DoLoginCommand.CanExecute(null))
            //{
            //this.ViewModel.DoLoginCommand.Execute(null);
            //ViewModel.DoLogin();
            //}
            //Navigation.PushAsync(new HomePage());
        }

        async void SignupClick(System.Object sender, System.EventArgs e)
        {
           await Navigation.PushModalAsync(new SignupPage());
        }
    }
}
