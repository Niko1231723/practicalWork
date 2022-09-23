using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL_EF
{
    public class Deposit_DAL_EF : BankConfirmationsContext, IDeposit
    {
        public List<Deposit> GetAll()
        {
            return Deposit.ToList();
        }

        public Deposit GetById(int id)
        {
            return Deposit.First(x=>x.Id==id);
        }

        public void Insert(Deposit account)
        {
            Deposit.Add(account);
            SaveChanges();
        }

        public void Update(Deposit account)
        {
            Deposit.Update(account);
            SaveChanges();
        }
        public void Delete(int id)
        {
            var result = Deposit.Find(id);
            Deposit.Remove(result);
            SaveChanges();
        }
    }
}
