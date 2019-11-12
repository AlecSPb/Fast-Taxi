using Babat_Taxi;
using Microsoft.Maps.MapControl.WPF;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Babat_Taxi.ViewModels
{
    public class MyMapViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }




        public ApplicationIdCredentialsProvider Provider { get; set; }

        

        public MyMapViewModel()
        {
            
            Provider = new ApplicationIdCredentialsProvider(ConfigurationManager.AppSettings["BingKey"]);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
           
        }


    }
}
