using Budget_Tracking_App.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{

    public class Budget : IBudgetAvailable
    {
        private double sumToAllocate;
        private double categoryBudget;
        private DateTime monthAndYear;

        public Budget(double sumToAllocate, double categoryBudget, DateTime monthAndYear)
        {
            this.sumToAllocate = sumToAllocate;
            this.categoryBudget = categoryBudget;
            this.monthAndYear = monthAndYear;
        }

        public void SetBudget(double amount)
        {
            sumToAllocate = amount;
        }

        public void SetCategoryBudget(double amount)
        {
            categoryBudget = amount;
        }

        public void SetDate(DateTime date)
        {
            monthAndYear = date;
        }

        public double GetBudget()
        {
            return sumToAllocate;
        }

        public double GetCategoryBudget()
        {
            return categoryBudget;
        }

        public DateTime GetDate()
        {
            return monthAndYear;
        }

        public bool IsBudgetAvailable(double amount)
        {
            throw new NotImplementedException();
        }

        // Any other methods and business logic goes here
    }

}
