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
    public partial class MyAccountPage : ContentPage
    {
        public MyAccountPage()
        {
            InitializeComponent();
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
