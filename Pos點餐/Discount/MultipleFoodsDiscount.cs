using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pos點餐.Models.POSModel;

namespace Pos點餐.Discount
{
    internal class MultipleFoodsDiscount : ADiscount
    {


        public override List<Item> ComputeDiscount(Strategy strategy, List<Item> items)
        {
            Multiplediscount multiplediscount = strategy.multipleDiscount;
            string itemName = multiplediscount.item;
            int amount = multiplediscount.amount;
            int price = multiplediscount.discount.price;

            Item item = items.FirstOrDefault(x => x.name == itemName);
            if (item == null)
            {
                return items;
            }
            if (item.number < amount)
            {
                return items;
            }

            int discountPrice = price - item.price * amount;
            items.Add(new Item($"(折扣){itemName}", discountPrice, (item.number / amount), (item.number / amount) * discountPrice));
            return items;
        }
    }
}
