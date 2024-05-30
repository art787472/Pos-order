using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐.Models
{
    internal class POSModel
    {
        public Food[] foods { get; set; }
        public Discount discount { get; set; }

        public class Discount
        {
            public Strategy[] strategies { get; set; }
        }

        public class Strategy
        {
            public string strategy { get; set; }
            public Setitems setItems { get; set; }
            public Multiplediscount multipleDiscount { get; set; }
            public Freeitem freeItem { get; set; }
            public Discount2 discount { get; set; }
        }

        public class Setitems
        {
            public string item1 { get; set; }
            public string item2 { get; set; }
            public int price { get; set; }
        }

        public class Multiplediscount
        {
            public string item { get; set; }
            public int amount { get; set; }
            public Discount1 discount { get; set; }
        }

        public class Discount1
        {
            public float percentage { get; set; }
            public int price { get; set; }
            public int free { get; set; }
        }

        public class Freeitem
        {
            public string item1 { get; set; }
            public string item2 { get; set; }
        }

        public class Discount2
        {
            public int percentage { get; set; }
            public int price { get; set; }
        }

        public class Food
        {
            public string category { get; set; }
            public Food1[] foods { get; set; }
        }

        public class Food1
        {
            public string name { get; set; }
            public int price { get; set; }
        }

    }
}
