using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class ThreePorkRice15_offDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfPorkRice = items.FirstOrDefault(x => x.name == "豬排飯")?.number;
            if (numOfPorkRice >= 3)
                items.Add(new Item("豬排飯三個打85折(折扣)", -38, numOfPorkRice.Value / 3, -38 * numOfPorkRice.Value / 3));
            return items;
        }
    }
}
