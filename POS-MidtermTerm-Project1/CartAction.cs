using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_MidtermTerm_Project1
{
    public class CartAction : CartItem
    {     
        public static Product GetProductByProductId(int productID)
        {
            var productList = Warehouse.getInventory();
            var product = productList.First(x => x.ProductID == productID);
            return product;
        }
    }
}
