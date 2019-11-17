using Babat_Taxi.Command;
using Babat_Taxi.Services;
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
using System.Windows.Forms;
using Babat_Taxi.Views;
using MessageBox = System.Windows.MessageBox;
using Babat_Taxi.Models;

namespace Babat_Taxi.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        

        public IAccountManager AccountManager { get; set; }
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion
        #region Top Line Visibility

        private Visibility _loginvisibility;

        public Visibility LoginVisibility
        {
            get { return _loginvisibility; }
            set { _loginvisibility = value; OnPropertyChanged(); }
        }




        private Visibility _signupvisibility;

        public Visibility SignUpVisibility
        {
            get { return _signupvisibility; }
            set { _signupvisibility = value; OnPropertyChanged(); }
        }

        #endregion
        #region UserControlPanel
        private Grid _usercontrolpanel;
        public Grid UserControlPanel
        {
            get { return _usercontrolpanel; }
            set { _usercontrolpanel = value; OnPropertyChanged(); }
        }

        private Window _mywindow;
        public Window MyWindow
        {
            get { return _mywindow; }
            set { _mywindow = value; OnPropertyChanged(); }
        }

        public UserControlLogin userControlLogin { get; set; }
        public UserControlSignUp userControlSignUp { get; set; }
        public UserControlCardInfo userControlCardInfo { get; set; }
        #endregion
        #region Commands
        public MyCommand LoginCommand { get; set; }
        public MyCommand SignUpComamnd { get; set; }
        public MyCommand SignUpWithCardComamnd { get; set; }



        public MyCommand Login_PageCommand { get; set; }
        public MyCommand SignUp_PageComamnd { get; set; }




        #endregion



        #region EmailboxLogin
        private string _emailboxLogin;
        public string EmailboxLogin
        {
            get { return _emailboxLogin; }
            set
            {
                _emailboxLogin = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region PasswordboxLogin
        private string _passwordboxLogin;
        public string PasswordboxLogin
        {
            get { return _passwordboxLogin; }
            set
            {
                _passwordboxLogin = value;
                OnPropertyChanged();
            }
        }

        #endregion


        #region UsernameSignUp
        private string _usernameSignUp;

        public string UsernameSignUp
        {
            get { return _usernameSignUp; }
            set { _usernameSignUp = value; OnPropertyChanged(); }
        }

        #endregion
        #region EmailBoxSignUp
        private string _emailboxSignUp;

        public string EmailBoxSignUp
        {
            get { return _emailboxSignUp; }
            set { _emailboxSignUp = value; OnPropertyChanged(); }
        }

        #endregion
        #region PasswordboxSignUp
        private string _passwordboxSignup;

        public string PasswordboxSignUp
        {
            get { return _passwordboxSignup; }
            set { _passwordboxSignup = value; OnPropertyChanged(); }
        }

        #endregion
        #region YesRadioSignUp
        private bool _yesradioSignUp;

        public bool YesRadioSignUp
        {
            get { return _yesradioSignUp; }
            set { _yesradioSignUp = value; OnPropertyChanged(); }
        }

        #endregion
        #region NoRadioSignUp
        private bool _noradioSignUp;

        public bool NoRadioSignUp
        {
            get { return _noradioSignUp; }
            set { _noradioSignUp = value; OnPropertyChanged(); }
        }

        #endregion


        #region SignUpNext
        private string _signUpNext;
        public string SignUpNext
        {
            get { return _signUpNext; }
            set { _signUpNext = value; OnPropertyChanged(); }
        }
        #endregion



        #region CardNumber
        private string _cardnumber;

        public string CardNumberSignUp
        {
            get { return _cardnumber; }
            set { _cardnumber = value; OnPropertyChanged(); }
        }
        #endregion
        #region CCV
        private string _ccv;

        public string CCVSignUp
        {
            get { return _ccv; }
            set { _ccv = value; OnPropertyChanged(); }
        }
        #endregion
        #region ExpireDate

        private DateTime _expiredate;
        public DateTime ExpireDateSignUp
        {
            get { return _expiredate; }
            set { _expiredate = value; OnPropertyChanged(); }
        }
        #endregion




        public LoginPageViewModel(IAccountManager accountManager)
        {
            UserControlPanel = new Grid();
            userControlLogin = new UserControlLogin();
            userControlSignUp = new UserControlSignUp();
            userControlCardInfo = new UserControlCardInfo();
            LoginVisibility = Visibility.Visible;
            SignUpVisibility = Visibility.Hidden;
            UserControlPanel.Children.Add(userControlLogin);
            AccountManager = accountManager;

            if (JsonReader.ReadFromFile(AccountManager.Accounts) == null)
                AccountManager.Accounts = new List<Account>();

            else
                AccountManager.Accounts = JsonReader.ReadFromFile(AccountManager.Accounts);
            ExpireDateSignUp = DateTime.Today;
            





            Login_PageCommand = new MyCommand(Login_PageCommandExecute, Login_PageCommandCanExecute);
            SignUp_PageComamnd = new MyCommand(SignUp_PageCommandExecute);

            LoginCommand = new MyCommand(LoginCommandExecute, LoginCommandCanExecute);
            SignUpComamnd = new MyCommand(SignUpCommandExecute, SignUpCommandCanExecute);

            SignUpWithCardComamnd = new MyCommand(SignUpWithCardComamndExecute, SignUpWithCardCanComamndExecute);
        }
        private void Login_PageCommandExecute(object obj)
        {
           
            LoginVisibility = Visibility.Visible;
            SignUpVisibility = Visibility.Hidden;
            UserControlPanel.Children.Clear();
            UserControlPanel.Children.Add(userControlLogin);
        }
        private bool Login_PageCommandCanExecute(object obj)
        {
            MyWindow = (obj as Window);
            if (YesRadioSignUp)
            {
                SignUpNext = "Next";
            }
            else
            {
                SignUpNext = "Sign Up";
            }
            return true;
        }
        private void SignUp_PageCommandExecute(object obj)
        {

            LoginVisibility = Visibility.Hidden;
            SignUpVisibility = Visibility.Visible;
            UserControlPanel.Children.Clear();
            UserControlPanel.Children.Add(userControlSignUp);
        }


        private void SignUpWithCardComamndExecute(object obj)
        {
            AccountManager.AddAccount(UsernameSignUp, EmailBoxSignUp, PasswordboxSignUp, YesRadioSignUp, new Card { 
            CardNumber = CardNumberSignUp,
            CCV = CCVSignUp,
            ExpireDate = ExpireDateSignUp
            });
            MessageBox.Show("Succesfully registered!", "Account info", MessageBoxButton.OK, MessageBoxImage.Information);
            JsonWriter.WriteToFile(AccountManager.Accounts);
            LoginVisibility = Visibility.Visible;
            SignUpVisibility = Visibility.Hidden;
            UserControlPanel.Children.Clear();
            UserControlPanel.Children.Add(userControlLogin);

            UsernameSignUp = "";
            EmailBoxSignUp = "";
            YesRadioSignUp = false;
            NoRadioSignUp = false;
            CardNumberSignUp = "";
            CCVSignUp = "";
        }
        private bool SignUpWithCardCanComamndExecute(object obj)
        {
            if (string.IsNullOrEmpty(CardNumberSignUp) || string.IsNullOrEmpty(CCVSignUp) || !AccountManager.DateAvaibility(ExpireDateSignUp))
            {
                return false;
            }
            else if (CardNumberSignUp.Contains("_") || CCVSignUp.Contains("_") || !AccountManager.DateAvaibility(ExpireDateSignUp))
                return false;
            else
                return true;
        }

        private void LoginCommandExecute(object obj)
        {
            PasswordboxLogin = (obj as PasswordBox).Password;

            if (!string.IsNullOrEmpty(PasswordboxLogin))
            {
                if (AccountManager.HaveAccount(EmailboxLogin, PasswordboxLogin))
                {
                    AutoClosingMessageBox.Show("Login Succesfully, please wait....", "Account info");
                    MainMap mainMap = new MainMap(AccountManager, AccountManager.GetAccount(EmailboxLogin, PasswordboxLogin));
                    EmailboxLogin = "";
                    PasswordboxLogin = "";
                    mainMap.Show();
                    MyWindow.Close();
                }
                else
                    MessageBox.Show("Wrong Email or Password", "Account info", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
        private bool LoginCommandCanExecute(object obj)
        {
            if (string.IsNullOrEmpty(EmailboxLogin)) return false;
            else return true;
        }


        private void SignUpCommandExecute(object obj)
        {
            if (UserControlPanel.Children[0] != userControlCardInfo)
                PasswordboxSignUp = (obj as PasswordBox).Password;


            if (!string.IsNullOrEmpty(PasswordboxSignUp))
            {
                if (AccountManager.HaveDublicateUsername(UsernameSignUp))
                {
                    MessageBox.Show("This username has already registered", "Account info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else if (AccountManager.HaveDublicateEmail(EmailBoxSignUp))
                {
                    MessageBox.Show("This email has already registered", "Account info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (!YesRadioSignUp && NoRadioSignUp)
                    {
                        AccountManager.AddAccount(UsernameSignUp, EmailBoxSignUp, PasswordboxSignUp, YesRadioSignUp);
                        MessageBox.Show("Succesfully registered!", "Account info", MessageBoxButton.OK, MessageBoxImage.Information);
                        JsonWriter.WriteToFile(AccountManager.Accounts);

                        LoginVisibility = Visibility.Visible;
                        SignUpVisibility = Visibility.Hidden;
                        UserControlPanel.Children.Clear();
                        UserControlPanel.Children.Add(userControlLogin);

                        UsernameSignUp = "";
                        EmailBoxSignUp = "";
                        YesRadioSignUp = false;
                        NoRadioSignUp = false;
                    }
                    else
                    {
                        UserControlPanel.Children.Clear();
                        UserControlPanel.Children.Add(userControlCardInfo);
                    }
                }

            }



        }
        private bool SignUpCommandCanExecute(object obj)
        {

            if (string.IsNullOrEmpty(UsernameSignUp) || string.IsNullOrEmpty(EmailBoxSignUp) || (YesRadioSignUp == false && NoRadioSignUp == false)) return false;
            else return true;
        }


    }
}
