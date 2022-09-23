using BankConfirmations_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankConfirmations_Interfaces
{
    public interface IAccount
    {
        List<Account> GetAll();
        Account GetById(int id);
        void Insert(Account account);
        void InsertModel(AccountModel accountModel);
        void Update(Account account);
        void Delete(int id);
        List<Account> SearchByIdNumber(string IdNumber);
        AccountModel GetAccountModelById(int id);
        Account InsertAccount(AccountModel accountModel);
    }
}
