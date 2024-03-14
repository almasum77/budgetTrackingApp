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
            if (category != null)
            {
                categoryList.Add(category);
            }
            return true;
        }

        //new added
        public void DisplayCategories(DateTime monthYear)
        {
            var filteredCategories = categoryList.Where(c => c.GetCategoryDate().Month == monthYear.Month && c.GetCategoryDate().Year == monthYear.Year);

            if (!filteredCategories.Any())
            {
                Console.WriteLine("No categories found for the specified month and year.");
                return;
            }

            Console.WriteLine($"Categories for {monthYear.ToString("MM/yyyy")}:");
            foreach (var category in filteredCategories)
            {
                Console.WriteLine($"- {category.GetCategoryLabel()} (Budget: {category.GetCategoryBudget()})");
            }
        }

        public bool RenameCategory(string oldLabel, string newLabel, DateTime monthYear)
        {
            Category categoryToRename = categoryList.FirstOrDefault(c => c.GetCategoryLabel() == oldLabel && c.GetCategoryDate() == monthYear);
            if (categoryToRename != null)
            {
                categoryToRename.SetCategoryLabel(newLabel);
                return true; 
            }
            return false; 
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

        //new added
        //public void GetAllCategory() 
        //{
        //    List<string> catList=categoryList.Select(s=>s.GetCategoryLabel()).Distinct().ToList();
        //    foreach (var item in catList)
        //    {
        //        Console.WriteLine("Categories are :");
        //        Console.WriteLine($"{item}");
        //    }
        //}




        public bool AddBudget(Budget budget)
        {
            if(budget != null) 
            {
             budgetHistory.Add(budget);
            }
            return true;
        }

        public bool RemoveBudget(Budget budget)
        {
            if (budget != null)
            {
                budgetHistory.Remove(budget);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool AllocateBudgetToCategory(string categoryLabel, double amount, DateTime monthYear)
        {
            Category modifiedCategory = categoryList.FirstOrDefault(c => c.GetCategoryLabel() == categoryLabel && c.GetCategoryDate() == monthYear);
            if (modifiedCategory != null)
            {
                modifiedCategory.SetCategoryBudget(amount);
                return true;
            }
            return false;
        }

        public Budget GetBudgetByDate(DateTime date)
        {
            return budgetHistory.FirstOrDefault(b => b.GetDate() == date);
        }



        //changed parameters.......
        public bool AddTransaction(Transaction tran, string catLabel)
        {
            DateTime currentDate = tran.GetTransactionDate().Date;
            Category cat = categoryList.FirstOrDefault(w => w.GetCategoryLabel() == catLabel
                         && w.GetCategoryDate().Month == currentDate.Month
                         && w.GetCategoryDate().Year == currentDate.Year);

            if (cat != null)
            {
                cat.transactionList.Add(tran);

                Budget currentBudget = budgetHistory.FirstOrDefault(b => b.GetDate().Month == currentDate.Month && b.GetDate().Year == currentDate.Year);
                if (currentBudget != null)
                {
                    double newAmount = currentBudget.GetremainingBudget() - tran.GetTransactionAmount();
                    currentBudget.SetremainingBudget(newAmount);
                }

                return true;
            }
            return false;
        }

        public bool ModifyTransactionAmount(string transactionId, double newAmount)
        {
            Transaction transaction= categoryList.Select(w=>w.transactionList.Where(s=>s.GetTransactionNbr()==transactionId).FirstOrDefault()).FirstOrDefault();
            if (transaction != null)
            {
                transaction.SetTransactionAmount(newAmount);

                DateTime currentDate = transaction.GetTransactionDate().Date;
                Budget currentBudget = budgetHistory.FirstOrDefault(b => b.GetDate().Month == currentDate.Month && b.GetDate().Year == currentDate.Year);
                if (currentBudget != null)
                {
                    double newRemaining = currentBudget.GetremainingBudget() - transaction.GetTransactionAmount();
                    currentBudget.SetremainingBudget(newRemaining);
                }

                return true;
            }
            return false;
        }
        // why group ????????????????????
        public bool MoveTransaction(string transactionId, string newCategoryLabel)
        {
            var originalCategory = categoryList.FirstOrDefault(cat => cat.transactionList.Any(tran => tran.GetTransactionNbr() == transactionId));
            if (originalCategory == null)
            {
                Console.WriteLine("Original category not found.");
                return false; 
            }

            var transaction = originalCategory.transactionList.FirstOrDefault(tran => tran.GetTransactionNbr() == transactionId);
            if (transaction == null)
            {
                Console.WriteLine("Transaction not found.");
                return false; 
            }

            var newCategory = categoryList.FirstOrDefault(cat => cat.GetCategoryLabel() == newCategoryLabel);
            if (newCategory == null)
            {
                Console.WriteLine("New category not found.");
                return false; 
            }

            originalCategory.transactionList.Remove(transaction);

            newCategory.transactionList.Add(transaction);

            return true;
        }

        // removed parameter string label 
        public bool RemoveTransaction(string transactionId)
        {
            Transaction transaction = categoryList.Select(w => w.transactionList.Where(s => s.GetTransactionNbr() == transactionId).FirstOrDefault()).FirstOrDefault();
            foreach (var category in categoryList)
            { 
             category.transactionList.Remove(transaction);
            }

            return true;
        }

        public void DisplayAllOngoingTransactions(DateTime currentDate)
        {
            List<Category> currentCategoryList = categoryList.Where(s => s.GetCategoryDate().Month == currentDate.Month && s.GetCategoryDate().Year==currentDate.Year).ToList();
            foreach (var category in currentCategoryList)
            {
                Console.WriteLine($"Category Name: {category.GetCategoryLabel()}");
                foreach (var transaction in category.transactionList)
                {
                    Console.WriteLine($"Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate()}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}");
                }
            }
        }

        public void DisplayCategoryTransactions(string label, DateTime date)
        {
            Category category = categoryList.Where(s => s.GetCategoryLabel() == label & s.GetCategoryDate().Month == date.Month && s.GetCategoryDate().Year==date.Year).FirstOrDefault();

        }

        public void DisplayAllPastTransactions()
        {
            foreach (var category in categoryList)
            {
                Console.WriteLine($"Category Name: {category.GetCategoryLabel()}");
                foreach (var transaction in category.transactionList)
                {
                    Console.WriteLine($"Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate()}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}");
                }
            }
        }
        
        public void DisplayPastCategoryTransaction(string label)
        {
            List<Category> currentCategoryList = categoryList.Where(s => s.GetCategoryLabel() == label).ToList();

            foreach (var category in currentCategoryList)
            {
                Console.WriteLine($"Category Name: {category.GetCategoryLabel()}");
                foreach (var transaction in category.transactionList)
                {
                    Console.WriteLine($"Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate()}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}");
                }
            }
        }


        //deleted previous month parameter and added category label
        public bool CloseAndOpenCategories(string catLabel,DateTime newMonth)
        {
            Category newCategory = new Category();
            newCategory = categoryList.Where(s => s.GetCategoryLabel() == catLabel).OrderByDescending(s=>s.GetCategoryDate()).FirstOrDefault();
            if (newCategory != null)
            {
                newCategory.SetCategoryDate(newMonth);
                categoryList.Add(newCategory);
                return true;
            }
            return false;
        }

        //???????????
        public void TrackBudget(string catLabel, DateTime monthYear)
        {
            //List<Category> category = categoryList.Where(e=>e.GetCategoryLabel()==catLabel & e.GetCategoryDate()=)
            //show if overspend or not only
        }
        public bool SaveCategoriesToFile(string filepath)
        {
            return true;
        }

    }

}
