using System.Collections.Generic;
using System.Linq;

namespace Pos點餐
{
    internal class ChickenThreeDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfChickenRice = items.FirstOrDefault(x => x.name == "雞排飯")?.number;
            if (numOfChickenRice >= 3)
                items.Add(new Item("雞排飯(折扣)", -20, numOfChickenRice.Value / 3, -20 * numOfChickenRice.Value / 3));
            return items;
        }
    }
}
