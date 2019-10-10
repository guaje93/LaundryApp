using App3.View;
using App5.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace App5.ViewModel
{
    public class StartPageViewModel
    {
        private ICommand _goToLoginPage;
        public ICommand GoToLoginPage
            => _goToLoginPage ?? (_goToLoginPage = new DelegateCommand<object>(async (args) =>
            {
                //App.Current.MainPage = new LoginPage2();
                await Application.Current.MainPage.Navigation.PushAsync(new LoginPage2());
            }
        ));

        private ICommand _goToRegisterPage;
        public ICommand GoToRegisterPage
            => _goToRegisterPage ?? (_goToRegisterPage = new DelegateCommand<object>(async (args) => { 

                await Application.Current.MainPage.Navigation.PushAsync(new RegisterPage2());
             
    }
    ));
    }
}
