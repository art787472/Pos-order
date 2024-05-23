using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class FishRiceApplePieFreeDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfFishRice = items.FirstOrDefault(x => x.name == "魚排飯")?.number;

            if (numOfFishRice == null) return items;
            items.Add(new Item("蘋果派(贈送)", 0, numOfFishRice.Value, 0));
            return items;

        }
    }
}
