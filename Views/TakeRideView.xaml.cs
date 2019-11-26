using Babat_Taxi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Babat_Taxi.Views
{
    /// <summary>
    /// Interaction logic for TakeRideView.xaml
    /// </summary>
    public partial class TakeRideView : Window
    {
      

        private DispatcherTimer timer;
        public TakeRideView()
        {
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 200);
            timer.Tick += Timer_Tick;
           // timer.Start();
            InitializeComponent();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {



            //if (Progbar.Value == 100)
            //{
            //    timer.Stop();
            //    ViewManager.CloseTakeRideView();
            //    ViewManager.ShowFeedbackView();


            //}
            //else
            //    Progbar.Value += 1;

        }
    }
}
