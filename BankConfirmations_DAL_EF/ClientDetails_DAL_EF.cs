using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL_EF
{
    public class ClientDetails_DAL_EF : BankConfirmationsContext, IClientDetails
    {
        public List<ClientDetails> GetAll()
        {
            return ClientDetails.ToList();
        }

        public ClientDetails GetById(int id)
        {
            return ClientDetails.First(x=>x.Id==id);
        }

        void IClientDetails.Insert(ClientDetails clientDetails)
        {
            ClientDetails.Add(clientDetails);
            SaveChanges();
        }

        public void Update(ClientDetails clientDetails)
        {
            ClientDetails.Update(clientDetails);
            SaveChanges();
        }
        public void Delete(int id)
        {
            var result = ClientDetails.Find(id);
            ClientDetails.Remove(result);
            SaveChanges();
        }
    }
}
