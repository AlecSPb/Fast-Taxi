using Babat_Taxi.Models;
using Babat_Taxi.Services;
using Babat_Taxi.ViewModels;
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
    /// Interaction logic for MainMap.xaml
    /// </summary>
    public partial class MainMap : Window
    {
        public MainMap(IAccountManager accountManager, Account account)
        {
            InitializeComponent();
            this.DataContext = new MyMapViewModel(accountManager, account);
        }
    }
}
