using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using StockManagementProjectApp.DAL.Modals;
using StockManagementProjectApp.DAL.Modals.ViewModel;

namespace StockManagementProjectApp.DAL.Gateway
{
    public class ItemGateway
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public ItemGateway()
        {
            string connectionString =
                WebConfigurationManager.ConnectionStrings["StockManagementProjectDBConString"]
                    .ConnectionString;                                      //Loading connectionString from Web.config
            connection = new SqlConnection(connectionString);
        }
        public int SaveItem(Item item)
        {
            string query = "INSERT INTO Items(ItemName,CompanyId,CatagoryId) VALUES(@itemName,@companyId,@catagoryId)";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemName", item.ItemName);
            command.Parameters.AddWithValue("@companyId", item.CompanyId);
            command.Parameters.AddWithValue("@catagoryId", item.CatagoryId);
            connection.Open();
            int rowAffect = command.ExecuteNonQuery();
            connection.Close();

            return rowAffect;
        }

        public bool IsItemExist(Item item)
        {
            string query =
                "SELECT * FROM GetAllItemsView WHERE "
                    + "ItemName = @itemName AND CompanyId = @companyId AND CatagoryId = @catagoryId";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@itemName", item.ItemName);
            command.Parameters.AddWithValue("@companyId", item.CompanyId);
            command.Parameters.AddWithValue("@catagoryId", item.CatagoryId);

            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();
            bool isExist = reader.HasRows;
            connection.Close();

            return isExist;
        }

        public List<ItemViewModel> GetItemsByCompanyId(int companyId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CompanyId = @companyId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@companyId", companyId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemViewModel item = new ItemViewModel();
                item.ItemId = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLavel = Convert.ToInt32(reader["ReorderLavel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyId"]).ToString();
                item.CatagoryId = Convert.ToInt32(reader["CatagoryId"]);
                item.CatagoryName = (reader["CatagoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public List<ItemViewModel> GetItemsByCatagoryId(int catagoryId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CatagoryId = @catagoryId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@catagoryId", catagoryId);
            connection.Open();
            reader = command.ExecuteReader();

            List<ItemViewModel> itemList = new List<ItemViewModel>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemViewModel item = new ItemViewModel();
                item.ItemId = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLavel = Convert.ToInt32(reader["ReorderLavel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyId"]).ToString();
                item.CatagoryId = Convert.ToInt32(reader["CatagoryId"]);
                item.CatagoryName = (reader["CatagoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public List<ItemViewModel> GetItemsByCompanyIdAndCatagoryId(int companyId,int catagoryId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE CompanyId = @companyId AND CatagoryId = @catagoryId";
            command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@companyId", companyId);
            command.Parameters.AddWithValue("@catagoryId", catagoryId);
            connection.Open();
            reader = command.ExecuteReader();

            if (!reader.HasRows)
            {
                connection.Close();
                return null;
            }
            List<ItemViewModel> itemList = new List<ItemViewModel>();
            while (reader.Read())                                           //Reading database row by row
            {
                ItemViewModel item = new ItemViewModel();
                item.ItemId = Convert.ToInt32(reader["Id"]);
                item.ItemName = reader["ItemName"].ToString();
                item.ReorderLavel = Convert.ToInt32(reader["ReorderLavel"]);
                item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
                item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
                item.CompanyName = (reader["CompanyId"]).ToString();
                item.CatagoryId = Convert.ToInt32(reader["CatagoryId"]);
                item.CatagoryName = (reader["CatagoryName"]).ToString();

                itemList.Add(item);
            }
            connection.Close();

            return itemList;
        }

        public ItemViewModel GetItemByItemId(int itemId)
        {
            string query = "SELECT * FROM GetAllItemsView WHERE  Id = @itemId";
            command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@itemId", itemId);
            connection.Open();
            reader = command.ExecuteReader();
            reader.Read();

            ItemViewModel item = new ItemViewModel();
            item.ItemId = Convert.ToInt32(reader["Id"]);
            item.ItemName = reader["ItemName"].ToString();
            item.ReorderLavel = Convert.ToInt32(reader["ReorderLavel"]);
            item.AvailableQuantity = Convert.ToInt32(reader["AvailableQuantity"]);
            item.CompanyId = Convert.ToInt32(reader["CompanyId"]);
            item.CompanyName = (reader["CompanyId"]).ToString();
            item.CatagoryId = Convert.ToInt32(reader["CatagoryId"]);
            item.CatagoryName = (reader["CatagoryName"]).ToString();

            connection.Close();

            return item;
        }

        public int StockInItem(int totalQuantity, int itemId)
        {
            string query = "UPDATE Items SET AvailableQuantity = @totalQuantity WHERE Id = @id";
            command = new SqlCommand(query,connection);
            command.Parameters.AddWithValue("@totalQuantity", totalQuantity);
            command.Parameters.AddWithValue("@id", itemId);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }
    }
}