using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BankConfirmations_DTO
{
    public class AccountModel
    {
        public IEnumerable<Client> ClientList { get; set; }
        public Account AccountM { get; set; }
        public Client ClientM { get; set; }
    }
}
