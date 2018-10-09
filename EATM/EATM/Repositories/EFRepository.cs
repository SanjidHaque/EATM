using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EATM.EatmViewModels;
using EATM.Models;
using EatmClassLibrary;

namespace EATM.Repositories
{
    public class EfRepository : IRepository
    {
        public ApplicationDbContext _context;

        public EfRepository()
        {
            _context = new ApplicationDbContext();
        }

        public Account CheckUserAccount(Account account)
        {
            var userAccount = _context.Accounts.FirstOrDefault(c => c.CardNumber == account.CardNumber && c.PinNumber == account.PinNumber);
            return userAccount;
        }

        public Account GetByCardNumber(int cardNumber)
        {
            var userAccount = _context.Accounts.FirstOrDefault(c => c.CardNumber == cardNumber);
            return userAccount;
        }

        public List<Transaction> TotalTransactions(int cardNumber)
        {
            var transaction = _context.Transactions.Where(c => c.CardNumber == cardNumber).ToList();
            return transaction;
        }

        public void SaveTransaction(int amount, int cardNumber, int balance)
        {
            var account = GetByCardNumber(cardNumber);
            account.Balance = balance;
            var transaction = new Transaction()
            {
                CardNumber = cardNumber,
                Amount = amount
            };
            _context.Transactions.Add(transaction);
            _context.SaveChanges();
        }

        public void NewAccount(NewAccountViewModel newAccount)
        {
            var account = new Account()
            {
                CardNumber = newAccount.CardNumber,
                PinNumber = newAccount.PinNumber,
                Balance = newAccount.Balance
            };
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }
    }
}