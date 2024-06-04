using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pos點餐.Models.POSModel;

namespace Pos點餐.Discount
{
    internal class BuyMgetNFree : ADiscount
    {
        public override List<Item> ComputeDiscount(Strategy strategy, List<Item> items)
        {
            Multiplediscount multipleDiscount = strategy.multipleDiscount;
            string itemName = multipleDiscount.item;
            int amount = multipleDiscount.amount;
            int free = multipleDiscount.discount.free;

            Item item = items.FirstOrDefault(x => x.name == itemName);
            if(item == null) 
            {
                return items;
            }
            if(item.number < amount)
            {
                return items;
            }

            items.Add(new Item($"(贈送){itemName}", 0, (item.number / amount), 0));

            return items;

        }
    }
}
