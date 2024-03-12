using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    class Program
    {
        static void Main(string[] args)
        {
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
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View");
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
                    Console.WriteLine("Transaction create function called");
                }
                else if (subChoice == 2)
                {
                    Console.WriteLine("Transaction Update function called");
                }
                else if (subChoice == 3)
                {
                    Console.WriteLine("Transaction Delete function called");
                }
                else if (subChoice == 4)
                {
                    Console.WriteLine("Transaction View function called");
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
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View");
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
                    Console.WriteLine("Category create function called");
                }
                else if (subChoice == 2)
                {
                    Console.WriteLine("Category Update function called");
                }
                else if (subChoice == 3)
                {
                    Console.WriteLine("Category Delete function called");
                }
                else if (subChoice == 4)
                {
                    Console.WriteLine("Category View function called");
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
                Console.WriteLine("2. Update");
                Console.WriteLine("3. Delete");
                Console.WriteLine("4. View");
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
                    Console.WriteLine("Budget create function called");
                }
                else if (subChoice == 2)
                {
                    Console.WriteLine("Budget Update function called");
                }
                else if (subChoice == 3)
                {
                    Console.WriteLine("Budget Delete function called");
                }
                else if (subChoice == 4)
                {
                    Console.WriteLine("Budget View function called");
                }
                ContinuePrompt();
            }
        }

        static void ContinuePrompt()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

}
