using App3.View;
using App5.Model;
using App5.Utils;
using EncryptStringSample;
using SQLite;
using System;
using System.IO;
using System.Windows.Input;
using Xamarin.Forms;

namespace App5.ViewModel
{
    public class RegisterPageViewModel : PropertyChangedClass
    {

        #region 
        public User user { get; set; }

        public RegisterPageViewModel()
        {
            user = new User();
        }

        public string UserFirstName
        {
            get { return user.FirstName; }
            set { user.LastName = value; OnPropertyChanged(); }
        }

        public string UserLastName
        {
            get { return user.LastName; }
            set { user.LastName = value; OnPropertyChanged(); }
        }

        public int UserRoom
        {
            get { return user.Room; }
            set { user.Room = value; OnPropertyChanged(); }
        }

        public string UserEmail
        {
            get { return user.Email; }
            set { user.Email = value; OnPropertyChanged(); }
        }

        public string UserPassword
        {
            get { return user.Password; }
            set { user.Password = value; OnPropertyChanged(); }
        }

        public string UserConfirmPassword
        {
            get { return user.ConfirmPassword; }
            set { user.ConfirmPassword = value; }
        }
        #endregion Properties

        private ICommand _register;
        public ICommand GoToInformationPage
            => _register ?? (_register = new DelegateCommand<object>(async (args) =>
            {
                if (RegisterValidator.Validate(user))
                {
                    InsertIntoTable();
                    await Application.Current.MainPage.Navigation.PushAsync(new InformationPage2());
                }
                else
                {
                    await Xamarin.Forms.Application.Current.MainPage.DisplayAlert("Registration error", RegisterValidator.Message.ToString(), "ok");
                    RegisterValidator.Message.Clear();
                }
            }
        ));

        private void InsertIntoTable()
        {
            try
            {
                string dpPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "user.db3");
                var db = new SQLiteConnection(dpPath);
                db.CreateTable<User>();
                user.Password = StringCipher.Encrypt(user.Password, user.Password);                
                db.Insert(user);
            }
            catch (Exception ex)
            {
            }
        }
        public bool CreateDatabase()
        {
            try
            {
                string folder = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
                using (var connection = new SQLiteConnection(System.IO.Path.Combine(folder, "Persons.db")))
                {
                    connection.CreateTable<User>();
                    return true;
                }
            }
            catch (SQLiteException ex)
            {
                return false;
            }
        }






    }
}
