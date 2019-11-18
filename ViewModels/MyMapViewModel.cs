using Babat_Taxi;
using Babat_Taxi.Command;
using Babat_Taxi.Models;
using Babat_Taxi.Services;
using Babat_Taxi.UserControls;
using Babat_Taxi.Views;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Babat_Taxi.ViewModels
{
    public class MyMapViewModel : INotifyPropertyChanged
    {
        #region OnPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
        #endregion

        public IAccountManager AccountManager { get; set; }
        public Account _account { get; set; }
        public ApplicationIdCredentialsProvider Provider { get; set; }
        bool check = false;
        bool check1 = false;


        #region Commands
        public MyCommand OpenMenuCommand { get; set; }
        public MyCommand CloseMenuCommand { get; set; }

        public MyCommand SettingsCommand { get; set; }
        public MyCommand AccountCommand { get; set; }
        public MyCommand AboutCommand { get; set; }
        public MyCommand LogOutCommand { get; set; }
        public MyCommand GetListViewCommand { get; set; }



        #endregion

        #region Open Close Menu
        private Visibility _openMenuVisibility;
        public Visibility OpenMenuVisibility
        {
            get { return _openMenuVisibility; }
            set { _openMenuVisibility = value; OnPropertyChanged(); }
        }

        private Visibility _closeMenuVisibility;

        public Visibility CloseMenuVisibility
        {
            get { return _closeMenuVisibility; }
            set { _closeMenuVisibility = value; OnPropertyChanged(); }
        }

        #endregion

        #region ListViewPanel
        private ListView _listViewPanel;

        public ListView ListViewPanel
        {
            get { return _listViewPanel; }
            set { _listViewPanel = value; OnPropertyChanged(); }
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
        public Window MapNewWindow
        {
            get { return _mywindow; }
            set { _mywindow = value; OnPropertyChanged(); }
        }


        public UserControlMap UserControlMap { get; set; }
        #endregion
        public MyMapViewModel(IAccountManager accountManager, Account account)
        {
            AccountManager = accountManager;
            _account = account;
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["BingKey"]);
            OpenMenuVisibility = Visibility.Visible;
            CloseMenuVisibility = Visibility.Collapsed;
            UserControlMap = new UserControlMap();





            OpenMenuCommand = new MyCommand(OpenMenuCommandExecute, OpenMenuCommandCanExecute);
            CloseMenuCommand = new MyCommand(CloseMenuCommandExecute, CloseMenuCommandCanExecute);

            SettingsCommand = new MyCommand(SettingsCommandExecute);
            AccountCommand = new MyCommand(AccountCommandExecute);
            AboutCommand = new MyCommand(AboutCommandExecute);
            LogOutCommand = new MyCommand(LogOutCommandExecute);

            GetListViewCommand = new MyCommand(GetListViewComamndExecute, GetListViewComamndCanExecute);

        }



        private void OpenMenuCommandExecute(object obj)
        {
            OpenMenuVisibility = Visibility.Collapsed;
            CloseMenuVisibility = Visibility.Visible;

        }
        private bool OpenMenuCommandCanExecute(object obj)
        {
            if (!check1)
            {

                UserControlPanel = obj as Grid;
                UserControlPanel.Children.Clear();
                UserControlPanel.Children.Add(UserControlMap);
                check1 = true;
            }
            return true;
        }


        private void CloseMenuCommandExecute(object obj)
        {
            CloseMenuVisibility = Visibility.Collapsed;
            OpenMenuVisibility = Visibility.Visible;
        }
        private bool CloseMenuCommandCanExecute(object obj)
        {
            MapNewWindow = obj as Window;
            return true;
        }




        private void SettingsCommandExecute(object obj)
        {


        }
        private void AccountCommandExecute(object obj)
        {


        }
        private void AboutCommandExecute(object obj)
        {
            MessageBox.Show("Ulvi Bahir Production\nVersion - V1.0\nContact: ubashirov@outlook.com\nCopyright © 2019", "About", MessageBoxButton.OK, MessageBoxImage.Information);

        }
        private void LogOutCommandExecute(object obj)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            MapNewWindow.Close();

        }



        private void GetListViewComamndExecute(object obj)
        {

        }
        private bool GetListViewComamndCanExecute(object obj)
        {
            if (!check)
            {
                ListViewPanel = obj as ListView;
                ListViewPanel.SelectionChanged += ListViewPanel_SelectionChanged;
                check = true;
            }
            return true;
        }



        private void ListViewPanel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)ListViewPanel).SelectedItem).Name)
            {
                case "ItemMap":
                    UserControlPanel.Children.Clear();
                    UserControlPanel.Children.Add(UserControlMap);
                    break;
                case "ItemHistory":
                    UserControlPanel.Children.Clear();

                    break;
                case "ItemFeedback":
                    UserControlPanel.Children.Clear();

                    break;

                default:
                    break;
            }
        }


    }
}
