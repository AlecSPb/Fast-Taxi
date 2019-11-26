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
        private static TakeRideView TakeRideView;
        private static FeedbackView FeedbackView;
       
        public ViewManager()
        {
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


        public static void ShowTakeRideView()
        {
           
            TakeRideView = new TakeRideView();
            TakeRideView.Show();
        }
        public static void CloseTakeRideView()
        {
            TakeRideView.Close();
        }
        public static bool IsOpenTakeRideView()
        {
           return TakeRideView.IsEnabled;
        }

        public static void ShowFeedbackView()
        {
            FeedbackView = new FeedbackView();
            FeedbackView.ShowDialog();
        }
        public static void CloseFeedbackView()
        {
            FeedbackView.Close();
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
