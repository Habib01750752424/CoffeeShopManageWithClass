using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopICO.Model;

namespace CoffeeShopICO.Repository
{
    public class CustomerRepository
    {
        string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";

        public DataTable LoadCustomers()
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT Id, Name FROM Customers";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }

        public bool IsExistCustomerName(int id)
        {
            bool isExist = false;
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT CustomerId FROM Orders WHERE CustomerId = '" + id + "'";
            SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();
            int isFill = sqlDataAdapter.Fill(dataTable);

            if (isFill > 0)
            {
                isExist = true;
            }

            return isExist;
        }
    }
}
