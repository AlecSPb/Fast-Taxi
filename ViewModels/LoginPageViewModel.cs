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
        public MyCommand Login_Page { get; set; }
        public MyCommand SignUp_Page { get; set; }



        #endregion



        #region EmailBox
        private string _emailtxtbox;
        public string EmailTxtBox
        {
            get { return _emailtxtbox; }
            set {
                _emailtxtbox = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region PasswordBox
        private string _passwordtxtbox;
        public string PasswordTxtBox
        {
            get { return _emailtxtbox; }
            set
            {
                _passwordtxtbox = value;
                OnPropertyChanged();
            }
        }

        #endregion


        


        public Grid UserControl_log_and_signup { get; set; }

        public LoginPageViewModel()
        {
            UserControl_log_and_signup = new Grid();
            UserControlLogin userControlLogin = new UserControlLogin();

            UserControlSignUp userControlSignUp = new UserControlSignUp();
            UserControl_log_and_signup.Children.Add(userControlSignUp);





            


            LoginCommand = new MyCommand(LoginCommandExecute,LoginCommandCanExecute);
            SignUp_Page = new MyCommand(Login_PageExecute,Login_PageCanExecute);
        }

        private void LoginCommandExecute(object obj)
        {
            MessageBox.Show(EmailTxtBox);
        }
        private bool LoginCommandCanExecute(object obj)
        {
            return true;
        }




        private void Login_PageExecute(object obj)
        {

        }
        private bool Login_PageCanExecute(object obj)
        {
            return true;
        }





    }
}
