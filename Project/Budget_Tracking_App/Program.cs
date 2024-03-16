using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    class Program
    {
        private static Wallet wallet = new Wallet();
        static void Main(string[] args)
        {
            InitializePresetCategories();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1. Transaction");
                Console.WriteLine("2. Category");
                Console.WriteLine("3. Budget");
                Console.WriteLine("4. Exit");
                Console.Write("\nSelect an option (1-4): ");

                if (!int.TryParse(Console.ReadLine(), out int mainChoice) || mainChoice < 1 || mainChoice > 4)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    ContinuePrompt();
                    continue;
                }

                if (mainChoice == 4) break; // Exit the program

                switch (mainChoice)
                {
                    case 1:
                        TransactionSubMenu();
                        break;
                    case 2:
                        CategorySubMenu();
                        break;
                    case 3:
                        BudgetSubMenu();
                        break;
                }
            }
        }

        static void TransactionSubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Transaction Menu:");
                Console.WriteLine("1. Create ");
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Move Transaciton to another Category");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. Display All Ongoing Transactions"); 
                Console.WriteLine("6. Display Category-wise Transactions");
                Console.WriteLine("7. Display All Past Transactions");
                Console.WriteLine("8. Display Past Category-wise Transactions");
                Console.WriteLine("9. Close And Reopen Category For The New Month");

                Console.WriteLine("10. Return to Main Menu");
                Console.Write("\nSelect an option (1-10): ");

                if (!int.TryParse(Console.ReadLine(), out int subChoice) || subChoice < 1 || subChoice > 10)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    ContinuePrompt();
                    continue;
                }

                if (subChoice >= 10) break; // Return to Main Menu
                else if (subChoice == 1)
                {
                    //Console.WriteLine("Transaction create function called");
                    AddTransactionFromInput();
                }
                else if (subChoice == 2)
                {
                   //Console.WriteLine("Transaction Update function called");
                    ModifyTransactionAmountFromInput();
                }
                else if (subChoice == 3)
                {
                    //Console.WriteLine("Transaction move function called");
                    MoveTransactionFromInput();
                }
                else if (subChoice == 4)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    RemoveTransactionFromInput();
                }
                else if (subChoice == 5)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    DisplayAllOngoingTransactionsFromInput();
                }
                else if (subChoice == 6)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    DisplayCategoryTransactionsFromInput();
                }
                else if (subChoice == 7)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    DisplayAllPastTransactionsFromInput();
                }
                else if (subChoice == 8)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    DisplayPastCategoryTransactionsFromInput();
                }
                else if (subChoice == 9)
                {
                    //Console.WriteLine("Transaction Delete function called");
                    CloseAndOpenCategoriesFromInput();
                }
                ContinuePrompt();
            }
        }
        static void CategorySubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Category Menu:");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Rename Category Label");
                Console.WriteLine("3. Update Category Budget");
                Console.WriteLine("4. Delete");
                Console.WriteLine("5. View");
                Console.WriteLine("6. Return to Main Menu");
                Console.Write("\nSelect an option (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out int subChoice) || subChoice < 1 || subChoice > 6)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    ContinuePrompt();
                    continue;
                }

                if (subChoice >= 6) break; 
                else if (subChoice == 1)
                {
                    //Console.WriteLine("Category create function called");
                    CreateCategoryFromInput();
                }
                else if (subChoice == 2)
                {
                    //Console.WriteLine("Category Rename function called");
                    RenameCategoryFromInput();
                }
                else if (subChoice == 3)
                {
                    //Console.WriteLine("Category Delete function called");
                    UpdateCategoryBudgetFromInput();
                }
                else if (subChoice == 4)
                {
                    //Console.WriteLine("Category Delete function called");
                    RemoveCategoryFromInput();
                }
                else if (subChoice == 5)
                {
                    //Console.WriteLine("Category View function called");
                    DisplayCategoriesFromInput();
                }
                ContinuePrompt();
            }
        }
        static void BudgetSubMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Budget Menu:");
                Console.WriteLine("1. Create");
                Console.WriteLine("2. Delete");
                Console.WriteLine("3. Allocate Budget To Category");
                Console.WriteLine("4. Check Budget");
                Console.WriteLine("5. Return to Main Menu");
                Console.Write("\nSelect an option (1-5): ");

                if (!int.TryParse(Console.ReadLine(), out int subChoice) || subChoice < 1 || subChoice > 5)
                {
                    Console.WriteLine("Invalid choice, please try again.");
                    ContinuePrompt();
                    continue;
                }

                if (subChoice >= 5) break; // Return to Main Menu
                else if (subChoice == 1)
                {
                    //Console.WriteLine("Budget create function called");
                    CreateBudgetFromInput();
                }
                else if (subChoice == 2)
                {
                    //Console.WriteLine("Budget Delete function called");
                    RemoveBudgetFromInput();
                    
                }
                else if (subChoice == 3)
                {
                    //Console.WriteLine("Allocate Budget To Category function called");
                    AllocateBudgetToCategoryFromInput();
                }
                else if (subChoice == 4)
                {
                    //Console.WriteLine("Budget View function called");
                    ViewBudgetByDate();
                }

                ContinuePrompt();
            }
        }

        static void ContinuePrompt()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static void InitializePresetCategories()
        {
            var currentDate = DateTime.Now;
            var monthAndYear = new DateTime(currentDate.Year, currentDate.Month, 1);

            // Preset categories for current month....
            var presetCategories = new List<Category>
        {
            new Category("Food", 0, monthAndYear),
            new Category("Transportation", 0, monthAndYear),
            new Category("Entertainment", 0, monthAndYear),
            new Category("Bills", 0, monthAndYear)
        };

            foreach (var category in presetCategories)
            {
                wallet.CreateCategory(category);
            }
        }

        #region Category
        static void CreateCategoryFromInput()
        {
            Console.WriteLine("Enter category label:");
            string label = Console.ReadLine();

            Console.WriteLine("Enter budget allocated for this category (optional):");
            string budgetInput = Console.ReadLine();
            if (!double.TryParse(budgetInput, out double budgetAllocated))
            {
                //Console.WriteLine("Invalid budget format. Please enter a valid number.");
                budgetAllocated = 0;
                //return;
            }

            Console.WriteLine("Enter month and year for the category (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();

            if (DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Category newCategory = new Category(label, budgetAllocated, monthYear);
                if (wallet.CreateCategory(newCategory))
                {
                    Console.WriteLine("Category created successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to create category.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }
        static void RenameCategoryFromInput()
        {

            Console.WriteLine("Enter the Month and Year for the category you wish to rename (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            DateTime monthYear;

            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out monthYear))
            {
                Console.WriteLine("Invalid date format. Please use MM/yyyy format.");
                return;
            }

            Console.WriteLine($"Current categories for {monthYear.ToString("MM/yyyy")}:");
            wallet.DisplayCategories(monthYear);

            // Asking for the old label
            Console.WriteLine("Enter the label of the category you wish to rename:");
            string oldLabel = Console.ReadLine();

            // Asking for the new label
            Console.WriteLine("Enter the new label for the category:");
            string newLabel = Console.ReadLine();

            if (wallet.RenameCategory(oldLabel, newLabel, monthYear))
            {
                Console.WriteLine("Category renamed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to rename category. Make sure it exists and you entered the correct date.");
            }
        }
        static void UpdateCategoryBudgetFromInput()
        {
            Console.WriteLine("Enter the category label:");
            string label = Console.ReadLine();

            Console.WriteLine("Enter the month and year for the category (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Console.WriteLine("Invalid date format.");
                return;
            }

            Console.WriteLine("Enter the new budget allocated for this category:");
            if (!double.TryParse(Console.ReadLine(), out double newBudget))
            {
                Console.WriteLine("Invalid budget format. Please enter a valid number.");
                return;
            }

            if (wallet.UpdateCategoryBudget(label, monthYear, newBudget))
            {
                Console.WriteLine($"Budget updated successfully for category '{label}' for the period {monthYearInput}.");
            }
            else
            {
                Console.WriteLine("Failed to update budget. Category not found.");
            }
        }

        public static void RemoveCategoryFromInput()
        {
            Console.WriteLine("Enter the label of the category you want to remove:");
            string label = Console.ReadLine();

            Console.WriteLine("Enter the month and year of the category to remove (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();

            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Console.WriteLine("Invalid date format. Please use MM/yyyy format.");
                return;
            }

            // Assuming 'wallet' is your static Wallet instance accessible from here
            bool isRemoved = wallet.RemoveCategory(label, monthYear);
            if (isRemoved)
            {
                Console.WriteLine("Category successfully removed.");
            }
            else
            {
                Console.WriteLine("Category not found or could not be removed.");
            }
        }
        public static void DisplayCategoriesFromInput()
        {
            Console.WriteLine("Enter the month and year to display categories (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();

            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Console.WriteLine("Invalid date format. Please use MM/yyyy format.");
                return;
            }
            wallet.DisplayCategories(monthYear);
        }

        #endregion

        #region Budget
        static void CreateBudgetFromInput()
        {
            Console.WriteLine("Enter the total sum to allocate for the budget:");
            string sumInput = Console.ReadLine();
            if (!double.TryParse(sumInput, out double sumToAllocate))
            {
                Console.WriteLine("Invalid sum format. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter month and year for the budget (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            if (DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Budget newBudget = new Budget(sumToAllocate, monthYear);
                if (wallet.AddBudget(newBudget))
                {
                    Console.WriteLine("Budget added successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to add budget.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please follow the MM/yyyy format.");
            }
        }
        static void RemoveBudgetFromInput()
        {
            Console.WriteLine("Enter month and year of the budget to remove (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            if (DateTime.TryParseExact(monthYearInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime monthYear))
            {
                Budget budgetToRemove = wallet.GetBudgetByDate(monthYear);
                if (budgetToRemove != null)
                {
                    if (wallet.RemoveBudget(budgetToRemove))
                    {
                        Console.WriteLine("Budget removed successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Failed to remove budget.");
                    }
                }
                else
                {
                    Console.WriteLine($"No budget found for {monthYear.ToString("MM/yyyy")}");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format. Please follow the MM/yyyy format.");
            }
        }
        static void AllocateBudgetToCategoryFromInput()
        {
            Console.WriteLine("Enter the label of the category to allocate budget to:");
            string categoryLabel = Console.ReadLine();

            Console.WriteLine("Enter the amount to allocate:");
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid amount format. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter the month and year for the category (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime monthYear))
            {
                Console.WriteLine("Invalid date format. Please follow the MM/yyyy format.");
                return;
            }

            if (wallet.AllocateBudgetToCategory(categoryLabel, amount, monthYear))
            {
                Console.WriteLine($"Budget of {amount} allocated to category '{categoryLabel}' for {monthYear.ToString("MM/yyyy")}.");
            }
            else
            {
                Console.WriteLine("Failed to allocate budget. Make sure the category exists and the date is correct.");
            }
        }
        static void ViewBudgetByDate()
        {
            Console.WriteLine("Enter the month and year to view the budget (format MM/yyyy):");
            string monthYearInput = Console.ReadLine();
            DateTime monthYear;
            if (!DateTime.TryParseExact(monthYearInput, "MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out monthYear))
            {
                Console.WriteLine("Invalid date format. Please follow the MM/yyyy format.");
                return;
            }

            Budget budget = wallet.GetBudgetByDate(monthYear);
            if (budget != null)
            {
                Console.WriteLine($"Budget for {monthYear.ToString("MM/yyyy")}:");
                Console.WriteLine($"- Amount allocated: {budget.GetBudget()}");
                Console.WriteLine($"- Remaining budget: {budget.GetremainingBudget()}");
            }
            else
            {
                Console.WriteLine("No budget found for the specified month and year.");
            }
        }
        #endregion

        #region Transaction
        static void AddTransactionFromInput()
        {
            Console.WriteLine("Enter the label of the category for the transaction:");
            string catLabel = Console.ReadLine();

            Console.WriteLine("Enter the amount of the transaction:");
            if (!double.TryParse(Console.ReadLine(), out double amount))
            {
                Console.WriteLine("Invalid amount. Please enter a valid number.");
                return;
            }

            Console.WriteLine("Enter the date of the transaction (format dd/MM/yyyy):");
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date format. Please follow the dd/MM/yyyy format.");
                return;
            }

            Console.WriteLine("Enter a description for the transaction or you can skip:");
            string description = Console.ReadLine();

            // Generate a transaction number
            string transactionNo = Helper.GenerateTransactionNo();

            Transaction newTransaction = new Transaction(transactionNo, amount, date, description);

            if (wallet.AddTransaction(newTransaction, catLabel))
            {
                Console.WriteLine($"Transaction added successfully. Transaction number: {transactionNo}");
            }
            else
            {
                //Console.WriteLine("Failed to add transaction. Make sure the category exists.");
            }
        }
        static void ModifyTransactionAmountFromInput()
        {
            Console.WriteLine("Enter the transaction ID:");
            string transactionId = Console.ReadLine();

            Console.WriteLine("Enter the new amount for the transaction:");
            if (!double.TryParse(Console.ReadLine(), out double newAmount))
            {
                Console.WriteLine("Invalid amount format. Please enter a valid number.");
                return;
            }

            if (wallet.ModifyTransactionAmount(transactionId, newAmount))
            {
                Console.WriteLine("Transaction amount updated successfully.");
            }
            else
            {
                Console.WriteLine("Failed to update transaction amount. Make sure the transaction ID is correct.");
            }
        }
        static void MoveTransactionFromInput()
        {
            Console.WriteLine("Enter the transaction ID you wish to move:");
            string transactionId = Console.ReadLine();

            Console.WriteLine("Enter the label of the new category for this transaction:");
            string newCategoryLabel = Console.ReadLine();

            // Assuming you have a static wallet instance accessible in this context
            bool result = wallet.MoveTransaction(transactionId, newCategoryLabel);

            if (result)
            {
                Console.WriteLine("Transaction successfully moved to the new category.");
            }
            else
            {
                Console.WriteLine("Failed to move the transaction. Please check the inputs and try again.");
            }
        }
        static void RemoveTransactionFromInput()
        {
            Console.WriteLine("Enter the transaction ID you wish to remove:");
            string transactionId = Console.ReadLine();

            if (wallet.RemoveTransaction(transactionId))
            {
                Console.WriteLine("Transaction removed successfully.");
            }
            else
            {
                Console.WriteLine("Failed to remove transaction. Please ensure the transaction ID is correct.");
            }
        }
        static void DisplayAllOngoingTransactionsFromInput()
        {
            Console.WriteLine("Enter the date to view transactions (format dd/MM/yyyy):");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime currentDate))
            {
                Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                return;
            }

            Console.WriteLine($"Displaying all transactions for {currentDate.ToString("dd/MM/yyyy")}:");
            wallet.DisplayAllOngoingTransactions(currentDate);
        }
        static void DisplayCategoryTransactionsFromInput()
        {
            Console.WriteLine("Enter the label of the category:");
            string label = Console.ReadLine();

            Console.WriteLine("Enter the date for the category transactions (format dd/MM/yyyy):");
            string dateInput = Console.ReadLine();

            if (!DateTime.TryParseExact(dateInput, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime date))
            {
                Console.WriteLine("Invalid date format. Please enter the date in dd/MM/yyyy format.");
                return;
            }

            Console.WriteLine($"Displaying transactions for category '{label}' on {date.ToString("dd/MM/yyyy")}:");
            wallet.DisplayCategoryTransactions(label, date);
        }
        static void DisplayAllPastTransactionsFromInput()
        {
            Console.WriteLine("Displaying all past transactions:");
            wallet.DisplayAllPastTransactions();
        }
        static void DisplayPastCategoryTransactionsFromInput()
        {
            Console.WriteLine("Enter the label of the category to display past transactions:");
            string label = Console.ReadLine();

            Console.WriteLine($"Displaying past transactions for category: {label}");
            wallet.DisplayPastCategoryTransaction(label);
        }
        static void CloseAndOpenCategoriesFromInput()
        {
            Console.WriteLine("Enter the label of the category to close and reopen for the new month:");
            string catLabel = Console.ReadLine();

            Console.WriteLine("Enter the new month and year for the category (format MM/yyyy):");
            string newMonthInput = Console.ReadLine();

            if (DateTime.TryParseExact(newMonthInput, "MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime newMonth))
            {
                if (wallet.CloseAndOpenCategories(catLabel, newMonth))
                {
                    Console.WriteLine("Category closed for the current month and opened for the new month successfully.");
                }
                else
                {
                    Console.WriteLine("Failed to close and open category. Make sure the category exists.");
                }
            }
            else
            {
                Console.WriteLine("Invalid date format.");
            }
        }

        #endregion
    }

}
