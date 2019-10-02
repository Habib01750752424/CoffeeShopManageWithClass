using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopICO.Repository
{
    public class Itemrepository
    {
        public DataTable LoadItems()
        {
            string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            string query = "SELECT ID, Name FROM Items";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public DataTable CountPrice(int id)
        {
            string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT Price FROM Items WHERE ID = " + id + "";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            sqlConnection.Close();
            return dataTable;
        }
    }
}
