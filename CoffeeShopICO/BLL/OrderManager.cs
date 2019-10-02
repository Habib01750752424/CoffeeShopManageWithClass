using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopICO.Model;
using CoffeeShopICO.Repository;

namespace CoffeeShopICO.BLL
{
    public class OrderManager
    {
        OrderRepository _orderRepository = new OrderRepository();

        public bool Add(Order order, double totalPrice)
        {
            return _orderRepository.Add(order, totalPrice);
        }
        public DataTable Display()
        {
            return _orderRepository.Display();
        }

    }
}
