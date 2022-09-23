using BankConfirmations_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_Interfaces
{
    public interface IDeposit
    {
        List<Deposit> GetAll();
        Deposit GetById(int id);
        void Insert(Deposit account);
        void Update(Deposit account);
        void Delete(int id);
    }
}
