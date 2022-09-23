using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;

namespace BankConfirmations_DAL
{
    public class ClientDetails_DAL_ADO : Connections, IClientDetails
    {
        public List<ClientDetails> GetAll()
        {
            List<ClientDetails> listClientDetails = new List<ClientDetails>();

            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetAllClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ClientDetails clientDetails = new();
                    clientDetails.Id = reader.GetInt32("id");
                    clientDetails.City = reader["city"].ToString();
                    clientDetails.Address = reader["address"].ToString();
                    clientDetails.Date = reader.GetDateTime("date");
                    listClientDetails.Add(clientDetails);
                }
            }
            con.Close();

            return listClientDetails;
        }

        public ClientDetails GetById(int id)
        {
            ClientDetails clientDetails = new();
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetByIdClientDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    clientDetails.City = reader["city"].ToString();
                    clientDetails.Address = reader["address"].ToString();
                    clientDetails.Date = reader.GetDateTime("date");
                }
            }
            con.Close();

            return clientDetails;
        }

        public void Insert(ClientDetails clientDetails)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("InsertClientDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("city", clientDetails.City);
            cmd.Parameters.AddWithValue("address", clientDetails.Address);
            cmd.Parameters.AddWithValue("date", clientDetails.Date);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(ClientDetails clientDetails)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("UpdateClientDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("city", clientDetails.City);
            cmd.Parameters.AddWithValue("address", clientDetails.Address);
            cmd.Parameters.AddWithValue("date", clientDetails.Date);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("DeleteClientDetails", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
