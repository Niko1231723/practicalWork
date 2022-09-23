using BankConfirmations_DAL;
using BankConfirmations_DAL_EF;
using BankConfirmations_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_BLL
{
    internal class DepositFactory
    {
        private static string GetPath() 
        {
            string path = "appsettings.json";

            using (FileStream fileStream = File.Open(path,FileMode.Open,FileAccess.Read))
            {
                byte [] bt = new byte [1024];
                UTF8Encoding end = new UTF8Encoding(true);

                while (fileStream.Read(bt,0,bt.Length)>0)
                {
                    return end.GetString(bt);
                }
            }
            return null;
        }
        public static IDeposit GetDalType(AppSettingsValue value) 
        {
            dynamic json = JsonConvert.DeserializeObject(GetPath());

            if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), (string)json["TypeAdo"]))
            {
                return new Deposit_DAL_ADO();
            }
            if (value == (AppSettingsValue)Enum.Parse(typeof(AppSettingsValue), (string)json["TypeEf"]))
            {
                return new Deposit_DAL_EF();
            }

            // BankConfirmations_UI_WF

            //if (value == (AppSettingsValue) Enum.Parse(typeof(AppSettingsValue), ConfigurationManager.AppSettings.Get("typeado").ToLower()))
            //{
            //    return new Deposit_DAL_ADO();
            //}
            //if (value == (AppSettingsValue) Enum.Parse(typeof(AppSettingsValue), ConfigurationManager.AppSettings.Get("typeef").ToLower()))
            //{
            //    return new Deposit_DAL_EF();
            //}
            return null;
        }
    }
}
