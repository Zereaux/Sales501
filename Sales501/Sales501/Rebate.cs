using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class Rebate
    {
        public int Year { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public double Amount { get; set; }

        public int Number { get; set; }

        public Rebate(int year, string name, string address, int number, double amount)
        {
            Year = year;
            Name = name;
            Address = address;
            Number = number;
            Amount = amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("The transaction number is:  " + Number + "\n");
            sb.Append("name: " + Name + "  ");
            sb.Append("address:" + Address + "  ");
            sb.Append("amount: " + Amount);
            return sb.ToString();
        }
    }
}
