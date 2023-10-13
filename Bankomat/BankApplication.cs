using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankApplication
    {
        private List<BankAccount> accounts;

        public BankApplication(List<BankAccount> accounts)
        {
            this.accounts = accounts;
        }
        public void Run()
        {

        }
        public void DisplayAccounts()
        {
            Console.WriteLine("Bankaccounts are: ");
            /*foreach (BankAccount account in accounts)
            {
                Console.WriteLine($"Users: {account.Username }");
            }*/
            for (int i = 0; i < accounts.Count; i++)
            {
                string user = accounts[i].Username;
                Console.WriteLine(user);
            }
            
        }
        public BankAccount Login(string username, string password)
        {
            return accounts.FirstOrDefault(account => account.Username == username && account.Password == password);
        }
    }
}
