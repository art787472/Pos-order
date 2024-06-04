using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pos點餐.Models.POSModel;

namespace Pos點餐
{
    internal class Order
    {
        private static List<Item> items = new List<Item> ();
        public static void AddOrder(Strategy strategy, Item item)
        {
            bool hasItem = items.Any(x => x.name == item.name);
            Item product = items.FirstOrDefault(x => x.name == item.name);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            DiscountContext discountCtx = new DiscountContext(strategy);
            

            // 新增:
            if (!hasItem && item.number > 0)
            {
                items.Add(item);
                discountCtx.GenerateDiscount(items);
                return;
            }
            // 刪除:
            if(item.number == 0)
            {
                items.Remove(product);
                discountCtx.GenerateDiscount(items);
                return;
            }
            
            // 修改:
            product.number = item.number;
            product.sum = item.sum;
            discountCtx.GenerateDiscount(items);
        }

        public static void UpdateDiscount(Strategy strategy)
        {
            DiscountContext discountCtx = new DiscountContext(strategy);
            discountCtx.GenerateDiscount(items);
        }


    }
}
