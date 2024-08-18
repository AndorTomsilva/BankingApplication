using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Presentation.Models
{
    public class User
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }
        public string AccountType { get; set; }
        public bool IsFrozen { get; set; }

        public User(string name, string password, string accountType)
        {
            Name = name;
            Password = password;
            AccountType = accountType;
            Balance = 0.0;
            AccountNumber = GenerateAccountNumber();
            IsFrozen = false;
        }

        private string GenerateAccountNumber()
        {
            Random rand = new Random();
            return rand.Next(10000000, 99999999).ToString();
        }

        public void FreezeAccount()
        {
            IsFrozen = true;
        }

        public void UnfreezeAccount()
        {
            IsFrozen = false;
        }
    }
}
