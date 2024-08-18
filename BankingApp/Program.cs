using System;
using BankingApp.Presentation.Business;
using BankingApp.Presentation.Models;

namespace BankingApplication.Presentation
{
    public class Program
    {
        static void Main(string[] args)
        {
            UserService userService = new UserService();

            Console.WriteLine("Welcome to the Banking Application");
            Console.WriteLine("1. Register New Account");
            Console.WriteLine("2. Login to Existing Account");
            Console.WriteLine("3. Exit");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                RegisterUser(userService);
            }
            else if (choice == "2")
            {
                LoginUser(userService);
            }
            else
            {
                Environment.Exit(0);
            }
        }

        static void RegisterUser(UserService userService)
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter a password:");
            string password = Console.ReadLine();

            Console.WriteLine("Enter account type (Savings/Current):");
            string accountType = Console.ReadLine();

            User newUser = userService.RegisterUser(name, password, accountType);

            Console.WriteLine($"Account created successfully! Your Account Number is {newUser.AccountNumber}");
        }

        static void LoginUser(UserService userService)
        {
            Console.WriteLine("Enter your Account Number:");
            string accountNumber = Console.ReadLine();

            Console.WriteLine("Enter your Password:");
            string password = Console.ReadLine();

            User loggedInUser = userService.LoginUser(accountNumber, password);

            if (loggedInUser != null)
            {
                if (loggedInUser.IsFrozen)
                {
                    Console.WriteLine("Your account is frozen. Please contact the bank for further assistance.");
                }
                else
                {
                    Console.WriteLine($"Welcome back, {loggedInUser.Name}!");
                    UserSession(userService, loggedInUser);
                }
            }
            else
            {
                Console.WriteLine("Invalid account number or password. Please try again.");
            }
        }

        static void UserSession(UserService userService, User user)
        {
            while (true)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. View Balance");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Dial Freeze Code (#1234#)");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.WriteLine($"Your current balance is: {user.Balance}");
                }
                else if (choice == "2")
                {
                    if (user.IsFrozen)
                    {
                        Console.WriteLine("Cannot deposit. Your account is frozen.");
                    }
                    else
                    {
                        Console.WriteLine("Enter amount to deposit:");
                        double amount = double.Parse(Console.ReadLine());
                        user.Balance += amount;
                        Console.WriteLine($"Deposit successful! Your new balance is: {user.Balance}");
                    }
                }
                else if (choice == "3")
                {
                    if (user.IsFrozen)
                    {
                        Console.WriteLine("Cannot withdraw. Your account is frozen.");
                    }
                    else
                    {
                        Console.WriteLine("Enter amount to withdraw:");
                        double amount = double.Parse(Console.ReadLine());

                        if (amount <= user.Balance)
                        {
                            user.Balance -= amount;
                            Console.WriteLine($"Withdrawal successful! Your new balance is: {user.Balance}");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient funds.");
                        }
                    }
                }
                else if (choice == "4")
                {
                    Console.WriteLine("Enter freeze code:");
                    string code = Console.ReadLine();

                    if (code == "#1234#")
                    {
                        userService.FreezeUserAccount(user);
                    }
                    else
                    {
                        Console.WriteLine("Invalid code.");
                    }
                }
                else if (choice == "5")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice.");
                }
            }
        }
    }
}
