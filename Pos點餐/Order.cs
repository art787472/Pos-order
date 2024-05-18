using System;
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

            // 新增:
            if(!hasItem && item.number > 0)
            {
                items.Add(item);
                return;
            }
            // 刪除:
            if(item.number == 0)
            {
                items.Remove(product);
                return;
            }
            
            // 修改:
            product.number = item.number;
            product.sum = item.sum;

            
        }

        public static FlowLayoutPanel GeneratePanel()
        {
            FlowLayoutPanel result = new FlowLayoutPanel();
            result.Height = 700;
            result.Width = 400;
            result.Controls.Add(GeneratePanelHeadUI());
            foreach (Item item in items)
            {
                Label nameLab = new Label();
                nameLab.Text = $"{item.name}";
                nameLab.TextAlign = ContentAlignment.MiddleCenter;
                Label priceLab = new Label();
                priceLab.Text = $"{item.number}";
                priceLab.TextAlign = ContentAlignment.MiddleCenter;
                Label numberLab = new Label();
                numberLab.Text = $"{item.price}";
                numberLab.TextAlign = ContentAlignment.MiddleCenter;
                Label sumLab = new Label();
                sumLab.Text = $"{item.sum}";
                sumLab.TextAlign = ContentAlignment.MiddleCenter;
                Label noteLab = new Label();
                noteLab.Text = $"{item.note}";
                noteLab.TextAlign = ContentAlignment.MiddleCenter;
                nameLab.Width = 70;
                priceLab.Width = 70;
                numberLab.Width = 70;
                sumLab.Width = 70;
                noteLab.Width = 70;

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.Width = 400;
                panel.Height = 20;
                panel.Controls.Add(nameLab);
                panel.Controls.Add(priceLab);
                panel.Controls.Add(numberLab);
                panel.Controls.Add(sumLab);
                panel.Controls.Add(noteLab);

                result.Controls.Add(panel);

            }
            return result;
        }

        private FlowLayoutPanel GeneratePanelHeadUI()
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.Width = 400;
            flowLayoutPanel.Height = 50;
            Label nameHead = new Label();
            nameHead.Text = $"品名";
            nameHead.TextAlign = ContentAlignment.MiddleCenter;

            Label priceHead = new Label();
            priceHead.Text = $"數量";
            priceHead.TextAlign = ContentAlignment.MiddleCenter;
            Label numberHead = new Label();
            numberHead.Text = $"單價";
            numberHead.TextAlign = ContentAlignment.MiddleCenter;
            Label sumHead = new Label();
            sumHead.Text = $"小計";
            sumHead.TextAlign = ContentAlignment.MiddleCenter;
            Label noteHead = new Label();

            noteHead.Text = $"備註";
            noteHead.TextAlign = ContentAlignment.MiddleCenter;
            nameHead.Width = 70;
            priceHead.Width = 70;
            numberHead.Width = 70;
            sumHead.Width = 70;
            noteHead.Width = 70;

            flowLayoutPanel.Controls.Add(nameHead);
            flowLayoutPanel.Controls.Add(priceHead);
            flowLayoutPanel.Controls.Add(numberHead);
            flowLayoutPanel.Controls.Add(sumHead);
            flowLayoutPanel.Controls.Add(noteHead);

            return flowLayoutPanel;
        }

        public static string Total()
        {
            return items.Sum(x => x.sum).ToString();
        }

    }
}
