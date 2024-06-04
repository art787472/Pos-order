using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Pos點餐.Models.POSModel;

namespace Pos點餐
{
    internal class DiscountContext
    {
        private ADiscount discount;
        private Strategy strategy;

        public DiscountContext(Strategy strategy)
        {
            this.strategy = strategy;
            string className = strategy.strategy;
            Type t = Type.GetType(className);

            this.discount = (ADiscount)Activator.CreateInstance(t);
        }

        public void GenerateDiscount(List<Item> items)
        {
            items.RemoveAll(x => x.name.Contains("贈送") || x.name.Contains("折扣"));
            items = this.discount.ComputeDiscount(strategy, items);
            ShowPanel.GeneratePanel(items);
        }
    }
}
