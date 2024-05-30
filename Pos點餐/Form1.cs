﻿using Newtonsoft.Json;
using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Pos點餐.Models.POSModel;

namespace Pos點餐
{
    public partial class Form1 : Form
    {

        private List<FlowLayoutPanel> layoutPanels = new List<FlowLayoutPanel>();
        public Form1()
        {
            InitializeComponent();
            //string[] mainDishes = { "雞排飯$90", "豬排飯$85", "魚排飯$75", "炒飯$100" };
            //string[] subDishes = { "薯條$30", "雞塊$30", "濃湯$30", "蘋果派$30" };
            //string[] drinks = { "紅茶$30", "綠茶$35", "奶茶$40", };
            //string[] desserts = { "蘋果派$25", "甜甜圈$30", "冰淇淋$35" };


            //layoutPanels[0] = flowLayoutPanel1;
            //layoutPanels[1] = flowLayoutPanel2;
            //layoutPanels[2] = flowLayoutPanel3;
            //layoutPanels[3] = flowLayoutPanel4;
            //string[][] dishes = { mainDishes, subDishes, drinks, desserts };
            //string[] categories = { "主餐", "附餐", "甜點", "飲料" };

            //for(int i = 0; i < categories.Length; i++)
            //{
            //    FlowLayoutPanel panelContainer = new FlowLayoutPanel();
            //    FlowLayoutPanel panel = new FlowLayoutPanel();
            //    Label lab = new Label();
            //    lab.Text = categories[i];
                

            //    //lab.BorderStyle = BorderStyle.FixedSingle;
            //    //panel.BorderStyle = BorderStyle.FixedSingle;
            //    //panelContainer.BorderStyle = BorderStyle.FixedSingle;
            //    panelContainer.Height = 300;
            //    panel.Height = 300;
            //    panelContainer.Controls.Add(lab);
            //    panelContainer.Controls.Add(panel);
                
            //    container.Controls.Add(panelContainer);
            //    layoutPanels.Add(panel);
            //}
            
            //for(int i = 0; i < layoutPanels.Count; i++)
            //{
            //    layoutPanels[i].GenerateItemsUI(dishes[i], CheckedChage, ValueChage);
            //}

            // Register event
            EventHandlers.panelHandler += EventHandlerOnpanelHandler;

            List<KeyValueModel> list = new List<KeyValueModel>()
            {
                (new KeyValueModel("雞排飯買2送1","Pos點餐.ChickenBuyTwoGetOneFreeDiscount")),
                (new KeyValueModel("雞排飯三個250","Pos點餐.ChickenThreeDiscount")),
                (new KeyValueModel("豬排飯搭配紅茶110","Pos點餐.PorkSetDiscount")),
                (new KeyValueModel("魚排飯搭配綠茶100","Pos點餐.FishSetDiscount")),
                (new KeyValueModel("買炒飯贈送冰淇淋","Pos點餐.FriedRiceIceCreamFreeDiscount")),
                (new KeyValueModel("魚排飯贈送蘋果派","Pos點餐.FishRiceApplePieFreeDiscount")),
                (new KeyValueModel("全部品項打9折","Pos點餐.All10_offDiscount")),
                (new KeyValueModel("豬排飯三個打85折","Pos點餐.ThreePorkRice15_offDiscount")),
            };

            comboBox1.DataSource = list;
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";



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
            Order.AddOrder(item, comboBox1.SelectedValue.ToString());

        }

        public void ValueChage(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkBox = numericUpDown.Tag as CheckBox;
            checkBox.Checked = numericUpDown.Value > 0 ;

            Item item = new Item(checkBox.Text, numericUpDown.Value);
            Order.AddOrder(item, comboBox1.SelectedValue.ToString());

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //HW1:讀取json file => JsonCovert 套件
            //Hw2:動態生成所有品項
            TextReader textRdr = File.OpenText(@"../../../pos.json");
            
            JsonReader jsonReader = new JsonTextReader(textRdr);
            POSModel res = JsonConvert.DeserializeObject<POSModel>(textRdr.ReadToEnd());
            List<string> categories = res.foods.Select(x => x.category).ToList();



            foreach (var c in categories)
            {
                FlowLayoutPanel panelContainer = new FlowLayoutPanel();
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Label lab = new Label();
                lab.Text = c;


                //lab.BorderStyle = BorderStyle.FixedSingle;
                //panel.BorderStyle = BorderStyle.FixedSingle;
                //panelContainer.BorderStyle = BorderStyle.FixedSingle;
                panelContainer.Height = 300;
                panel.Height = 300;
                panelContainer.Controls.Add(lab);
                panelContainer.Controls.Add(panel);

                string[] items = res.foods.FirstOrDefault(x => x.category == c).foods.Select(x => $"{x.name}${x.price}").ToArray();

                panel.GenerateItemsUI(items, CheckedChage, ValueChage);

                container.Controls.Add(panelContainer);
                layoutPanels.Add(panel);
            }





        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(comboBox1.SelectedValue is string))
                return;

            Order.UpdateDiscount(comboBox1.SelectedValue.ToString());


        }
    }
}
