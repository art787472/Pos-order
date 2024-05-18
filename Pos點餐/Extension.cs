using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static System.Net.Mime.MediaTypeNames;

namespace Pos點餐
{
    internal static class Extension
    {

        //public static int GetLength(this string str,int number)
        //{
        //    return str.Length;
        //}

        public static void GenerateItemsUI(this FlowLayoutPanel flowLayoutPanel, string[] items, EventHandler checkChage, EventHandler valueChage)
        {
            foreach (string item in items)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                NumericUpDown numericUpDown = new NumericUpDown();
                numericUpDown.Width = 50;
                checkBox.Tag = numericUpDown;
                numericUpDown.Tag = checkBox;
                FlowLayoutPanel panel = new FlowLayoutPanel();
                checkBox.CheckedChanged += checkChage;
                numericUpDown.ValueChanged += valueChage;
                panel.Height = 50;
                panel.Controls.Add(checkBox);
                panel.Controls.Add(numericUpDown);
                flowLayoutPanel.Controls.Add(panel);
            }
        }

        public static List<Item> GetItems(this FlowLayoutPanel flowLayoutPanel)
        {
            List<Item> list = new List<Item>();
            // 雞排飯$90
            // $ => [0] 雞排飯 [1] 90
            

            foreach (FlowLayoutPanel panel in flowLayoutPanel.Controls)
            {
                
                CheckBox checkBox = (CheckBox)panel.Controls[0];
       

                NumericUpDown numericUpDown = (NumericUpDown)panel.Controls[1];
                string name = checkBox.Text.Split('$')[0];
                int price = int.Parse(checkBox.Text.Split('$')[1]);
                int number = (int)numericUpDown.Value;
                int sum = 0;
                if (checkBox.Checked)
                {
                    
                    sum = price * number;
                    Item item = new Item(name, price, number, sum);
                    list.Add(item);
                }
                
                
            }
            return list;
        }

        public static void GenerateRecordUI(this FlowLayoutPanel flowLayoutPanel, List<Item> items)
        {
            
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
                sumLab.TextAlign= ContentAlignment.MiddleCenter;
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

                flowLayoutPanel.Controls.Add(panel);

            }
        }

        public static void GenerateRecordHeadUI(this FlowLayoutPanel flowLayoutPanel)
        {
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
        }


    }
}
