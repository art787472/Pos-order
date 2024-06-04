using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pos點餐.Models.POSModel;

namespace Pos點餐
{
    internal abstract class ADiscount
    {
        public abstract List<Item> ComputeDiscount(Strategy strategy,List<Item> items);

    }
}
