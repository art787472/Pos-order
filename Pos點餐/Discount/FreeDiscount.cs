using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐.Discount
{
    internal class FreeDiscount : ADiscount

    {
        public override List<Item> ComputeDiscount(POSModel.Strategy strategy, List<Item> items)
        {
            string item1 = strategy.freeItem.item1;
            string item2 = strategy.freeItem.item2;

            Item dish = items.FirstOrDefault(x => x.name == item1);
            if(dish == null)
            {
                return items;
            }
            items.Add(new Item($"(贈送){item2}", 0, dish.number, 0));
            return items;
        }
    }
}
