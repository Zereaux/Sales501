using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales501
{
    public class TransactionManager
    {
        private int _productID = 0;

        public int IDGenerator()
        {
            _productID++;
            return _productID;
        }

        private Dictionary<int, Transaction> _transactionID = new Dictionary<int, Transaction>();

        public bool CheckID(int number)
        {
            if (_transactionID.ContainsKey(number))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckTransactionStatus(int number)
        {
            if (_transactionID[number]._status == "Rebated")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Transaction GetTransaction(int number)
        {
            if (!CheckID(number))
            {
                return null;
            }
            else
                return _transactionID[number];
        }

        public Transaction ChangeTransaction(int number, string name)
        {
            Transaction tran = GetTransaction(number);

            if (tran == null)
            {
                return null;
            }
            tran.DeleteItemByName(name);

            return tran;
        }

        public void CheckOut(Transaction tran)
        {
            _transactionID.Add(tran.TransactionNumber, tran);
        }

        public bool DeleteTransaction(int number)
        {
            if (CheckID(number))
            {
                _transactionID.Remove(number);
                return true;
            }
            return false;
        }
    }
}
