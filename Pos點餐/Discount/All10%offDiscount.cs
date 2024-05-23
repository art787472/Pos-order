using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class All10_offDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            
            int sum = items.Sum(x => x.sum);
            items.Add(new Item("全部品項打9折(折扣)", (int)(sum * -0.1), 1, (int)(sum * -0.1)));
            return items;
        }
    }
}
