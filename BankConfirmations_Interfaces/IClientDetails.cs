using BankConfirmations_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_Interfaces
{
    public interface IClientDetails
    {
        List<ClientDetails> GetAll();
        ClientDetails GetById(int id);
        void Insert(ClientDetails account);
        void Update(ClientDetails account);
        void Delete(int id);
    }
}
