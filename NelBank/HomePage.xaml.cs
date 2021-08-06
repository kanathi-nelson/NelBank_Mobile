using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace NelBank
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        void WithdrawClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new WithdrawPage());
        }
        void AccountTransferClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new AccountTransferPage());
        }
        void MyAccountClicked(System.Object sender, System.EventArgs e)
        {
            Navigation.PushModalAsync(new MyAccountPage());
        }
    }
}
