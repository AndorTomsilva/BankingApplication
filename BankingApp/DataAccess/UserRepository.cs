using BankingApp.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Presentation.DataAccess
{
    public class UserRepository
    {
        private static List<User> users = new List<User>();

        public void AddUser(User user)
        {
            users.Add(user);
        }

        public User GetUserByAccountNumber(string accountNumber)
        {
            return users.Find(user => user.AccountNumber == accountNumber);
        }

        public User AuthenticateUser(string accountNumber, string password)
        {
            return users.Find(user => user.AccountNumber == accountNumber && user.Password == password);
        }
    }
}
