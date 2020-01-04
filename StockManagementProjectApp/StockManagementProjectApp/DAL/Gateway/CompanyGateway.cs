using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class CompanyGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;

        public CompanyGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["StockManagementProjectDBConString"]
                    .ConnectionString;                                      //Loading connectionString from Web.config
            connection = new SqlConnection(connectionString);
        }

        public int SaveCompany(Company company)                                 //Mathod for saving Company
        {
            string query = "INSERT INTO Companies(CompanyName) VALUES(@companyName)";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@companyName", company.CompanyName);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsCompanyExist(string company)                              //Mathod for making Company unique
        {
            string query = "SELECT * FROM Companies WHERE CompanyName = @companyName";
            command = new SqlCommand(query,connection);

            command.Parameters.AddWithValue("@companyName", company);

            connection.Open();
            reader = command.ExecuteReader();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<Company> GetAllCompanies()                   //Mathod for Retriving all Catagories from database
        {
            string query = "SELECT * FROM Companies";
            command = new SqlCommand(query, connection);

            connection.Open();
            reader = command.ExecuteReader();

            List<Company> companyList = new List<Company>();
            while (reader.Read())                               //Reading database row by row
            {
                Company company = new Company();
                company.Id = Convert.ToInt32(reader["Id"]);
                company.CompanyName = reader["CompanyName"].ToString();
                companyList.Add(company);
            }
            connection.Close();

            return companyList;
        }
    }
}