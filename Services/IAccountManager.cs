using System.Collections.Generic;
using Babat_Taxi.Models;

namespace Babat_Taxi.Services
{
    public interface IAccountManager
    {
        List<Account> Accounts { get; set; }
        void AddAccount(string username, string email, string password, bool havecard, Card card = null);
        bool HaveDublicateUsername(string username);
        bool HaveDublicateEmail(string email);
        bool HaveAccount(string email, string password);
        Account GetAccount(string email, string password);
    }
}