using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankConfirmations_DTO;
using BankConfirmations_BLL;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using BankConfirmations_UI_MVC.RestAccess;
using BankConfirmations_Interfaces;
using System.Security.Principal;

namespace BankConfirmations_UI_MVC.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        public  IActionResult Index()
        {
            Account_REST accountRest = new();

            return View(accountRest.GetAll());
        }

        // GET: Accounts/Details/5
        public IActionResult Details(int id)
        {
            Account_REST accountRest = new();

            var account = accountRest.GetById(id);
            if (account == null) return NotFound();


            return View(account);
        }

        // GET: Accounts/Edit/5
        public IActionResult Edit(int id)
        {
            Account_REST accountRest = new();
            
            var account = accountRest.GetById(id);
            if (account == null) return NotFound();

            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Account account)
        {
            Account_REST accountRest = new();
            AccountBLL accountBll = new();

            //if (id != account.Id) return NotFound();

            if (ModelState.IsValid)
            {
                //accountRest.Update(account);
                accountBll.Update(account);
                return RedirectToAction(nameof(Index));
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public IActionResult Delete(int id)
        {
            Account_REST accountRest = new();

            var account = accountRest.GetById(id);
            if (account == null) return NotFound();

            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            Account_REST accountRest = new();

            accountRest.Delete(id);
            
            return RedirectToAction(nameof(Index));
        }

        // GET: Accounts/Create
        public IActionResult Create()
        {
            return View();
        }
        // GET: Accounts/Create


        public IActionResult CreateNewClient()
        {
            Account account = new();
            //AccountBLL accountBll = new();

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateNewClient(Account account)
        {
            Account_REST accountRest = new();
            //AccountBLL accountBll = new();


            if (ModelState.IsValid)
            {
                accountRest.Insert(account);
                //accountBll.Insert(account);

                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public IActionResult CreateWithClient()
        {
            Client_REST clientRest = new();

            return View(clientRest.GetAll());
        }
        public IActionResult ClientIndex()
        {
            return View();
        }

        public IActionResult Select(int id)
        {
            Account account = new();
            account.ClientId = id;

            return View(account);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Select(int id, Account accountModel)
        {
            Account_REST accountRest = new();
            ////AccountBLL accountBll = new();

            Account account = new();
            account.ClientId = id;
            account.Number = accountModel.Number;
            account.Balance = accountModel.Balance;
            account.OpenDate = accountModel.OpenDate;
            account.Type = accountModel.Type;


            if (ModelState.IsValid)
            {
                accountRest.Insert(account);
                //accountBll.Insert(account);

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult ClientListAccount()
        {
            //AccountModel accountModel = new();

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ClientListAccount(AccountModel accountModel)
        {
            Account_REST accountRest = new();

            if (ModelState.IsValid)
            {
                accountRest.Insert(accountModel.AccountM);

                return RedirectToAction("Index");
            }

            return View();
        }
        public IActionResult ClientSearch()
        {
            return View();
        }
        
        public IActionResult FilterSearch()
        {
            return View();
        }
        public IActionResult Partial(string search)
        {
            ClientBLL clientBll = new();
            var client = clientBll.Search(search);

            return PartialView("_Partial", client);
        }
    }
}
