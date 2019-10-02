using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShopICO.Repository;

namespace CoffeeShopICO.BLL
{
    public class ItemManager
    {
        Itemrepository _itemrepository = new Itemrepository();
        public DataTable LoadItems()
        {
            return _itemrepository.LoadItems();
        }

        public DataTable CountPrice(int id)
        {
            return _itemrepository.CountPrice(id);
        }
    }
}
