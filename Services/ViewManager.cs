using Babat_Taxi.Models;
using Babat_Taxi.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Services
{
    public class ViewManager
    {
        private static LoginPage loginPage;
        private static MainMap mainMap;
        private static MySplashScreen mySplashScreen;

        public ViewManager()
        {
            //loginPage = new LoginPage();
            //mainMap = new MainMap();
            //mySplashScreen = new MySplashScreen();

        }
        public static void ShowSplashScreen()
        {
            mySplashScreen = new MySplashScreen();
            mySplashScreen.Show();
        }
        public static void CloseSplashScreen()
        {
            mySplashScreen.Close();
        }


        public static void ShowLoginPage()
        {
            loginPage = new LoginPage();
            loginPage.Show();
        }
        public static void CloseLoginPage()
        {
            
            loginPage.Close();
        }

        public static void ShowMainMap(IAccountManager accountManager, Account account)
        {
            mainMap = new MainMap(accountManager, account);
            mainMap.Show();
        }

        public static void CloseMainMap()
        {
            mainMap.Close();
        }
    }
}
