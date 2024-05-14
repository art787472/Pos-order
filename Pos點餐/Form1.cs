using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using CheckBox = System.Windows.Forms.CheckBox;

namespace Pos點餐
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] mainDishes = { "雞排飯$90", "豬排飯$85", "魚排飯$75", "炒飯$100" };
            string[] subDishes = { "薯條$30", "雞塊$30", "濃湯$30", "蘋果派$30" };
            string[] drinks = { "紅茶$30", "綠茶$35", "奶茶$40", };
            string[] desserts = { "蘋果派$25", "甜甜圈$30", "冰淇淋$35" };

            GenerateItemsUI(flowLayoutPanel1, mainDishes);
            GenerateItemsUI(flowLayoutPanel2, subDishes);
            GenerateItemsUI(flowLayoutPanel3, drinks);
            GenerateItemsUI(flowLayoutPanel4, desserts);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            int sum = 0;
            // 雞排飯$90
            // $ => [0] 雞排飯 [1] 90

            sum += GetSum(flowLayoutPanel1);
            sum += GetSum(flowLayoutPanel2);
            sum += GetSum(flowLayoutPanel3);
            sum += GetSum(flowLayoutPanel4);
            priceLab.Text = sum.ToString();
            //
            //if (checkBox1.Checked) sum += 80;
            //if (checkBox2.Checked) sum += 65;
            //if (checkBox3.Checked) sum += 95;
            //
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void GenerateItemsUI(FlowLayoutPanel flowLayoutPanel, string[] items)
        {
            foreach(string item in items)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.Text = item;
                flowLayoutPanel.Controls.Add(checkBox);
            }
        }

        private int GetPrice(string text) => int.Parse(text.Split('$')[1]);

        private int GetSum(FlowLayoutPanel flowLayoutPanel)
        {
            int sum = 0;
            // 雞排飯$90
            // $ => [0] 雞排飯 [1] 90

            foreach (CheckBox checkBox in flowLayoutPanel.Controls)
            {
                if (checkBox.Checked)
                    sum += GetPrice(checkBox.Text);
            }
            return sum;
        }

    }
}
