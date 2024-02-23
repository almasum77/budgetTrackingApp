using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App.Interface
{
    public interface ITransaction
    {
        void SetTransactionAmount(double amount);
        void SetTransactionDate(DateTime date);
        void SetOccurrence(string period);

        double GetTransactionAmount();
        DateTime GetTransactionDate();
        string GetTransactionNumber();
        string GetOccurrence();
    }
}
