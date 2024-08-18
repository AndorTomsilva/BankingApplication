using BankingApp.Presentation.DataAccess;
using BankingApp.Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingApp.Presentation.Business
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        public User RegisterUser(string name, string password, string accountType)
        {
            User newUser = new User(name, password, accountType);
            _userRepository.AddUser(newUser);
            return newUser;
        }

        public User LoginUser(string accountNumber, string password)
        {
            return _userRepository.AuthenticateUser(accountNumber, password);
        }

        public void FreezeUserAccount(User user)
        {
            user.FreezeAccount();
        }
    }
}
