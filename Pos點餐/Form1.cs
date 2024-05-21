using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pos點餐
{
    public partial class Form1 : Form
    {

        private List<FlowLayoutPanel> layoutPanels = new List<FlowLayoutPanel>();
        public Form1()
        {
            InitializeComponent();
            string[] mainDishes = { "雞排飯$90", "豬排飯$85", "魚排飯$75", "炒飯$100" };
            string[] subDishes = { "薯條$30", "雞塊$30", "濃湯$30", "蘋果派$30" };
            string[] drinks = { "紅茶$30", "綠茶$35", "奶茶$40", };
            string[] desserts = { "蘋果派$25", "甜甜圈$30", "冰淇淋$35" };


            //layoutPanels[0] = flowLayoutPanel1;
            //layoutPanels[1] = flowLayoutPanel2;
            //layoutPanels[2] = flowLayoutPanel3;
            //layoutPanels[3] = flowLayoutPanel4;
            string[][] dishes = { mainDishes, subDishes, drinks, desserts };
            string[] categories = { "主餐", "附餐", "甜點", "飲料" };

            for(int i = 0; i < categories.Length; i++)
            {
                FlowLayoutPanel panelContainer = new FlowLayoutPanel();
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Label lab = new Label();
                lab.Text = categories[i];
                

                //lab.BorderStyle = BorderStyle.FixedSingle;
                //panel.BorderStyle = BorderStyle.FixedSingle;
                //panelContainer.BorderStyle = BorderStyle.FixedSingle;
                panelContainer.Height = 300;
                panel.Height = 300;
                panelContainer.Controls.Add(lab);
                panelContainer.Controls.Add(panel);
                
                container.Controls.Add(panelContainer);
                layoutPanels.Add(panel);
            }
            
            for(int i = 0; i < layoutPanels.Count; i++)
            {
                layoutPanels[i].GenerateItemsUI(dishes[i], CheckedChage, ValueChage);
            }

            // Register event
            EventHandlers.panelHandler += EventHandlerOnpanelHandler;

        }

        private void EventHandlerOnpanelHandler(object sender, (FlowLayoutPanel, string) args)
        {
            recordContainer.Controls.Clear();
            recordContainer.Controls.Add(args.Item1);
            priceLab.Text = args.Item2;
        }

        public void CheckedChage(object sender,EventArgs e)
        {
            CheckBox checkBox = (CheckBox)sender;
            NumericUpDown numericUpDown = checkBox.Tag as NumericUpDown;
            numericUpDown.Value = checkBox.Checked == true ? 1 : 0;

            
            Item item = new Item(checkBox.Text, numericUpDown.Value);
            Order.AddOrder(item);
            

        }

        public void ValueChage(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkBox = numericUpDown.Tag as CheckBox;
            checkBox.Checked = numericUpDown.Value > 0 ;

            Item item = new Item(checkBox.Text, numericUpDown.Value);
            Order.AddOrder(item);
            

        }



    }
}
