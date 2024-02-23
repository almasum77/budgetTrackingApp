using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Menu
    {
        private Wallet wallet;

        public Menu()
        {
            wallet = new Wallet();
        }

        public void DisplayMainMenu()
        {
            while (true)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. View Balance");
                Console.WriteLine("4. Set Monthly Budget");
                Console.WriteLine("5. View Categories");
                Console.WriteLine("6. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddTransaction();
                        break;
                    case "2":
                        ViewTransactions();
                        break;
                    case "3":
                        ViewBalance();
                        break;
                    case "4":
                        SetMonthlyBudget();
                        break;
                    case "5":
                        ViewCategories();
                        break;
                    case "6":
                        Console.WriteLine("Exiting...");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        private void AddTransaction()
        {
            Console.Write("Enter transaction amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter transaction description: ");
            string description = Console.ReadLine();
            Console.Write("Enter transaction category: ");
            string category = Console.ReadLine();
            //wallet.AddTransaction(amount, description, category);
            Console.WriteLine("Transaction added successfully!");
        }

        private void ViewTransactions()
        {
            //wallet.ViewTransactions();
        }

        private void ViewBalance()
        {
            //wallet.ViewBalance();
        }

        private void SetMonthlyBudget()
        {
            Console.Write("Enter monthly budget amount: ");
            double monthlyBudget = Convert.ToDouble(Console.ReadLine());
            //wallet.SetMonthlyBudget(monthlyBudget);
            Console.WriteLine("Monthly budget set successfully!");
        }

        private void ViewCategories()
        {
            //wallet.ViewCategories();
        }
    }
}
