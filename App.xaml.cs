using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Babat_Taxi.Services;
using Babat_Taxi.ViewModels;
using Babat_Taxi.Views;

namespace Babat_Taxi
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {

            IoC.Reference
                .Register<AccountManager, IAccountManager>()
                .Register<DataFromServer,IDataFromServer>()
                .Register<LoginPageViewModel>()
                .Register<DataFromServer>()
                .Build();

            ViewManager viewManager = new ViewManager();
            ViewManager.ShowSplashScreen();

            //ViewManager.CloseSplashScreen();
            //this.MainWindow = new MySplashScreen();
            //this.MainWindow.Show();
        }

    }
}
