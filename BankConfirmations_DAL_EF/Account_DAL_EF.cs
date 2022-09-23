using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankConfirmations_DAL_EF
{
    public class Account_DAL_EF : BankConfirmationsContext, IAccount
    {
        public  List<Account> GetAll() => Account.ToList();
        public Account GetById(int id) => Account.Include(i => i.Client).Include(i => i.Client.ClientDetails).First(i => i.Id == id);
        public void Insert(Account account)
        {
            //ClientDetails.Add(account.Client.ClientDetails);
            //SaveChanges();

            //account.Client.ClientDetails = ClientDetails.OrderBy(i=>i.Id).Last();
            //account.Client.ClientDetailsId = account.Client.ClientDetails.Id;

            //Client.Add(account.Client);
            //SaveChanges();

            //account.Client = Client.OrderBy(i=>i.Id).Last();
            //account.ClientId = account.Client.Id;

            Account.Add(account);
            SaveChanges();
        }
        public void Update(Account account)
        {
            Account.Update(account);
            SaveChanges();

            //Client.Update(account.Client);
            //SaveChanges();

            //ClientDetails.Update(account.Client.ClientDetails);
            //SaveChanges();
        }
        public void Delete(int id)
        {
            var result = Account.Include(i=>i.Client).Include(i=>i.Client.ClientDetails).First(i=>i.Id==id);

            Account.Remove(result);
            SaveChanges();

            //Client.Remove(result.Client);
            //SaveChanges();

            //ClientDetails.Remove(result.Client.ClientDetails);
            //SaveChanges();
        }

        public List<Account> SearchByIdNumber(string IdNumber)
        {
            throw new NotImplementedException();
        }

        public Account InsertAccount(AccountModel accountModel)
        {
            Account result = new Account
            {
                Number = accountModel.AccountM.Number,
                Balance = accountModel.AccountM.Balance,
                OpenDate = accountModel.AccountM.OpenDate,
                Type = accountModel.AccountM.Type,
                //ClientId = accountModel.ClientM.Id
            };
            return result;
        }

        public void InsertModel(AccountModel accountModel)
        {
            Account result = new Account
            {
                Number = accountModel.AccountM.Number,
                Balance = accountModel.AccountM.Balance,
                OpenDate = accountModel.AccountM.OpenDate,
                Type = accountModel.AccountM.Type,
                //ClientId = accountModel.ClientM.Id,
            };
            Account.Add(result);
            SaveChanges();
        }

        public AccountModel GetAccountModelById(int id)
        {
            var model = new AccountModel
            {
                //ClientM = Client.First(i=>i.Id==id),
                AccountM = new Account()
            };
            return model;
        }
    }
}
