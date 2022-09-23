using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BankConfirmations_DTO;
using Newtonsoft.Json;

namespace BankConfirmations_UI_MVC.Controllers
{
    public class DepositsController : Controller
    {

        // GET: Deposits
        public  IActionResult Index()
        {
            List<Deposit>? depositList = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync("https://localhost:7049/api/deposit").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                depositList = JsonConvert.DeserializeObject<List<Deposit>>(data);
                return View(depositList);
            }
        }

        // GET: Deposits/Details/5
        public IActionResult Details(int id)
        {
            Deposit? deposit = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/deposit/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                deposit = JsonConvert.DeserializeObject<Deposit>(data);
                if (deposit == null) return NotFound();
                return View(deposit);
            }
        }

        // GET: Deposits/Create
        public IActionResult Create()
        {
            Deposit deposit = new();
            return View(deposit);
        }

        // POST: Deposits/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  IActionResult Create(Deposit deposit)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new())
                {
                    HttpResponseMessage message = client.PostAsJsonAsync("https://localhost:7049/api/deposit",deposit).Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(deposit);
        }

        // GET: Deposits/Edit/5
        public IActionResult Edit(int id)
        {
            Deposit? deposit = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/deposit/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                deposit = JsonConvert.DeserializeObject<Deposit>(data);
                if (deposit == null) return NotFound();
                return View(deposit);
            }
        }

        // POST: Deposits/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Deposit deposit)
        {
            if (id != deposit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (HttpClient client = new())
                {
                    HttpResponseMessage message = client.PutAsJsonAsync($"https://localhost:7049/api/deposit/{id}", deposit).Result;
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(deposit);
        }

        // GET: Deposits/Delete/5
        public  IActionResult Delete(int id)
        {
            Deposit? deposit = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/deposit/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                deposit = JsonConvert.DeserializeObject<Deposit>(data);
                if (deposit == null) return NotFound();
                return View(deposit);
            }
        }

        // POST: Deposits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.DeleteAsync($"https://localhost:7049/api/deposit/{id}").Result;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
