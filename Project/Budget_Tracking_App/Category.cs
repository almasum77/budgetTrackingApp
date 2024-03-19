using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Category: ITransactionDate
    {
        private string categoryLabel;
        private double budgetAllocated;
        private DateTime monthAndYear;
        private bool isExpense;
        public List<Transaction> transactionList; //changed access modifier to public

        public Category(string label, double budget, DateTime date, bool isExpense)
        {
            categoryLabel = label;
            budgetAllocated = budget;
            monthAndYear = date;
            transactionList = new List<Transaction>();
            this.isExpense = isExpense; 
        }

        public Category()
        { 
        }

        public void SetCategoryLabel(string label)
        {
            categoryLabel = label;
        }

        //changed parameter type form budget to double??????
        public void SetCategoryBudget(double budget)
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

        public double GetCategoryBudget()
        {
            return budgetAllocated;
        }

        public DateTime GetCategoryDate()
        {
            return monthAndYear;
        }

        public DateTime GetTransactionDate()
        {
            throw new NotImplementedException();
        }

        public void SetIsExpense(bool isExp) 
        {
            isExpense = isExp;

        }

        public bool GetIsExpense()
        { 
            return isExpense;   
        }

        //public void AddTransaction(Transaction transaction)
        //{
        //    transactionList.Add(transaction);
        //}
    }
}
