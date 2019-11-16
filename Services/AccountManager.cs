using Babat_Taxi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Babat_Taxi.Services
{
    public class AccountManager : IAccountManager
    {
        public List<Account> Accounts { get; set; }
        public AccountManager()
        {
            Accounts = new List<Account>();
        }

        public void AddAccount(string username, string email, string password, bool havecard, Card card = null)
        {
            Account account = new Account()
            {
                Username = username,
                Password = password,
                Email = email,
                HaveCard = havecard,
                CardInfo = card,
            };
            Accounts.Add(account);
        }

        public bool HaveDublicateUsername(string username)
        {
            foreach (var item in Accounts)
            {
                if (item.Username == username)
                    return true;
            }
            return false;
        }

        public bool HaveDublicateEmail(string email)
        {
            foreach (var item in Accounts)
            {
                if (item.Email == email)
                    return true;
            }
            return false;
        }

        public bool HaveAccount(string email, string password)
        {
            foreach (var item in Accounts)
            {
                if (item.Email == email && item.Password == password)
                    return true;
            }
            return false;
        }

        public Account GetAccount(string email, string password)
        {
            foreach (var item in Accounts)
            {
                if (item.Email == email && item.Password == password)
                    return item;
            }
            return null ;
        }

    }
}
