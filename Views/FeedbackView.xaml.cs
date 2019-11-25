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

namespace Babat_Taxi.Views
{
    /// <summary>
    /// Interaction logic for FeedbackView.xaml
    /// </summary>
    public partial class FeedbackView : Window
    {
        public FeedbackView()
        {
            InitializeComponent();
        }

       

        private void SendBtn_Click(object sender, RoutedEventArgs e)
        {
            ViewManager.CloseFeedbackView();
        }
    }
}
