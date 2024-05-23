using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class FishSetDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfFishRice = items.FirstOrDefault(x => x.name == "魚排飯")?.number;
            int? numOfGreenTea = items.FirstOrDefault(x => x.name == "綠茶")?.number;

            if (numOfFishRice == null || numOfGreenTea == null)
                return items;

            int? numOfFishSet = numOfFishRice >= numOfGreenTea ? numOfGreenTea : numOfFishRice;
            if (numOfFishSet > 0)
                items.Add(new Item("魚排飯搭配綠茶100(折扣)", -10, numOfFishSet.Value, -10 * numOfFishSet.Value));
            return items;
        }
    }
}
