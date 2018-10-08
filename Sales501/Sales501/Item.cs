using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class Item
    {
        public string Name { get; set; }

        public double Value { get; set; }

        public int Code { get; set; }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Name: " + Name + "  ");
            sb.Append(" Price: " + Value + "  ");
            sb.Append(" Code: " + Code + "  ");
            return sb.ToString();
        }


        public Item(string name, double value, int code)
        {
            Name = name;
            Value = value;
            Code = code;
        }
    }
}
