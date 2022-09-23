using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL
{
    public class Deposit_DAL_ADO : Connections, IDeposit
    {
        public List<Deposit> GetAll()
        {
            List<Deposit> listDeposit = new List<Deposit>();

            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetAllDeposit", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Deposit deposit = new();
                    deposit.Id = reader.GetInt32("id");
                    deposit.Number = reader["number"].ToString();
                    deposit.Balance = reader.GetDecimal("balance");
                    deposit.Interest = reader.GetDecimal("interest");
                    listDeposit.Add(deposit);
                }
            }
            con.Close();
        
            return listDeposit;
        }

        public Deposit GetById(int id)
        {
            Deposit deposit = new();
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetByIdDeposit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    deposit.Id = reader.GetInt32("id");
                    deposit.Number = reader["number"].ToString();
                    deposit.Balance = reader.GetDecimal("balance");
                    deposit.Interest = reader.GetDecimal("interest");
                }
            }
            con.Close();

            return deposit;
        }

        public void Insert(Deposit deposit)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("InsertDeposit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("number", deposit.Number);
            cmd.Parameters.AddWithValue("balance", deposit.Balance);
            cmd.Parameters.AddWithValue("interest", deposit.Interest);
            cmd.Parameters.AddWithValue("client_id", deposit.ClientId);
            cmd.Parameters.AddWithValue("details_id", deposit.ProductDetailsId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Deposit deposit)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("UpdateDeposit", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("number", deposit.Number);
            cmd.Parameters.AddWithValue("balance", deposit.Balance);
            cmd.Parameters.AddWithValue("interest", deposit.Interest);
            cmd.Parameters.AddWithValue("client_id", deposit.ClientId);
            cmd.Parameters.AddWithValue("details_id", deposit.ProductDetailsId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("DeleteDeposit", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
