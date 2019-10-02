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
    public class OrderRepository
    {
        string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";

        public bool Add(Order order,double totalPrice)
        {
            bool isAdd = false;
            try
            {
                SqlConnection sqlConnection = new SqlConnection(connectionString);
                string commandString = "INSERT INTO Orders(CustomerId, ItemId, Quantity, TotalPrice) VALUES("+order.CustomerId+","+order.ItemId+","+order.Quantity+","+ totalPrice + ")";
                SqlCommand sqlCommand = new SqlCommand(commandString, sqlConnection);

                sqlConnection.Open();
                int isExecute = sqlCommand.ExecuteNonQuery();
                if (isExecute > 0)
                {
                    isAdd = true;
                }
                sqlConnection.Close();
            }
            catch (Exception exep)
            {
                //MessageBox.Show(exep.Message);
            }
            return isAdd;
        }

        public DataTable Display()
        {
            string connectionString = @"Server = HABIB; Database = CoffeeShop; Integrated Security = true";
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            string query = "SELECT o.Id,c.Name AS Customer,i.Name AS Item,Quantity,i.Price,TotalPrice FROM Orders AS o " +
                "INNER JOIN Customers AS c ON o.CustomerId = c.Id INNER JOIN Items AS i ON o.ItemId = i.ID";
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
