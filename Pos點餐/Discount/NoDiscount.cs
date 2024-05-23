using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{ 
    internal class NoDiscount : ADiscount
    {
        public override List<Item> ComputeDiscount(List<Item> items)
        {
            return items;
        }
    }
}
