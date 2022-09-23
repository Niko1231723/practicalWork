using BankConfirmations_DAL;
using BankConfirmations_DAL_ADO;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System.Data;

namespace BankConfirmations_BLL
{
    public class ClientBLL
    {
        public List<Client> GetAll()
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            return clientDal.GetAll();
        }
        public List<Client> Search(string search)
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            return clientDal.Search(search);
        }
        public Client GetById(int id)
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            return clientDal.GetById(id);
        }
        public void Insert(Client client)
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);

            clientDal.Insert(client);
            //clientDetailsDal.Insert(client.ClientDetails);
        }
        public void Update(Client client)
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetails = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);

            clientDal.Update(client);
            //clientDetails.Update(client.ClientDetails);
        }
        public void Delete(int id)
        {
            IClient clientDal = ClientFactory.GetDalType(AppSettingsValue.ef);
            //IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            clientDal.Delete(id);
            //clientDetailsDal.Delete(id);
        }
    }
}