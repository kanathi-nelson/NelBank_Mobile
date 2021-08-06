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
    public partial class AccountTransferPage : ContentPage
    {
        public AccountTransferViewmodel ViewModel;
        public AccountTransferPage(AccountTransferViewmodel viewModel)
        {
            InitializeComponent();
            BindingContext = this.ViewModel = viewModel;

        }
        public AccountTransferPage()
        {
            InitializeComponent();
            BindingContext = new AccountTransferViewmodel();
        }
       

        void WithdrawClick(System.Object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new HomePage());
        }
        async void DoPoppin(System.Object sender, System.EventArgs e)
        {
           await Navigation.PopModalAsync();
        }



    





        
        
        }
}
