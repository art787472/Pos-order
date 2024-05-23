
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class DiscountFactory
    {
        public static ADiscount CreateDiscount(string discountOpt)
        {
            ADiscount discount = null;
            switch (discountOpt)
            {
                case "雞排飯買2送1":
                    discount = new ChickenBuyTwoGetOneFreeDiscount();
                    break;
                case "雞排飯三個250":
                    discount = new ChickenThreeDiscount();
                    break;
                case "豬排飯搭配紅茶110":
                    discount = new PorkSetDiscount();
                    break;
                case "魚排飯搭配綠茶100":
                    discount = new FishSetDiscount();
                    break;
                case "買炒飯贈送冰淇淋":
                    discount = new FriedRiceIceCreamFreeDiscount();
                    break;
                case "魚排飯贈送蘋果派":
                    discount = new FishRiceApplePieFreeDiscount();
                    break;
                case "全部品項打9折":
                    discount = new All10_offDiscount();
                    break;
                case "豬排飯三個打85折":
                    discount = new ThreePorkRice15_offDiscount();
                    break;
                case "":
                    discount = new NoDiscount();
                    break;
            }
            return discount;
        }
        }
}
