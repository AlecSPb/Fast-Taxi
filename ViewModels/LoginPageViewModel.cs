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
        public MyCommand SignUpComamnd { get; set; }

        public MyCommand Login_PageCommand { get; set; }
        public MyCommand SignUp_PageComamnd { get; set; }




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
            get { return _passwordtxtbox; }
            set
            {
                _passwordtxtbox = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region Top Line Visibility

        private Visibility _loginvisibility;

        public Visibility LoginVisibility
        {
            get { return _loginvisibility; }
            set { _loginvisibility = value;  OnPropertyChanged(); }
        }




        private Visibility _signupvisibility;

        public Visibility SignUpVisibility
        {
            get { return _signupvisibility; }
            set { _signupvisibility = value; OnPropertyChanged(); }
        }

        #endregion

        private Grid _usercontrolpanel;
        public Grid UserControlPanel
        {
            get { return _usercontrolpanel; }
            set { _usercontrolpanel = value; OnPropertyChanged(); }
        }

    
        public UserControlLogin userControlLogin { get; set; }
        public UserControlSignUp userControlSignUp { get; set; }
        public LoginPageViewModel()
        {
            UserControlPanel = new Grid();
            userControlLogin = new UserControlLogin();
            userControlSignUp = new UserControlSignUp();
            LoginVisibility = Visibility.Visible;
            SignUpVisibility = Visibility.Hidden;




            UserControlPanel.Children.Add(userControlLogin);







            Login_PageCommand = new MyCommand(Login_PageExecute, Login_PageCanExecute);
            SignUp_PageComamnd = new MyCommand(SignUp_PageExecute, SignUp_PageCanExecute);

            LoginCommand = new MyCommand(LoginCommandExecute,LoginCommandCanExecute);
        }

        private void LoginCommandExecute(object obj)
        {
            PasswordTxtBox = (obj as PasswordBox).Password;
            MessageBox.Show(PasswordTxtBox);
        }
        private bool LoginCommandCanExecute(object obj)
        {
            return true;
        }




        private void Login_PageExecute(object obj)
        {
            LoginVisibility = Visibility.Visible;
            SignUpVisibility = Visibility.Hidden;
            UserControlPanel.Children.Clear();
            UserControlPanel.Children.Add(userControlLogin);
        }
        private bool Login_PageCanExecute(object obj)
        {
            return true;
        }



        private void SignUp_PageExecute(object obj)
        {
            LoginVisibility = Visibility.Hidden;
            SignUpVisibility = Visibility.Visible;
            UserControlPanel.Children.Clear();
            UserControlPanel.Children.Add(userControlSignUp);
        }
        private bool SignUp_PageCanExecute(object obj)
        {
            return true;
        }

    }
}
