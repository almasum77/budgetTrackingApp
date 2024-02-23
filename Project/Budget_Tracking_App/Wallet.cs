using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Wallet
    {
        private List<Category> categoryList;
        private List<Budget> budgetHistory;
        //private WalletRepository database;

        public Wallet()
        {
            categoryList = new List<Category>();
            budgetHistory = new List<Budget>();
            //database = new WalletRepository();
        }

        public bool CreateCategory(string label)
        {
             
            return true;
        }

        public bool RenameCategory(string oldName, string newName)
        {
             
            return true;
        }

        public bool RemoveCategory(string label)
        {
             
            return true;
        }

        public bool AddBudget(double amount)
        {
             
            return true;
        }

        public bool ModifyBudget(double amount)
        {
             
            return true;
        }

        public bool AllocateBudgetToCategory(string label, double amount)
        {
             
            return true;
        }

        public bool AddTransaction(double amount, DateTime date, string transactionId, string group)
        {
             
            return true;
        }

        public void ApplyPeriodicTransaction()
        {
             
        }

        public bool ModifyTransactionAmount(string transactionId, double newAmount)
        {
             
            return true;
        }

        public bool MoveTransaction(string transactionId, string originalGroup, string recipientGroup)
        {
             
            return true;
        }

        public bool RemoveTransaction(string label, string transactionId)
        {
             
            return true;
        }

        public void DisplayAllOngoingTransactions()
        {
             
        }

        public void DisplayOngoingTransactions(string label)
        {
             
        }

        public void DisplayAllPastTransactions(string filename)
        {
             
        }

        public void DisplayPastTransactions(string filename, string label)
        {
             
        }

        public bool AddTransactionDescription(string transactionId, string group)
        {
             
            return true;
        }

        public bool ModifyTransactionDescription(string transactionId, string group)
        {
             
            return true;
        }

        public bool RemoveTransactionDescription(string transactionId, string group)
        {
             
            return true;
        }
    }
}
