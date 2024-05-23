﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class Discount
    {
        public static void GenerateDiscount(List<Item> items, string discountOpt)
        {
            ADiscount discount = DiscountFactory.CreateDiscount(discountOpt);
            items.RemoveAll(x => x.name.Contains("贈送") || x.name.Contains("折扣"));
            items = discount.ComputeDiscount(items);
            ShowPanel.GeneratePanel(items);
        }
    }
}
