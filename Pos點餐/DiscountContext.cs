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

        public void GenerateDiscount(List<Item> items)
        {
            items.RemoveAll(x => x.name.Contains("贈送") || x.name.Contains("折扣"));
            items = this.discount.ComputeDiscount(items);
            ShowPanel.GeneratePanel(items);
        }
    }
}
