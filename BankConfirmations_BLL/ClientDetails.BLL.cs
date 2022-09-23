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
    public class ClientDetailsBLL
    {
        public List<ClientDetails> GetAll()
        {
            IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            return clientDetailsDal.GetAll();
        }
        public ClientDetails GetById(int id)
        {
            IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            return clientDetailsDal.GetById(id);
        }
        public void Insert(ClientDetails clientDetails)
        {
            IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            clientDetailsDal.Insert(clientDetails);
        }
        public void Update(ClientDetails clientDetails)
        {
            IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            clientDetailsDal.Update(clientDetails);
        }
        public void Delete(int id)
        {
            IClientDetails clientDetailsDal = ClientDetailsFactory.GetDalType(AppSettingsValue.ef);
            clientDetailsDal.Delete(id);
        }
    }
}
