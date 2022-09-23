using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL_EF
{
    public class Client_DAL_EF : BankConfirmationsContext, IClient
    {
        public List<Client> GetAll()
        {
            return Client.ToList();
        }
        public List<Client> Search(string search)
        {
            return Client.Where(i => i.FirstName == search || i.LastName == search || i.IdNumber == search).ToList();
        }
        public Client GetById(int id)
        {
            return Client.Include(i=>i.ClientDetails).First(i=>i.Id==id);
        }

        public void Insert(Client client)
        {
            Client.Add(client);
            SaveChanges();
        }

        public void Update(Client client)
        {
            Client.Update(client);
            SaveChanges();
        }
        public void Delete(int id)
        {
            var result = Client.Include(i => i.ClientDetails).Single(i => i.Id == id);

            Client.Remove(result);
            SaveChanges();
        }


    }
}
