using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class Transaction
    {
        public List<Item> _items;

        public double _total;

        public int Year { get; set; }

        public int Month { get; set; }

        public int Day { get; set; }

        public int TransactionNumber { get; set; }

        public string _status;

        public string ChangeStatus(String s)
        {
            _status = s;
            return _status;
        }

        public void AddItem(Item item)
        {
            _items.Add(item);
            _total += item.Value;

        }

        public bool CheckItemByName(string name)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool DeleteItemByName(string name)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].Name == name)
                {
                    _total -= _items[i].Value;
                    _items.Remove(_items[i]);

                    return true;

                }
            }
            return false;
        }

        public double GetTotal()
        {
            return _total;
        }

        public Transaction(int year, int month, int day, int number)
        {
            _items = new List<Item>();
            _total = 0;
            Year = year;
            Month = month;
            Day = day;
            TransactionNumber = number;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("\n");
            sb.Append("Transaction No.: " + TransactionNumber + "\n");
            sb.Append("Date: " + Year + " " + Month + " " + Day + "\n" + "\n");
            for (int i = 0; i < _items.Count; i++)
            {
                sb.Append(_items[i].ToString() + "\n");
            }
            sb.Append("\n");
            sb.Append("Total " + _total + "\n");
            sb.Append("Status: (" + ChangeStatus("Sold") + ")");
            return sb.ToString();
        }
    }
}
