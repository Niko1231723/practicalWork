using BankConfirmations_DAL;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_BLL
{
    public class DepositBLL
    {
        public List<Deposit> GetAll()
        {
            IDeposit depositDal = DepositFactory.GetDalType(AppSettingsValue.ado);
            return depositDal.GetAll();
        }
        public Deposit GetById(int id)
        {
            IDeposit depositDal = DepositFactory.GetDalType(AppSettingsValue.ef);
            return depositDal.GetById(id);
        }
        public void Insert(Deposit deposit)
        {
            IDeposit depositDal = DepositFactory.GetDalType(AppSettingsValue.ef);
            depositDal.Insert(deposit);
        }
        public void Update(Deposit deposit)
        {
            IDeposit depositDal = DepositFactory.GetDalType(AppSettingsValue.ef);
            depositDal.Update(deposit);
        }
        public void Delete(int id)
        {
            IDeposit depositDal = DepositFactory.GetDalType(AppSettingsValue.ef);
            depositDal.Delete(id);
        }
    }
}
