using Newtonsoft.Json;
using Pos點餐.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
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
            Strategy strategy = res.discount.strategies.FirstOrDefault(x => x.name == comboBox1.Text);
            Order.AddOrder(strategy, item);

        }

        public void ValueChage(object sender, EventArgs e)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            CheckBox checkBox = numericUpDown.Tag as CheckBox;
            checkBox.Checked = numericUpDown.Value > 0 ;

            Item item = new Item(checkBox.Text, numericUpDown.Value);
            string strategyName = comboBox1.Text;
            Strategy strategy = res.discount.strategies.FirstOrDefault(x => x.name == strategyName);
            Order.AddOrder(strategy, item);

        }

        private POSModel res;
        private void Form1_Load(object sender, EventArgs e)
        {
            //HW1:讀取json file => JsonCovert 套件
            //Hw2:動態生成所有品項
            TextReader textRdr = File.OpenText(ConfigurationManager.AppSettings["foodPath"]);
            
            JsonReader jsonReader = new JsonTextReader(textRdr);
            res = JsonConvert.DeserializeObject<POSModel>(textRdr.ReadToEnd());
            List<string> categories = res.foods.Select(x => x.category).ToList();



            foreach (var c in categories)
            {
                FlowLayoutPanel panelContainer = new FlowLayoutPanel();
                FlowLayoutPanel panel = new FlowLayoutPanel();
                Label lab = new Label();
                lab.Text = c;


                panelContainer.Height = 300;
                panel.Height = 300;
                panelContainer.Controls.Add(lab);
                panelContainer.Controls.Add(panel);

                string[] items = res.foods.FirstOrDefault(x => x.category == c).foods.Select(x => $"{x.name}${x.price}").ToArray();

                panel.GenerateItemsUI(items, CheckedChage, ValueChage);

                container.Controls.Add(panelContainer);
                layoutPanels.Add(panel);
            }

            List<Strategy> strategies = res.discount.strategies.ToList();

            List<KeyValueModel> list = new List<KeyValueModel>();
            
            foreach(Strategy strategy in strategies)
            {
                list.Add(new KeyValueModel(strategy.name, strategy.strategy));
            }


            comboBox1.DataSource = strategies;
            comboBox1.DisplayMember = "name";
            comboBox1.ValueMember = "strategy";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(!(comboBox1.SelectedValue is string))
                return;
            string strategyName = comboBox1.Text;

            Strategy strategy = res.discount.strategies.FirstOrDefault(x => x.name == strategyName);
            
            Order.UpdateDiscount(strategy);


        }

        
    }
}
