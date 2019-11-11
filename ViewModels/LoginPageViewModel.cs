using Babat_Taxi.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Babat_Taxi.ViewModels
{
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string property = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        MyCommand LoginCommand;



        public LoginPageViewModel()
        {
            LoginCommand = new MyCommand(LoginCommandExecute);
        }

     public void LoginCommandExecute(object obj)
        {
           MessageBox.Show("Test");
        }
        
    }
}
