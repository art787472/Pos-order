using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐.Discount
{
    internal class PriceDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(POSModel.Strategy strategy, List<Item> items)
        {
            

            float percentage = strategy.multipleDiscount.discount.percentage;
            string item = strategy.multipleDiscount.item;
            int amount = strategy.multipleDiscount.amount;

            if(item == "")
            {
                if (items.Count == 0) return items;
                int sum = items.Sum(x => x.sum);
                int discountPriceAll = (int)(-sum * percentage);
                items.Add(new Item($"(折扣)打{(1 - percentage) * 100}折", discountPriceAll, 1, discountPriceAll));
                return items;
            }

            Item dish = items.FirstOrDefault(x => x.name == item);

            if(dish == null)
            {
                return items;
            }

            
            int discountPrice = (int)(-dish.price *  amount * percentage);
            if(dish.number < amount)
            {
                return items;
            }
            int number = dish.number / amount;
            items.Add(new Item($"(折扣){item}", discountPrice, number, number * discountPrice));
            return items;
        }
    }
}
