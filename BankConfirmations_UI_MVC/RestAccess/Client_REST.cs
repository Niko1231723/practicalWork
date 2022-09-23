using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Newtonsoft.Json;

namespace BankConfirmations_UI_MVC.RestAccess
{
    public class Client_REST : Services_REST<Client>
    {
        public List<Client> GetAll()
        {
            return GetList("client");
        }
        public Client GetById(int id)
        {
            return GetT("client", id);
        }
        public Client Search(string search)
        {
            return SearchT("search/{search}", search);
        }
        public void Insert(Client client)
        {
            PostT(client, "client");
        }
        public void Update(Client client)
        {
            PutT(client, "client");
        }
        public void Delete(int id)
        {
            DeleteT("client", id);
        }
    }
}
