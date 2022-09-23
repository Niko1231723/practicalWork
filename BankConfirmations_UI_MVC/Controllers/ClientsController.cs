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
using BankConfirmations_UI_MVC.RestAccess;

namespace BankConfirmations_UI_MVC.Controllers
{
    public class ClientsController : Controller
    {
        // GET: Clients
        public  IActionResult Index()
        {
            Client_REST clientRest = new();
            return View(clientRest.GetAll());
        }

        // GET: Clients/Details/5
        public  IActionResult Details(int id)
        {
            Client_REST clientRest = new();
            return View(clientRest.GetById(id));
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            Client client = new();
            return View(client);
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Client client)
        {
            if (ModelState.IsValid)
            {
                Client_REST clientRest = new();
                clientRest.Insert(client);
                return RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Edit/5
        public  IActionResult Edit(int id)
        {
            Client_REST clientRest = new();
            var result = clientRest.GetById(id);
            if (result == null) return NotFound();
            return View(result);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Edit(int id, Client client)
        {
            if (id != client.Id) return NotFound();

            if (ModelState.IsValid)
            {
                Client_REST clientRest = new();
                clientRest.Update(client);
                return  RedirectToAction(nameof(Index));
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public IActionResult Delete(int id)
        {
            Client_REST clientRest = new();
            var result = clientRest.GetById(id);
            if (result==null) return NotFound();
            return View(result);
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Client_REST clientRest = new();
            clientRest.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
