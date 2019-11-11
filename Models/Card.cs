using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Models
{
    public class Card
    {
        public string CardNumber { get; set; }
        public string CCV { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
