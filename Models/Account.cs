using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Models
{
    public class Account : Entitiy
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool HaveCard { get; set; }
        public Card CardInfo { get; set; }

        public Account()
        {
            ID = Guid.NewGuid().ToString();
        }


    }
}
