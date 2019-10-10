using Android.App;
using Android.Widget;
using App3.View;
using App5.Model;
using App5.Utils;
using EncryptStringSample;
using SQLite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using SQLiteConnection = SQLite.SQLiteConnection;

namespace App5.ViewModel
{
    public class LoginPageViewModel : PropertyChangedClass
    {
        private string email;

        public string Email
        {
            get => email;
            set
            {
                email = value;
                OnPropertyChanged();
            }
        }

        private string password;

        public string Password
        {
            get => password;
            set
            {
                password = value;
                OnPropertyChanged();
            }
        }

        private ICommand _login;
        public ICommand GoToInformationPage
            => _login ?? (_login = new DelegateCommand<object>((args) =>
            {
                LogIn();
            }
        ));

        private void LogIn()
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Call Database  
                var db = new SQLiteConnection(dpPath);
                var data = db.Table<User>();
                var data1 = data.Where(x => x.Email == Email).FirstOrDefault();
                if (data1 != null && StringCipher.Decrypt(data1.Password, Password) == Password)
                {
                    App.Current.MainPage = new InformationPage2();
                }

                else
                {
                    Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Logging error", "Not correct login or password", "ok");

                }
            }
            catch (Exception ex)
            {
            }
        }



        public string CreateDB()
        {
            var output = "";
            output += "Creating Databse if it doesnt exists";
            string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3"); //Create New Database  
            var db = new SQLiteConnection(dpPath);
            output += "\n Database Created....";
            return output;
        }
    }
}
