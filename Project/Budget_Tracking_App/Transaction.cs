using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    using System;

    public class Transaction
    {
        private double transactionAmount;
        private DateTime transactionDate;
        private string transactionNbr;
        private string transactionDescription;
        private bool isMonthlyRecurring;

        public Transaction(string trnNo, double amount, DateTime date, string note,bool isRecuring=false) 
        {
            transactionAmount = amount;
            transactionDate = date;
            transactionNbr = trnNo;
            transactionDescription = note;
            isMonthlyRecurring = isRecuring;
        }
        public void SetTransactionAmount(double amount)
        {
            transactionAmount = amount;
        }

        public void SetTransactionDate(DateTime date)
        {
            transactionDate = date;
        }

        public void SetTransactionNbr(string idNbr)
        {
            transactionNbr = idNbr;
        }

        public void SetTransactionDescription(string description)
        {
            transactionDescription = description;
        }

        public double GetTransactionAmount()
        {
            return transactionAmount;
        }

        public DateTime GetTransactionDate()
        {
            return transactionDate;
        }

        public string GetTransactionNbr()
        {
            return transactionNbr;
        }

        public string GetTransactionDescription()
        {
            return transactionDescription;
        }

        public bool GetIsMonthlyRecurring()
        {
            return isMonthlyRecurring;
        }

        public void SetIsMonthlyRecurring(bool isRec)
        {
            isMonthlyRecurring = isRec;
        }
    }

}
