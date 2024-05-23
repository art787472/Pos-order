using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class PorkSetDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfPorkRice = items.FirstOrDefault(x => x.name == "豬排飯")?.number;
            int? numOfBlackTea = items.FirstOrDefault(x => x.name == "紅茶")?.number;

            if (numOfPorkRice == null || numOfBlackTea == null)
                return items;

            int? numOfPorkSet = numOfPorkRice >= numOfBlackTea ? numOfBlackTea : numOfPorkRice;
            if (numOfPorkRice > 0)
                items.Add(new Item("豬排飯搭配紅茶110(折扣)", -5, numOfPorkSet.Value, -5 * numOfPorkSet.Value));

            return items;
        }
    }
}
