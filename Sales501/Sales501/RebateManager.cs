using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class RebateManager
    {
        public List<Rebate> _rebates;

        public RebateManager()
        {
            _rebates = new List<Rebate>();
        }

        public void AddRebate(Rebate r)
        {
            _rebates.Add(r);
        }


        public Rebate RebateNumberSearch(int number)
        {
            for (int i = 0; i < _rebates.Count; i++)
            {
                if (_rebates[i].Number == number)
                {
                    return _rebates[i];
                }
            }
            return null;
        }

        public string GenerateAllChecks()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _rebates.Count; i++)
            {
                sb.Append("NO.   " + _rebates[i].ToString() + "\n");
            }
            return sb.ToString();
        }

        public string GenerateOneCheck(int n)
        {
            Rebate rb = RebateNumberSearch(n);
            return rb.ToString();
        }
    }
}
