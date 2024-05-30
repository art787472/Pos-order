using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos點餐
{
    internal class Item
    {
        public string name;
        public int price;
        public int number;
        public int sum;
        public string note;

        public Item(string name, int price, int number, int sum, string note = "")
        {
            this.name = name;
            this.price = price;
            this.number = number;
            this.sum = sum;
            this.note = note;
        }

        public Item(string checkBoxText, decimal numericUpDownValue)
        {
            string name = checkBoxText.Split('$')[0];
            int price = int.Parse(checkBoxText.Split('$')[1]);
            int number = (int)numericUpDownValue;
            int sum = price * number;
            this.name = name;
            this.price = price;
            this.number = number;
            this.sum = sum;
        }
    }
}
