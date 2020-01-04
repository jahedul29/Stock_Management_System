using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class CatagoryGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CatagoryGateway()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["StockManagementProjectDBConString"]
                .ConnectionString;                                      //Loading connectionString from Web.config
            connection = new SqlConnection(connectionString);
        }

        public int SaveCatagory(Catagory catagory)                                      //Mathod for saving Catagory
        {
            string query = "INSERT INTO Catagories(CatagoryName) VALUES(@catagoryName)";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@catagoryName", catagory.CatagoryName);    //Inserting value in a Hackprotected way
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCatagoryExist(string catagory)                        //Mathod for making Company unique
        {
            string query = "SELECT * FROM Catagories WHERE CatagoryName = @catagoryName";
            command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@catagoryName", catagory);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<Catagory> GetAllCatagories()                            //Mathod for Retriving all Catagories from database
        {
            string query = "SELECT * FROM Catagories";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();

            List<Catagory> catagoryList = new List<Catagory>();
            while (reader.Read())                                           //Reading database row by row
            {
                Catagory catagory = new Catagory();
                catagory.Id = Convert.ToInt32(reader["Id"]);
                catagory.CatagoryName = reader["CatagoryName"].ToString();
                catagoryList.Add(catagory);
            }
            connection.Close();

            return catagoryList;
        }

        public Catagory GetCatagoryById(int id)                     //Mathod for retriving a catagory using CatagoryId
        {
            string query = "SELECT * FROM Catagories WHERE Id = " + id;
            command = new SqlCommand(query,connection);
            
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            Catagory catagory = null;
            if (reader.HasRows)
            {
                catagory = new Catagory();
                catagory.Id = Convert.ToInt32(reader["Id"]);
                catagory.CatagoryName = reader["CatagoryName"].ToString();
                connection.Close();
            }

            return catagory;
        }

        public int  UpdateCatagoryById(Catagory catagory)               //Mathod for Updating a Catagory
        {
            string query = "UPDATE Catagories SET CatagoryName = @catagoryName WHERE Id = "+catagory.Id;
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@catagoryName", catagory.CatagoryName);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}