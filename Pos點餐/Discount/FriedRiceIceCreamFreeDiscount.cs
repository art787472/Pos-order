using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class FriedRiceIceCreamFreeDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            int? numOfFriedRice = items.FirstOrDefault(x => x.name == "炒飯")?.number;

            if (numOfFriedRice == null) return items;
            items.Add(new Item("冰淇淋(贈送)", 0, numOfFriedRice.Value, 0));
            return items;
        }
    }
}
