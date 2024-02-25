using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Category : ICategory
    {
        public string CategoryLabel { get; set; }
        public DateTime? OpeningDate { get; set; }
        public DateTime? ClosingDate { get; set; }
        public double BudgetAllocated { get; set; }
        public List<Transaction> TransactionList { get; set; }

        public Category()
        {
            TransactionList = new List<Transaction>();
        }

        public void SetCategoryLabel(string label)
        {
            CategoryLabel = label;
        }

        public void SetCategoryBudget(double amount)
        {
            BudgetAllocated = amount;
        }

        public void SetOpeningDate(DateTime openingDate)
        {
            OpeningDate = openingDate;
        }

        public void SetClosingDate(DateTime closingDate)
        {
            ClosingDate = closingDate;
        }

        public string GetCategoryLabel()
        {
            return CategoryLabel;
        }

        public DateTime? GetOpeningDate()
        {
            return OpeningDate;
        }

        public DateTime? GetClosingDate()
        {
            return ClosingDate;
        }

        public double GetCategoryBudget()
        {
            return BudgetAllocated;
        }

        public double GetCategoryBalance()
        {

            return 0.0;
        }

        DateTime ICategory.GetOpeningDate()
        {
            throw new NotImplementedException();
        }

        DateTime ICategory.GetClosingDate()
        {
            throw new NotImplementedException();
        }

        Budget ICategory.GetCategoryBudget()
        {
            throw new NotImplementedException();
        }
    }
}
