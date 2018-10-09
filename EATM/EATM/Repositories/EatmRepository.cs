using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using EATM.EatmViewModels;
using EatmClassLibrary;

namespace EATM.Repositories
{
    public interface IRepository
    {
        Account CheckUserAccount(Account account);
        Account GetByCardNumber(int cardNumber);
        List<Transaction> TotalTransactions(int cardNumber);
        void SaveTransaction(int amount, int cardNumber, int balance);
        void NewAccount(NewAccountViewModel newAccount);
    }
}
