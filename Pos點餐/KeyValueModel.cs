using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pos點餐
{
    internal class KeyValueModel
    {
        public String Key { get; set; } 
        public String Value { get; set; }
        public KeyValueModel(string key,string value) { 
            this.Key = key;
            this.Value = value;
        }
    }
}
