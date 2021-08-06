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
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        async void SubmitSignup(System.Object sender, System.EventArgs e)
        {
            //Navigation.PushAsync(new HomePage());
            await Navigation.PopModalAsync();
        }
        async void DoNewLogin(System.Object sender, System.EventArgs e)
        {
           await Navigation.PopModalAsync();
        }
    }
}
