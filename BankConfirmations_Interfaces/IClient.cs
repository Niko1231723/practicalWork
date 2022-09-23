using BankConfirmations_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_Interfaces
{
    public interface IClient
    {
        List<Client> GetAll();
        Client GetById(int id);
        List<Client> Search(string name);
        void Insert(Client client);
        void Update(Client client);
        void Delete(int id);
    }
}
