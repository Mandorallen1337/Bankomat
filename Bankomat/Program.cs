using System.ComponentModel;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Collections.Generic;

namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.Title = "My ATM";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("-----------ATM------------\n");
            List<BankAccount> accounts = new List<BankAccount>
            {
                new BankAccount("user1", "1357", 1000),
                new BankAccount("user2", "2532", 5000),
                new BankAccount("user3", "6432", 10000)
            };

            BankApplication bankapp = new BankApplication(accounts);

            bankapp.DisplayAccounts();

            bool loggedIn = false;
            BankAccount selectedAccount = null;
            while (!loggedIn)
            {

                Console.Write("What account do you want to log in to? ");
                string selectedUsername = Console.ReadLine();

                Console.Write("Submit password: ");
                string password = Console.ReadLine();

                selectedAccount = bankapp.Login(selectedUsername, password);

                if (selectedAccount != null)
                {
                    Console.WriteLine("Logged in user is: " + selectedUsername);
                    loggedIn = true;
                }
                else
                {
                    Console.WriteLine("Invalid username or password. Try again.");
                }
            }

            bool exitMenu = false;

            while (!exitMenu)
            {

                Console.WriteLine("\n1. Check balance:");
                Console.WriteLine("2. Add funds: ");
                Console.WriteLine("3. Withdraw money: ");
                Console.WriteLine("4. Exit: ");
                Console.Write("Choose what to do: ");
                String choice = Console.ReadLine();



                switch (choice)
                {
                    case "1":
                        Console.WriteLine("Your balance is: " + selectedAccount.Balance);
                        break;

                    case "2":
                        try
                        {
                            Console.Write("How much money do you want to add? ");
                            int depositAmount = Convert.ToInt32(Console.ReadLine());
                            selectedAccount.Deposit(depositAmount);
                            Console.Write("\nDeposit done. Your new balance is:  " + selectedAccount.Balance);
                        }
                        catch
                        {
                            Console.WriteLine("Please use numbers only:");
                        }
                        break;


                    case "3":
                        try
                        {
                            Console.Write("How much do you want to withdraw: ");
                            int withdrawalAmount = Convert.ToInt32(Console.ReadLine());

                            bool withdrawlSuccess = selectedAccount.Withdraw(withdrawalAmount);
                            if (withdrawlSuccess)
                            {

                                Console.WriteLine("Transaction done. Your new balance is: " + selectedAccount.Balance);
                            }
                            else
                            {
                                Console.WriteLine("Insufficient funds.");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Please use numbers only: ");
                        }
                        break;

                    case "4":
                        exitMenu = true;
                        Console.WriteLine("Have a nice day!");
                        break;

                    default:
                        Console.WriteLine("Please select 1-4! ");
                        break;


                }

            }






        }

    }
}      
       


