using DFS.Core;
using DFS.Services;
using DFS.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DFS.ViewModel
{
   public class LoginViewModel :BaseViewModel
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value;

                OnPropertyChanged("UserName");
            }
        }

        private string password;

        public string Password
        {
            get { return password; }
            set { password = value;
                OnPropertyChanged("Password");
            }
        }


        private ICommand loginCommand;

        public ICommand LoginCommand
        {
            get { return loginCommand; }
            set { loginCommand = value; }
        }


        public LoginViewModel()
        {
            LoginCommand = new Command(Login);
        }

        private async void Login(object obj)
        {
            ILoginService service = new LoginService();
            
         var userInfo = await  service.GetUser(UserName, App.Base64Encode(Password));

            if (userInfo != null)
            {
                App.Current.MainPage = new RootPage();
                App.User = userInfo;
            }

        }
    }
}
