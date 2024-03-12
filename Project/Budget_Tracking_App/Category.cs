using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Category
    {
        private string categoryLabel;
        private Budget budgetAllocated;
        private DateTime monthAndYear;
        private List<Transaction> transactionList;

        public Category(string label, Budget budget, DateTime date)
        {
            categoryLabel = label;
            budgetAllocated = budget;
            monthAndYear = date;
            transactionList = new List<Transaction>();
        }

        public void SetCategoryLabel(string label)
        {
            categoryLabel = label;
        }

        public void SetCategoryBudget(Budget budget)
        {
            budgetAllocated = budget;
        }

        public void SetCategoryDate(DateTime date)
        {
            monthAndYear = date;
        }

        public string GetCategoryLabel()
        {
            return categoryLabel;
        }

        public Budget GetCategoryBudget()
        {
            return budgetAllocated;
        }

        public DateTime GetCategoryDate()
        {
            return monthAndYear;
        }

        //// Additional methods to manage transactions can be added here
        //// For example, to add a transaction to the list:
        //public void AddTransaction(Transaction transaction)
        //{
        //    transactionList.Add(transaction);
        //}
    }
}
