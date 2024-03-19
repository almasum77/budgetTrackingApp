using Budget_Tracking_App.Interface;
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
                Category preCat = categoryList.Where(e => e.GetCategoryLabel().ToLower() == category.GetCategoryLabel().ToLower() && e.GetCategoryDate().Month==category.GetCategoryDate().Month && e.GetCategoryDate().Year == category.GetCategoryDate().Year).FirstOrDefault();
                if (preCat == null)
                {
                    categoryList.Add(category);
                    return true;
                }
                
            }
            return false;
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
                string type = "";
                if (category.GetIsExpense() == true)
                { 
                    type = "Expense"; 
                }
                else
                {
                    type = "Income";
                }
                Console.WriteLine($"- {category.GetCategoryLabel()} (Budget: {category.GetCategoryBudget()} and Type: {type})");
            }
        }

        public bool RenameCategory(string oldLabel, string newLabel, DateTime monthYear)
        {
            Category categoryToRename = categoryList.FirstOrDefault(c => c.GetCategoryLabel().ToLower() == oldLabel.ToLower() && c.GetCategoryDate() == monthYear);
            if (categoryToRename != null)
            {
                categoryToRename.SetCategoryLabel(newLabel);
                return true; 
            }
            return false; 
        }

        public bool UpdateCategoryBudget(string label, DateTime monthYear, double newBudget)
        {
            var category = categoryList.FirstOrDefault(c => c.GetCategoryLabel().ToLower() == label.ToLower() && c.GetCategoryDate() == monthYear);
            if (category != null)
            {
                category.SetCategoryBudget(newBudget);
                return true; 
            }
            return false; 
        }


        public bool RemoveCategory(string label, DateTime monthYear)
        {
            Category remCate = categoryList.Where(s => s.GetCategoryLabel().ToLower() == label.ToLower() && s.GetCategoryDate() == monthYear).FirstOrDefault();
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
            Category modifiedCategory = categoryList.FirstOrDefault(c => c.GetCategoryLabel().ToLower() == categoryLabel.ToLower() && c.GetCategoryDate() == monthYear);
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
            DateTime tranDate = tran.GetTransactionDate().Date;
            
            Category cat = categoryList.FirstOrDefault(w => w.GetCategoryLabel().ToLower() == catLabel.ToLower()
                             && w.GetCategoryDate().Month == tranDate.Month
                             && w.GetCategoryDate().Year == tranDate.Year);

            if (cat != null)
            {
                Budget budget = budgetHistory.FirstOrDefault(b => b.GetDate().Month == tranDate.Month && b.GetDate().Year == tranDate.Year);

                if (cat.GetIsExpense() == false)
                {
                    cat.transactionList.Add(tran);
                    return true;
                }
                else
                {
                    if (budget != null && cat.GetIsExpense() == true)
                    {
                        //Check if adding the transaction would exceed the remaining budget
                        double newAmountAfterTransaction = budget.GetremainingBudget() - tran.GetTransactionAmount();

                        if (newAmountAfterTransaction >= 0)
                        {
                            cat.transactionList.Add(tran);

                            budget.SetremainingBudget(newAmountAfterTransaction);
                            TrackBudgetByCategory(cat.GetCategoryLabel(), tran.GetTransactionDate());

                            return true;
                        }
                        else
                        {
                            Console.WriteLine("Adding this transaction would exceed the remaining budget for this month.");
                            return false;
                        }
                    }
                    else
                    {
                        //No budget found for the current month
                        Console.WriteLine("No budget found for the current month. Transaction cannot be added.");
                        return false;
                    }
                }

            }
            else
            {
                //Category not found
                Console.WriteLine("Category not found. Transaction cannot be added.");
                return false;
            }
        }


        public bool ModifyTransactionAmount(string transactionId, double newAmount)
        {
            Transaction transaction = categoryList.SelectMany(cat => cat.transactionList)
                .FirstOrDefault(tran => tran.GetTransactionNbr().ToLower() == transactionId.ToLower());

            if (transaction != null)
            {
                // Calculating the difference between the new and current transaction amount
                double amountDifference = newAmount - transaction.GetTransactionAmount();

                DateTime transactionDate = transaction.GetTransactionDate();
                Budget currentBudget = budgetHistory.FirstOrDefault(b => b.GetDate().Month == transactionDate.Month && b.GetDate().Year == transactionDate.Year);

                if (currentBudget != null)
                {
                    // Checking if applying the difference would exceed the remaining budget........
                    double newRemainingBudget = currentBudget.GetremainingBudget() - amountDifference;

                    if (newRemainingBudget >= 0)
                    {
                        transaction.SetTransactionAmount(newAmount);

                        currentBudget.SetremainingBudget(newRemainingBudget);
                        Category cat = categoryList.FirstOrDefault(s => s.transactionList.Any(t => t.GetTransactionNbr() == transactionId));
                        if (cat != null)
                        {
                            TrackBudgetByCategory(cat.GetCategoryLabel(), transactionDate);
                        }
                        
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Modifying this transaction would exceed the remaining budget for this month.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("No budget found for the month of the transaction. Cannot modify the transaction amount.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Transaction not found.");
                return false;
            }
        }

        public bool MoveTransaction(string transactionId, string newCategoryLabel)
        {
            var originalCategory = categoryList.FirstOrDefault(cat => cat.transactionList.Any(tran => tran.GetTransactionNbr().ToLower() == transactionId.ToLower()));
            if (originalCategory == null)
            {
                Console.WriteLine("Original category not found.");
                return false; 
            }

            var transaction = originalCategory.transactionList.FirstOrDefault(tran => tran.GetTransactionNbr().ToLower() == transactionId.ToLower());
            if (transaction == null)
            {
                Console.WriteLine("Transaction not found.");
                return false; 
            }

            var newCategory = categoryList.FirstOrDefault(cat => cat.GetCategoryLabel().ToLower() == newCategoryLabel.ToLower());
            if (newCategory == null)
            {
                Console.WriteLine("New category not found.");
                return false; 
            }

            if (originalCategory.GetIsExpense() == newCategory.GetIsExpense())
            {
                originalCategory.transactionList.Remove(transaction);
                newCategory.transactionList.Add(transaction);
                return true;
            }
            else
            {
                Console.WriteLine("Category Types are not same. Cannot move transaction between Income and Expencse type");
            }

            return false;
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
                    string recuring;
                    if (transaction.GetIsMonthlyRecurring() == true)
                    {
                        recuring = "Yes";
                    }
                    else
                    {
                        recuring = "No";
                    }

                    Console.WriteLine($"---Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate().ToString("dd/MM/yyyy")}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}, Monthly Recurring: {recuring}");
                }
            }
        }

        public void DisplayCategoryTransactions(string label, DateTime date)
        {
            Category category = categoryList.Where(s => s.GetCategoryLabel().ToLower() == label.ToLower() & s.GetCategoryDate().Month == date.Month && s.GetCategoryDate().Year==date.Year).FirstOrDefault();
            
            
            Console.WriteLine($"Category Name: {category.GetCategoryLabel()}, Month: {date.Month}-{date.Year}");
            foreach (var transaction in category.transactionList)
            {
                string recuring;
                if (transaction.GetIsMonthlyRecurring() == true)
                {
                    recuring = "Yes";
                }
                else
                {
                    recuring = "No";
                }

                Console.WriteLine($"---Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate().ToString("dd/MM/yyyy")}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}, Monthly Recurring: {recuring}");
            }
        }

        public void DisplayAllPastTransactions()
        {
            foreach (var category in categoryList)
            {
                Console.WriteLine($"Category Name: {category.GetCategoryLabel()}");
                Console.WriteLine($"  Month: {category.GetCategoryDate().Month}/{category.GetCategoryDate().Year}");
                foreach (var transaction in category.transactionList)
                {
                    string recuring;
                    if (transaction.GetIsMonthlyRecurring() == true)
                    {
                        recuring = "Yes";
                    }
                    else
                    {
                        recuring = "No";
                    }
                    
                    Console.WriteLine($"    Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate().ToString("dd/MM/yyyy")}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}, Monthly Recurring: {recuring}");
                }
            }
        }
        
        public void DisplayPastCategoryTransaction(string label)
        {
            List<Category> currentCategoryList = categoryList.Where(s => s.GetCategoryLabel().ToLower() == label.ToLower()).ToList();

            foreach (var category in currentCategoryList)
            {
                Console.WriteLine($"Category Name: {category.GetCategoryLabel()}");
                foreach (var transaction in category.transactionList)
                {
                    string recuring;
                    if (transaction.GetIsMonthlyRecurring() == true)
                    {
                        recuring = "Yes";
                    }
                    else
                    {
                        recuring = "No";
                    }

                    Console.WriteLine($"---Transaction info: {transaction.GetTransactionNbr()},Date:{transaction.GetTransactionDate().ToString("dd/MM/yyyy")}, Amount:{transaction.GetTransactionAmount()},Note:{transaction.GetTransactionDescription()}, Monthly Recurring: {recuring}");
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

        //name cahnged from TrackBudget
        public void TrackBudgetByCategory(string catLabel, DateTime monthYear)
        {
            Category category = categoryList.Where(e => e.GetCategoryLabel().ToLower() == catLabel.ToLower() & e.GetCategoryDate().Month == monthYear.Month & e.GetCategoryDate().Year == monthYear.Year).FirstOrDefault();

            if (category == null) 
            {
                Console.WriteLine($"No category found for {catLabel} in {monthYear.ToString("MM/yyyy")}.");
                return;
            }

            double totalSpent = category.transactionList.Where(tr => tr.GetTransactionAmount() > 0)
                                                 .Sum(tr => tr.GetTransactionAmount());

            // Compare the total spent against the budget
            if (category.GetCategoryBudget()>0 & totalSpent > category.GetCategoryBudget() )
            {
                Console.WriteLine($"<Warning>: You have exceeded your budget for {category.GetCategoryLabel()} in {monthYear.ToString("MM/yyyy")}. Budget: {category.GetCategoryBudget()}, Spent: {totalSpent}");
            }
            else
            {
                Console.WriteLine($"For {category.GetCategoryLabel()} in {monthYear.ToString("MM/yyyy")}, you have spent {totalSpent} out of your budget of {category.GetCategoryBudget()}.");
            }
        }


        public void TrackOverallBudget(DateTime monthYear)
        {
            double totalBudget = budgetHistory.Where(s=>s.GetDate().Month==monthYear.Month && s.GetDate().Year==monthYear.Year).Select(b=>b.GetBudget()).FirstOrDefault();
            double totalExpenses = 0;
            double totalIncome = 0;

            var filteredCategories = categoryList
                                     .Where(c => c.GetCategoryDate().Year == monthYear.Year &&
                                                 c.GetCategoryDate().Month == monthYear.Month)
                                     .ToList();
            Console.WriteLine($"__________ Budget and Expenses for {monthYear:MM/yyyy} __________");

            foreach (var category in filteredCategories.Where(s=>s.GetIsExpense()==true))
            {
                double categoryBudget = category.GetCategoryBudget();
                double categoryExpenses = category.transactionList
                                          .Sum(t => t.GetTransactionAmount());
                totalExpenses += categoryExpenses;

                Console.WriteLine($"Category: {category.GetCategoryLabel()}, Budget: {categoryBudget}, Expenses: {categoryExpenses}");
            }

            Console.WriteLine($"Total Budget: {totalBudget}, Total Expenses: {totalExpenses}");

            double remainingBudget = totalBudget - totalExpenses;
            Console.WriteLine($"Remaining Budget: {remainingBudget}");

            Console.WriteLine($"__________ Income for {monthYear:MM/yyyy} __________");
            foreach (var category in filteredCategories.Where(s => s.GetIsExpense() == false))
            {
                double categoryIncome = category.transactionList
                                          .Sum(t => t.GetTransactionAmount());
                totalIncome += categoryIncome;

                Console.WriteLine($"Category: {category.GetCategoryLabel()}, Income: {totalIncome}");
            }
            Console.WriteLine($"Total Income: {totalIncome}");

        }

        public bool ApplyRepeatingTransactions()
        {
            DateTime fromMonthYear = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1).AddMonths(-1); 
            DateTime toMonthYear = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            Budget budget = budgetHistory.FirstOrDefault(b => b.GetDate().Month == toMonthYear.Month && b.GetDate().Year == toMonthYear.Year);

            if (budget == null)
            {
                Console.WriteLine("You need to set Monthly budget first for any transaction");
                return false;
            }

            foreach (var category in categoryList.Where(c => c.GetCategoryDate().Month == fromMonthYear.Month && c.GetCategoryDate().Year == fromMonthYear.Year))
            {
                var recurringTransactions = category.transactionList.Where(t => t.GetIsMonthlyRecurring()).ToList();

                // Duplicate each recurring transaction for the new month.
                foreach (var transaction in recurringTransactions)
                {
                    Transaction newTransaction = new Transaction(
                        Helper.GenerateTransactionNo(),
                        transaction.GetTransactionAmount(),
                        new DateTime(toMonthYear.Year, toMonthYear.Month, Math.Min(DateTime.DaysInMonth(toMonthYear.Year, toMonthYear.Month), transaction.GetTransactionDate().Day)), 
                        transaction.GetTransactionDescription(),
                        true 
                    );

                    var newMonthCategory = categoryList.FirstOrDefault(c =>
                        c.GetCategoryLabel().Equals(category.GetCategoryLabel(), StringComparison.OrdinalIgnoreCase) &&
                        c.GetCategoryDate().Month == toMonthYear.Month &&
                        c.GetCategoryDate().Year == toMonthYear.Year);

                    if (newMonthCategory == null)
                    {
                        newMonthCategory = new Category(
                            category.GetCategoryLabel(),
                            0, 
                            new DateTime(toMonthYear.Year, toMonthYear.Month, 1),
                            category.GetIsExpense() 
                        );
                        categoryList.Add(newMonthCategory);
                    }

                    newMonthCategory.transactionList.Add(newTransaction);
                }
            }

            return true; 
        }


    }

}
