using BankConfirmations_DAL;
using BankConfirmations_DTO;
using BankConfirmations_Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL_ADO
{
    public class Client_DAL_ADO : Connections, IClient
    {
        public List<Client> GetAll()
        {
            List<Client> listClient = new List<Client>();

            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetAllClient", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Client client = new();
                    client.Id = reader.GetInt32("id");
                    client.FirstName = reader["first_name"].ToString();
                    client.LastName = reader["last_name"].ToString();
                    client.IdNumber = reader["id_number"].ToString();
                    listClient.Add(client);
                }
            }
            con.Close();

            return listClient;
        }
        public List<Client> Search(string name)
        {
            throw new NotImplementedException();
        }

        public Client GetById(int id)
        {
            Client client = new();
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("GetByIdClient", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            con.Open();
            using SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    client.Id = reader.GetInt32("id");
                    client.FirstName = reader["first_name"].ToString();
                    client.LastName = reader["last_name"].ToString();
                    client.IdNumber = reader["id_number"].ToString();
                    client.ClientDetailsId = reader.GetInt32("clientDetails_id");
                }
            }
            con.Close();

            return client;
        }

        public void Insert(Client client)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("InsertClient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("first_name", client.FirstName);
            cmd.Parameters.AddWithValue("last_name", client.LastName);
            cmd.Parameters.AddWithValue("id_number", client.IdNumber);
            cmd.Parameters.AddWithValue("clientDetails_id", client.ClientDetailsId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Update(Client client)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("UpdateClient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", client.Id);
            cmd.Parameters.AddWithValue("first_name", client.FirstName);
            cmd.Parameters.AddWithValue("last_name", client.LastName);
            cmd.Parameters.AddWithValue("id_number", client.IdNumber);
            cmd.Parameters.AddWithValue("clientDetails_id", client.ClientDetailsId);
            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void Delete(int id)
        {
            using SqlConnection con = new(ConString);
            using SqlCommand cmd = new("DeleteClient", con);
            con.Open();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
