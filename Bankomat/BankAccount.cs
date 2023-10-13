using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankAccount
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public int Balance { get; set; }

        public BankAccount(string username, string password, int balance)
        {
            Username = username;
            Password = password;
            Balance = balance;
        }
        public void Deposit(int amount)
        {
            Balance += amount;
        }
        public bool Withdraw(int amount)
        {
            if(amount > Balance) 
                return false;

            Balance -= amount;
            return true;
        }
        
    }
}
