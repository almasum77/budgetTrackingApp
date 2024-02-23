using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Transaction:ITransaction
    {
        private string transaction_no { get; set; }
        private double transaction_amount { get; set; }
        private DateTime transaction_date { get; set; }
        private string transaction_description { get; set; }
        private string occarance_period { get; set; }

        public string GetOccurrence()
        {
            throw new NotImplementedException();
        }

        public double GetTransactionAmount()
        {
            throw new NotImplementedException();
        }

        public DateTime GetTransactionDate()
        {
            throw new NotImplementedException();
        }

        public string GetTransactionNumber()
        {
            throw new NotImplementedException();
        }

        public void SetOccurrence(string period)
        {
            throw new NotImplementedException();
        }

        public void SetTransactionAmount(double amount)
        {
            throw new NotImplementedException();
        }

        public void SetTransactionDate(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
