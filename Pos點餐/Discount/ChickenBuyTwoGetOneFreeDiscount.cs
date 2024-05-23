using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class ChickenBuyTwoGetOneFreeDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfChickenRice = items.FirstOrDefault(x => x.name == "雞排飯")?.number;
            if (numOfChickenRice >= 2)
                items.Add(new Item("雞排飯(贈送)", 0, numOfChickenRice.Value / 2, 0));
            return items;
        }
    }
}
