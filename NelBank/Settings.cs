// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;
using System;

namespace NelBank
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }
       
        public static string Username
        {
            get
            {
                return AppSettings.GetValueOrDefault("usern", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("usern", value);
            }
        } 
        public static string Name
        {
            get
            {
                return AppSettings.GetValueOrDefault("name", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("name", value);
            }
        }

        public static string Password
        {
            get
            {
                return AppSettings.GetValueOrDefault("Passwrd", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Passwrd", value);
            }
        }
         
        
        public static bool IsLoggedIn
        {
            get
            {
                return AppSettings.GetValueOrDefault("Loggedin",false);
            }
            set
            {
                AppSettings.AddOrUpdateValue("Loggedin", value);
            }
        }
         public static int AccountId
        {
            get
            {
                return AppSettings.GetValueOrDefault("Accountid", 0);
            }
            set
            {
                AppSettings.AddOrUpdateValue("Accountid", value);
            }
        }
         public static string AccountName
        {
            get
            {
                return AppSettings.GetValueOrDefault("Accountname", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Accountname", value);
            }
        }
         public static string AccountType
        {
            get
            {
                return AppSettings.GetValueOrDefault("Accounttype", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Accounttype", value);
            }
        } 
        public static int UserId
        {
            get
            {
                return AppSettings.GetValueOrDefault("Userid", 0);
            }
            set
            {
                AppSettings.AddOrUpdateValue("Userid", value);
            }
        }
         public static string AccountBalance
        {
            get
            {
                return AppSettings.GetValueOrDefault("Accountbalance", "");
            }
            set
            {
                AppSettings.AddOrUpdateValue("Accountbalance", value);
            }
        }

        public static DateTime AccessTokenExpirationDate
        {
            get
            {
                return AppSettings.GetValueOrDefault("AccessTokenExpirationDate", DateTime.UtcNow);
            }
            set
            {
                AppSettings.AddOrUpdateValue("AccessTokenExpirationDate", value);
            }
        }
    }
}