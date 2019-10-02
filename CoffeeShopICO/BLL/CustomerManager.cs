using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopICO.Model;
using CoffeeShopICO.Repository;
using System.Data;

namespace CoffeeShopICO.BLL
{
    public class CustomerManager
    {
        CustomerRepository _customerRepository = new CustomerRepository();
        public DataTable LoadCustomers()
        {
            return _customerRepository.LoadCustomers();
        }

        public bool IsExistCustomerName(int id)
        {
            return _customerRepository.IsExistCustomerName(id);
        }
    }
}
