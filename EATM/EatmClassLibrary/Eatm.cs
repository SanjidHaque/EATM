using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EatmClassLibrary
{
    public class Eatm
    {
        public bool TermsOfTransaction(List<Transaction> transactions)
        {
            if (transactions.Count < 3|| transactions == null)
                return true;
            return false;
        }

        public bool UnsufficientBalance(Account account, int amount)
        {
            if (account.Balance >= amount)
            {
                return true;
            }
            return false;
        }

        public int SaveTransaction(Account account, int amount)
        {
            account.Balance -= amount;
            return account.Balance;
        }

    }
}
