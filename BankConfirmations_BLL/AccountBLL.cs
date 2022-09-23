using BankConfirmations_DAL;
using BankConfirmations_DAL_ADO;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_BLL 
{
    public class AccountBLL
{
        public List<Account> GetAll()
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            return accountDal.GetAll();
        }
        public AccountModel GetAccountModelById(int id)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            return accountDal.GetAccountModelById(id);
        }
        public void InsertModel(AccountModel accountModel)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            accountDal.InsertModel(accountModel);
        }
        public Account InsertAccount(AccountModel accountModel)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            return accountDal.InsertAccount(accountModel);
        }
        public Account GetById(int id)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            return accountDal.GetById(id);
        }
        public void Insert(Account account)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            //IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);

            accountDal.Insert(account);
            //clientDal.Insert(account.Client);
            //clientDetailsDal.Insert(account.Client.ClientDetails);
        }
        public void Update(Account account)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            //IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);

            accountDal.Update(account);
            //clientDal.Update(account.Client);
            //clientDetailsDal.Update(account.Client.ClientDetails);
        }
        public void Delete(int id)
        {
            IAccount accountDal = AccountFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            //IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);

            accountDal.Delete(id);
            //clientDetailsDal.Delete(id);
            //clientDal.Delete(id);
        }
    }
}
