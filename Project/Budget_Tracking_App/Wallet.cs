using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{

    public class Wallet
    {
        private List<Category> categoryList;
        private List<Budget> budgetHistory;

        public Wallet()
        {
            categoryList = new List<Category>();
            budgetHistory = new List<Budget>();
        }

        public bool CreateCategory(Category category)
        {
            if (category == null)
            {
                categoryList.Add(category);
            }
            return true;
        }

        public bool RenameCategory(Category category)
        {
            if (!categoryList.Contains(category))
            {
                categoryList.Add(category);
            }
            return true;
        }

        public bool RemoveCategory(string label, DateTime monthYear)
        {
            Category remCate = categoryList.Where(s => s.GetCategoryLabel() == label && s.GetCategoryDate() == monthYear).FirstOrDefault();
            if (remCate != null)
            {
                categoryList.Remove(remCate);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool AddBudget(Budget budget)
        {
            if(budget != null) 
            {
             budgetHistory.Add(budget);
            }
            return true;
        }

        public bool RemoveBudget(double amount, DateTime monthYear)
        {
            Budget remBud = budgetHistory.Where(s => s.get() == label && s.GetCategoryDate() == monthYear).FirstOrDefault();
            if (remCate != null)
            {
                categoryList.Remove(remCate);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AllocateBudgetToCategory(Category category, double amount)
        {
            return true;
        }

        public bool AddTransaction(double amount, DateTime date, string transactionId, string group)
        {
            return true;
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

        public void DisplayAllOngoingTransactions(DateTime currentDate)
        {
        }

        public void DisplayCategoryTransactions(string label, DateTime date)
        {
        }

        public void DisplayAllPastTransactions()
        {
        }

        public void DisplayPastCategoryTransaction(string label)
        {
        }


        public bool SaveCategoriesToFile(string filepath)
        {
            return true;
        }

        public bool CloseAndOpenCategories(DateTime previousMonth, DateTime newMonth)
        {
            return true;
        }

        public void TrackBudget(string label, DateTime monthYear)
        {
        }

    }

}
