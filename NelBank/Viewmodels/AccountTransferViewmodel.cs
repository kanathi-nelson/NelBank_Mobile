using NelBank.Models;
using NelBank.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NelBank.Viewmodels
{
    public class AccountTransferViewmodel :BaseViewModel
    {
        public AccountTransferViewmodel()
        {
            BanksList = new ObservableCollection<string>();
            AddBanksList();
        }

        void AddBanksList()
        {
            var mybanks = FillBanks();
            foreach(var a in mybanks)
            {
                BanksList.Add(a);
            }
        }
        
        public ICommand DoTransferCommand
        {
            get
            {
                return new Command(TransferFunds);
            }
        }
        private ObservableCollection<string> _bankslist { get; set; }
        public ObservableCollection<string> BanksList

        {
            get { return _bankslist; }
            set
            {
                _bankslist = value;
                OnPropertyChanged("BanksList");
            }
        }
        private string banksval_ = string.Empty;

        public string BanksVal
        {
            get { return banksval_; }
            set
            {
                if (banksval_ == value)
                    return;

                banksval_ = value;
                OnPropertyChanged("BanksVal");
            }
        }
         
        private string accountno_ = string.Empty;
        public string AccountNo
        {
            get { return accountno_; }
            set
            {
                if (accountno_ == value)
                    return;

                accountno_ = value;
                OnPropertyChanged("AccountNo");
            }
        }
         
        private string amount_ = string.Empty;

        public string Amount
        {
            get { return amount_; }
            set
            {
                if (amount_ == value)
                    return;

                amount_ = value;
                OnPropertyChanged("Amount");
            }
        }

       private bool _isaccounterror = false;

        public bool IsAccountError
        {
            get { return _isaccounterror; }
            set
            {
                if (_isaccounterror == value)
                    return;

                _isaccounterror = value;
                OnPropertyChanged("IsAccountError");
            }
        }
        private bool _isbankerror = false;

        public bool IsBankError
        {
            get { return _isbankerror; }
            set
            {
                if (_isbankerror == value)
                    return;

                _isbankerror = value;
                OnPropertyChanged("IsBankError");
            }
        }
        private bool _isamounterror = false;

        public bool IsAmountError
        {
            get { return _isamounterror; }
            set
            {
                if (_isamounterror == value)
                    return;

                _isamounterror = value;
                OnPropertyChanged("IsAmountError");
            }
        }


        public IEnumerable<string> FillBanks()
        {
            List<string> Gend = new List<string>();
            Gend.Add("Nel-Bank");
            Gend.Add("I&M Bank");
            Gend.Add("Co-op Bank");
            return Gend.AsEnumerable();
        }

        public async void TransferFunds()
        {
            if (string.IsNullOrEmpty(BanksVal))
            {
                IsBankError = true;
                return;
            }
            IsBankError = false;
            if (string.IsNullOrEmpty(AccountNo))
            {
                IsAccountError = true;
                return;
            }
            IsAccountError = false;
             if (string.IsNullOrEmpty(Amount))
            {
                IsAmountError = true;
                return;
            }
            IsAmountError = false;
            var result = await App.Current.MainPage.DisplayAlert("Confirm", "Click Ok to transfer ksh. " + Amount + " to " + BanksVal + " account No. " + AccountNo, "Ok", "Cancel");
            if (result == true)
            {
                IsBusy = true;
                int usaid_ = Settings.UserId;
                int accid = Settings.AccountId;
                string acc_ = Settings.AccountName;
                AccTransferViewmodel transferViewmodel = new AccTransferViewmodel()
                {
                    Amount = Convert.ToDecimal(Amount),
                    AccountId = accid,
                    AccountNo = AccountNo,
                    FromAccount =  acc_,
                    Bank = BanksVal,
                    UserId =  usaid_
                };
               var myresult = await SendData_(transferViewmodel);
                if(myresult=="ok")
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Success", "Transfer successfully completed", "Ok");
                    await App.Current.MainPage.Navigation.PopModalAsync();
                }
                else if(myresult=="failed")
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Failed", "An error occurred when transferring funds, Please try again later.", "Ok");
                }
                else
                {
                    IsBusy = false;
                    await App.Current.MainPage.DisplayAlert("Failed", myresult, "Ok");
                }
            }
            else
            {
                return;
            }
        }


        public async Task<string> SendData_(AccTransferViewmodel viewmodel)
        {
            try
            {
                var client = new HttpClient();
                var content = new StringContent(JsonConvert.SerializeObject(viewmodel), Encoding.UTF8, "application/json");
                string fullapi = StaticData.BaseApiUrl + "BankApi/AddTransaction/";
                client.Timeout = TimeSpan.FromMinutes(5);
                Uri uri = new Uri(string.Format(fullapi, string.Empty));
                HttpResponseMessage response = await client.PostAsync(uri, content);
                string responsecontent = await response.Content.ReadAsStringAsync();
                if (response.IsSuccessStatusCode)
                {
                    return "ok";
                }
                else
                {
                    return responsecontent;
                }


            }
            catch (Exception Ex)
            {

                var msg = Ex.Message;
                var stck = Ex.StackTrace;
                var innere = Ex.InnerException;
                var srrc = Ex.Source;

                return "failed";
            }

        }








    }
}
