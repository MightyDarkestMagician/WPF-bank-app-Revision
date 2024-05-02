using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbankHW12.Models.Client.BankAccounts
{
    public abstract class BankAccount
    {
        //
        protected int       accountId;
        protected string    accountName;
        protected string    color;
        protected int       balance = 0;

        //
        public int      AccountId   { get => accountId; }
        public string   AccountName { get => accountName; }
        public string   Color       { get => color; }
        public int      Balance     { get => balance; }

        public void Deposit(int amount)
        {
            balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount > balance)
                throw new InvalidOperationException("Insufficient funds");
            balance -= amount;
        }
    }
}