﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos點餐
{
    internal class Order
    {
        private static List<Item> items = new List<Item> ();
        public static void AddOrder(Item item)
        {
            bool hasItem = items.Any(x => x.name == item.name);
            Item product = items.FirstOrDefault(x => x.name == item.name);
            FlowLayoutPanel panel = new FlowLayoutPanel();
            // 新增:
            if (!hasItem && item.number > 0)
            {
                items.Add(item);
                ShowPanel.GeneratePanel(items);
                return;
            }
            // 刪除:
            if(item.number == 0)
            {
                items.Remove(product);
                ShowPanel.GeneratePanel(items);
                return;
            }
            
            // 修改:
            product.number = item.number;
            product.sum = item.sum;
            ShowPanel.GeneratePanel(items);
        }



    }
}
