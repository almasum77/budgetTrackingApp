using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    static class Helper
    {
        public static string GenerateTransactionNo() 
        {
            Guid guid = Guid.NewGuid();
            string guidString = guid.ToString("N");

            string transactionNo = guidString.Substring(0, 8);

            transactionNo = "TR" + transactionNo;

            return transactionNo;
        }
    }
}
