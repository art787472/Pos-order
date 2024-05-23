using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal abstract class ADiscount
    {
        public abstract List<Item> ComputeDiscount(List<Item> items);

    }
}
