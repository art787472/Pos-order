using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class Discount
    {
        public static void computeDiscount(List<Item> items, string discountOpt)
        {
            items.RemoveAll(x => x.name.Contains("贈送") || x.name.Contains("折扣"));
            switch (discountOpt)
            {
                case "雞排飯買2送1":

                    //int numOfChickenRice = items.FirstOrDefault(x => x.name == "雞排飯").number;

                    int? numOfChickenRice = items.FirstOrDefault(x => x.name == "雞排飯")?.number;
                    if(numOfChickenRice >= 2)
                        items.Add(new Item("雞排飯(贈送)", 0, numOfChickenRice.Value / 2, 0));
                    break;
                case "雞排飯三個250":
                    numOfChickenRice = items.FirstOrDefault(x => x.name == "雞排飯")?.number;
                    if(numOfChickenRice >= 3)
                        items.Add(new Item("雞排飯(折扣)", -20, numOfChickenRice.Value / 3, -20 * numOfChickenRice.Value / 3)); 
                        
                    break;
                case "豬排飯搭配紅茶110":
                    int? numOfPorkRice = items.FirstOrDefault(x => x.name == "豬排飯")?.number;
                    int? numOfBlackTea = items.FirstOrDefault(x => x.name == "紅茶")?.number;

                    if(numOfPorkRice == null  || numOfBlackTea == null)
                        break;

                    int? numOfPorkSet = numOfPorkRice >= numOfBlackTea ? numOfBlackTea : numOfPorkRice;
                    if(numOfPorkRice > 0)
                        items.Add(new Item("豬排飯搭配紅茶110(折扣)", -5, numOfPorkSet.Value, -5 * numOfPorkSet.Value));
                    break;
                case "魚排飯搭配綠茶100":
                    int? numOfFishRice = items.FirstOrDefault(x => x.name == "魚排飯")?.number;  
                    int? numOfGreenTea = items.FirstOrDefault(x => x.name == "綠茶")?.number;

                    if (numOfFishRice == null || numOfGreenTea == null)
                        break;

                    int? numOfFishSet = numOfFishRice >= numOfGreenTea ? numOfGreenTea : numOfFishRice;
                    if(numOfFishSet > 0)
                        items.Add(new Item("魚排飯搭配綠茶100(折扣)", -10, numOfFishSet.Value, -10 * numOfFishSet.Value));
                    break;
                case "買炒飯贈送冰淇淋":
                    int? numOfFriedRice = items.FirstOrDefault(x => x.name == "炒飯")?.number;

                    if (numOfFriedRice == null) break;
                    items.Add(new Item("冰淇淋(贈送)", 0, numOfFriedRice.Value, 0));
                    break;
                case "魚排飯贈送蘋果派":
                    numOfFishRice = items.FirstOrDefault(x => x.name == "魚排飯")?.number;

                    if (numOfFishRice == null) break;
                    items.Add(new Item("蘋果派(贈送)", 0, numOfFishRice.Value, 0));
                    break;
                case "全部品項打9折":
                    int sum = items.Sum(x => x.sum);
                    items.Add(new Item("全部品項打9折(折扣)", (int)(sum * -0.1), 1, (int)(sum * -0.1)));
                    break;
                case "豬排飯三個打85折":
                    numOfPorkRice = items.FirstOrDefault(x => x.name == "豬排飯")?.number;
                    if (numOfPorkRice >= 3)
                        items.Add(new Item("豬排飯三個打85折(折扣)", -38, numOfPorkRice.Value / 3, -38 * numOfPorkRice.Value / 3));
                        
                    break;
            }

            ShowPanel.GeneratePanel(items);
        }
    }
}
