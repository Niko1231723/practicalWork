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
    public class ClientDetailsController : Controller
    {
        // GET: ClientDetails
        public IActionResult Index()
        {
            List<ClientDetails>? clientDetails = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync("https://localhost:7049/api/clientdetails").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                clientDetails = JsonConvert.DeserializeObject<List<ClientDetails>>(data);
                return View(clientDetails);
            }
        }

        // GET: ClientDetails/Details/5
        public  IActionResult Details(int id)
        {
            ClientDetails? clientDetails = new();

            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/clientdetails/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                clientDetails = JsonConvert.DeserializeObject<ClientDetails>(data);
                if (clientDetails == null)
                {
                    return NotFound();
                }
                return View(clientDetails);
            }
        }

        // GET: ClientDetails/Create
        public IActionResult Create()
        {
            ClientDetails clientDetails = new();
            return View(clientDetails);
        }

        // POST: ClientDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create (ClientDetails clientDetails)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient httpClient = new())
                {
                    HttpResponseMessage message = httpClient.PostAsJsonAsync("https://localhost:7049/api/clientdetails",clientDetails).Result;
                    if (message.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            return View(clientDetails);
        }

        // GET: ClientDetails/Edit/5
        public  IActionResult Edit(int id)
        {
            ClientDetails? clientDetails = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/clientdetails/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                clientDetails = JsonConvert.DeserializeObject<ClientDetails>(data);
                if (clientDetails == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: ClientDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClientDetails clientDetails)
        {
            if (id != clientDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using (HttpClient httpClient = new())
                {
                    HttpResponseMessage message = httpClient.PutAsJsonAsync($"https://localhost:7049/api/clientdetails/{id}",clientDetails).Result;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View();
        }

        // GET: ClientDetails/Delete/5
        public IActionResult Delete(int id)
        {
            ClientDetails? clientDetails = new();
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.GetAsync($"https://localhost:7049/api/clientdetails/{id}").Result;
                string data = message.Content.ReadAsStringAsync().Result;
                clientDetails = JsonConvert.DeserializeObject<ClientDetails>(data);
                if (clientDetails == null)
                {
                    return NotFound();
                }
                return View(clientDetails);
            }
        }

        // POST: ClientDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public  IActionResult DeleteConfirmed(int id)
        {
            using (HttpClient client = new())
            {
                HttpResponseMessage message = client.DeleteAsync($"https://localhost:7049/api/clientdetails/{id}").Result;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
