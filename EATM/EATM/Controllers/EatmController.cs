using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EATM.EatmViewModels;
using EATM.Repositories;
using EatmClassLibrary;

namespace EATM.Controllers
{
    public class EatmController : Controller
    {
        private  EfRepository _repository;
        private Eatm _eatm;
        public EatmController()
        {
            _repository = new EfRepository();
            _eatm = new Eatm();
        }
        // GET: Eatm
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View("RegistrationForm");
        }

        [HttpPost]
        public ActionResult RegistrationCompleted(NewAccountViewModel newAccount)
        {
            if (!ModelState.IsValid)
            {
                return View("RegistrationForm");
            }
            else
            {              
                _repository.NewAccount(newAccount);
                return View(newAccount.CardNumber);
            }         
        }

        public JsonResult IsAlreadySigned(int cardNumber)
        {
          
            if (_repository.GetByCardNumber(cardNumber) != null)
            {
                return Json("Sorry! Card number already exists", JsonRequestBehavior.AllowGet);
            }
            return Json(true, JsonRequestBehavior.AllowGet);
        }
        
        [HttpGet]
        public ActionResult LogIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Account userAccount)
        {         
            var account = _repository.CheckUserAccount(userAccount);
            if (account!=null)
            {
                return RedirectToAction("Options", new { cardNumber = userAccount.CardNumber });
            }
            return RedirectToAction("LogIn");
        }


        [Route("eatm/{cardNumber}/Options")]
        public ActionResult Options(int cardNumber)
        {
            return View(cardNumber);
        }


        [Route("eatm/{cardNumber}/CheckBalance")]
        public ActionResult CheckBalance(int cardNumber)
        {       
            var account = _repository.GetByCardNumber(cardNumber);
            return View(account.Balance);
        }

      
        [Route("eatm/{cardNumber}/GetAmount")]
        public ActionResult GetAmount(int cardNumber)
        {         
            var transaction = _repository.TotalTransactions(cardNumber);
            if (!_eatm.TermsOfTransaction(transaction))
            {
                return View("TermsOfTransaction");
            }
            return View(cardNumber);
        }

        [HttpPost]
        [Route("eatm/{cardNumber}/CashWithdraw")]
        public ActionResult CashWithdraw(int cardNumber, int amount)
        {        
            var account = _repository.GetByCardNumber(cardNumber);          
            if (!_eatm.UnsufficientBalance(account,amount))
            {
                return View("UnsufficientBalance",account.Balance);
            }
            _repository.SaveTransaction(amount, cardNumber,_eatm.SaveTransaction(account, amount));
            return View(account.Balance);
        }


        [Route("eatm/{cardNumber}/TransactionHistory")]
        public ActionResult TransactionHistory(int cardNumber)
        {          
            var transactionHistory = _repository.TotalTransactions(cardNumber);
            return View(transactionHistory);
        }


        public ActionResult Exit()
        {
            return RedirectToAction("LogIn");
        }


    }
}