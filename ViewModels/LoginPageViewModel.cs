using Babat_Taxi.Command;
using Babat_Taxi.UserControls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Babat_Taxi.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {


        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion


        #region Commands
        public MyCommand LoginCommand { get; set; }

        #endregion


        public string EmailTxtBox { get; set; }
        public string PasswordTxtBox { get; set; }

        public Visibility IsFocusPassword { get; set; }
        public Visibility IsFocusEmail { get; set; }

        public Grid UserControl_log_and_signup { get; set; }

        public LoginPageViewModel()
        {
            LoginCommand = new MyCommand(LoginCommandExecute);
            UserControl_log_and_signup = new Grid();
            UserControlLogin userControlLogin = new UserControlLogin();
            UserControl_log_and_signup.Children.Add(userControlLogin);
        }

        private void LoginCommandExecute(object obj)
        {
            MessageBox.Show("Test");
        }
        private bool LoginCommandCanExecute(object obj)
        {
            return true;
        }
    }
}
