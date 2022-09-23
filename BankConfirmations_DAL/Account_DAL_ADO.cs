using BankConfirmations_DAL;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace BankConfirmations_DAL_ADO
{
    public class Account_DAL_ADO : Connections, IAccount
    {
        public AccountModel AccountModel => throw new NotImplementedException();


        public List<Account> GetAll()
        {
            List<Account> listAccount = new List<Account>();

            using SqlConnection con = new((string)json["ConnectionStrings"]["SqlConnection"]);
            using SqlCommand cmd = new("GetAllAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Account account = new();
                    account.Id = reader.GetInt32("id");
                    account.Number = reader.GetString("number");
                    account.Balance = reader.GetDecimal("balance");
                    account.OpenDate = reader.GetDateTime("open_date");
                    account.Type = reader.GetString("type");
                    listAccount.Add(account);
                }
            }
            con.Close();

            return listAccount;
        }

        public Account GetById(int id)
        {
            Account account = new();
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetByIdAccount", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    account.Id = reader.GetInt32("id");
                    account.Number = reader.GetString("number");
                    account.Balance = reader.GetDecimal("balance");
                    account.OpenDate = reader.GetDateTime("open_date");
                    account.Type = reader.GetString("type");
                    account.ClientId = reader.GetInt32("client_id");
                }
            }
            con.Close();

            return account;
        }

        public void Insert(Account account)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("InsertAccount", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("number", account.Number);
            cmd.Parameters.AddWithValue("balance", account.Balance);
            cmd.Parameters.AddWithValue("open_date", account.OpenDate);
            cmd.Parameters.AddWithValue("type", account.Type);
            cmd.Parameters.AddWithValue("client_id", account.ClientId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Account account)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("UpdateAccount", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", account.Id);
            cmd.Parameters.AddWithValue("number", account.Number);
            cmd.Parameters.AddWithValue("balance", account.Balance);
            cmd.Parameters.AddWithValue("open_date", account.OpenDate);
            cmd.Parameters.AddWithValue("type", account.Type);
            cmd.Parameters.AddWithValue("client_id", account.ClientId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("DeleteAccount", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void GetXml() 
        {
            using (var file = new FileStream("xmlAdoDal",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Account_DAL_ADO));
                xml.Serialize(file,this);
            }
        }

        public List<Account> SearchByIdNumber(string idNumber)
        {
            throw new NotImplementedException();
        }

        public Account InsertAccount(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }

        public void InsertModel(AccountModel accountModel)
        {
            throw new NotImplementedException();
        }

        public AccountModel GetAccountModelById(int id)
        {
            throw new NotImplementedException();
        }

        public AccountModel GetClass()
        {
            throw new NotImplementedException();
        }
    }
}
