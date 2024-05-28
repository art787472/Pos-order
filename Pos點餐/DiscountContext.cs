using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class DiscountContext
    {
        private ADiscount discount;

        public DiscountContext(string discountOpt)
        {
            Type t = Type.GetType(discountOpt);
            this.discount = (ADiscount)Activator.CreateInstance(t);
        }

        public List<Item> GetResult(List<Item> items)
        {
            return this.discount.ComputeDiscount(items);
        }
    }
}
