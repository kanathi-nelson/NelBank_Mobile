using NelBank.Models;
using NelBank.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NelBank.Viewmodels
{
    public class LoginViewModel : BaseViewModel
    {
        HttpClient client_;
        
        private bool _isusernameerror = false;
        public bool IsUsernameError
        {
            get { return _isusernameerror; }
            set
            {
                if (_isusernameerror == value)
                    return;

                _isusernameerror = value;
                OnPropertyChanged("IsUsernameError");
            }
        }
        private bool _ispassworderror = false;
        public bool IsPasswordError
        {
            get { return _ispassworderror; }
            set
            {
                if (_ispassworderror == value)
                    return;

                _ispassworderror = value;
                OnPropertyChanged("IsPasswordError");
            }
        }
        private string _username = string.Empty;
        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);

        }
        public string Password { get; set; }
        public ICommand DoLoginCommand //Tapped="LoginClicked"
        {
            get
            {
                return new Command(DoLogin);
            }
        }
        public LoginViewModel()
        {
            IsUsernameError = false;
            IsPasswordError = false;
            client_ = new HttpClient();

        }
        public async void DoLogin()
        {
            IsBusy = true;
            try
            {
                

                if (string.IsNullOrEmpty(UserName))
                {
                    IsUsernameError = true;
                    return;
                }
                IsUsernameError = false;
                if (string.IsNullOrEmpty(Password))
                {
                    IsPasswordError = true;
                    return;
                }
                IsPasswordError = false;
                //AccountLoginResp login = new AccountLoginResp();
                AccountLoginResp login =  await loginSys(UserName, Password);
                if(login!=null)
                {

                    if (login.status.Contains("failed"))
                    {
                        IsBusy = false;
                        await App.Current.MainPage.DisplayAlert("Failed", login.message, "Ok");
                    }
                    else
                    {
                        IsBusy = false;
                        Settings.AccountId = login.accountId;
                        Settings.AccountName = login.accountNo;
                        Settings.AccountType = login.accountType;
                        Settings.AccountBalance = login.accountBalance;
                        Settings.UserId = login.userId;
                        Settings.IsLoggedIn = true;
                        Settings.Username = UserName;
                        Settings.Password = Password;
                        Settings.Name = login.username;
                        await App.Current.MainPage.DisplayAlert("Success", "Successfully logged in", "Ok");
                        await App.Current.MainPage.Navigation.PopAsync();
                        App.Current.MainPage = new HomePage();
                        //await App.Current.MainPage.Navigation.PushAsync(new HomePage());


                    }
                }
                else
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Failed", "Login is failed due to an error.", "Ok");
                }

            }
            catch (Exception ex)
            {
                IsBusy = false;
                await Application.Current.MainPage.DisplayAlert("Failed", "Login failed", "Ok");

                var msg = ex.Message;
                var innex = ex.InnerException;
            }
        }

        public async Task<AccountLoginResp> loginSys(string Username, string pass)
        {
            try
            {
                Username = Username.Trim();
                pass = pass.Trim();
                string fullapi = StaticData.BaseApiUrl+ "BankApi/ConfirmLogin?u1=" + Username + "&p1=" + pass;
                Uri uri = new Uri(string.Format(fullapi, string.Empty));
                HttpResponseMessage response = await client_.GetAsync(uri);
                string content = await response.Content.ReadAsStringAsync();
                 if (response.IsSuccessStatusCode)
                    {
                        AccountLoginResp vals1 = JsonConvert.DeserializeObject<AccountLoginResp>(content);
                        return vals1;
                    }
                    else
                    {
                        AccountLoginResp accountLoginResp = new AccountLoginResp();
                        accountLoginResp.status = "failed";
                        accountLoginResp.username = string.Empty;
                        accountLoginResp.userId = 0;
                        accountLoginResp.fromAccount = string.Empty;
                        accountLoginResp.accountId = 0;
                        accountLoginResp.message = content;
                       


                        return accountLoginResp;
                    }
               
            }
            catch(Exception ex)
            {
                AccountLoginResp accountLoginResp = new AccountLoginResp();
                accountLoginResp.status = "failed";
                accountLoginResp.message = ex.Message;
                accountLoginResp.username = string.Empty;
                accountLoginResp.userId = 0;
                accountLoginResp.fromAccount = string.Empty;
                accountLoginResp.accountId = 0;
                return accountLoginResp;
            }
            
        }

    }
}
