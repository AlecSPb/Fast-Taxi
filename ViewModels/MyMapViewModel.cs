using Babat_Taxi;
using Babat_Taxi.Models;
using Babat_Taxi.Services;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
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



        public MyMapViewModel(IAccountManager accountManager, Account account)
        {
            AccountManager = accountManager;
            _account = account;
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["BingKey"]);
        }

        


    }
}
