using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐.Discount
{
    internal class SetDishPercentageDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(POSModel.Strategy strategy, List<Item> items)
        {
            string item1 = strategy.setItems.item1;
            string item2 = strategy.setItems.item2;
            float discountPercentage = strategy.multipleDiscount.discount.percentage;

            Item dish1 = items.FirstOrDefault(x => x.name == item1);
            Item dish2 = items.FirstOrDefault(x => x.name == item2);

            if(dish1 == null || dish2 == null)
            {
                return items;
            }

            int discountPrice = (int)(-(dish1.price + dish2.price) * discountPercentage);
            int number = dish1.number > dish2.number ? dish2.number : dish1.number;

            items.Add(new Item($"(折扣){strategy.name}", discountPrice, number, discountPrice * number));
            return items;
        }
    }
}
