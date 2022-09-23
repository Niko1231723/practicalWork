using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;

namespace BankConfirmations_UI_MVC.RestAccess
{
    public class Account_REST : Services_REST<Account>
    {
        public List<Account> GetAll()
        {
            return GetList("account");
        }

        public Account GetById(int id) 
        {
            return GetT("account",id);

        }
        public void Insert(Account account)
        {
            PostT(account, "account");
        }
        public void Update(Account account)
        {
            PutT(account, "account");
        }
        public void Delete(int id)
        {
            DeleteT("account", id);
        }
    }
}
