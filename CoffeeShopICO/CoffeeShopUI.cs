using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using CoffeeShopICO.Model;
using CoffeeShopICO.BLL;

namespace CoffeeShopICO
{
    public partial class CoffeeShopUI : Form
    {
        CustomerManager _customerManager = new CustomerManager();
        ItemManager _itemManager = new ItemManager();
        OrderManager _orderManager = new OrderManager();

        Customer customer = new Customer();
        Item item = new Item();
        Order order = new Order();

        public CoffeeShopUI()
        {
            InitializeComponent();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string cName = customerComboBox.Text;
            string iName = itemComboBox.Text;
            string qty = quantityTextBox.Text;

            if (cName == "" || iName == "" || qty == "")
            {
                MessageBox.Show("Plesae,, Field must not be empty");
                return;
            }
           

            order.CustomerId = Convert.ToInt32(customerComboBox.SelectedValue);
            order.ItemId = Convert.ToInt32(itemComboBox.SelectedValue);
            order.Quantity = Convert.ToInt32(quantityTextBox.Text);
            //order.TotalPrice = Convert.ToDouble(totalPriceTextBox.Text);

            if (_customerManager.IsExistCustomerName(order.CustomerId))
            {
                MessageBox.Show("Customer is Allready Exist..!");
                return;
            }

            showDataGridView.DataSource = _itemManager.CountPrice(order.ItemId);
            string price = showDataGridView.CurrentRow.Cells[0].Value.ToString();
            showDataGridView.DataSource = "";
            double totalPrice = Convert.ToDouble(price) * order.Quantity;
            totalPriceTextBox.Text = totalPrice.ToString();



            if (_orderManager.Add(order, totalPrice))
            {
                showDataGridView.DataSource = _orderManager.Display();
                MessageBox.Show("Saved");
                return;
            }
            else
            {
                MessageBox.Show("Not Save");
            }
        }


        private void CoffeeShopUI_Load(object sender, EventArgs e)
        {
            customerComboBox.DataSource = _customerManager.LoadCustomers();
            itemComboBox.DataSource = _itemManager.LoadItems();
        }
    }
}
