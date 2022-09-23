using BankConfirmations_DAL_ADO;
using BankConfirmations_DAL_EF;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Text;

namespace BankConfirmations_BLL
{
    internal class AccountFactory
    {
        private static string GetPath() 
        {
            string path = "appsettings.json";

            using (FileStream fileStream = File.Open(path,FileMode.Open,FileAccess.Read))
            {
                byte[] bt = new byte [1024]; 
                UTF8Encoding end = new (true);

                while (fileStream.Read(bt,0,bt.Length)>0)
                {
                    return end.GetString(bt);
                }
            }
            return null;
        }

        public static IAccount GetDalType(AppSettingsValue value)
        {
            dynamic json = JsonConvert.DeserializeObject(GetPath());

            if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), (string)json["TypeAdo"]))
            {
                return new Account_DAL_ADO();
            }
            if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), (string)json["TypeEf"]))
            {
                return new Account_DAL_EF();
            }

            // BankConfirmations_UI_WF

            //if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), ConfigurationManager.AppSettings.Get("typeado").ToLower()))
            //{
            //    return new Account_DAL_ADO();
            //}
            //if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), ConfigurationManager.AppSettings.Get("typeef").ToLower()))
            //{
            //    return new Account_DAL_EF();
            //}
            return null;
        }
    }
}