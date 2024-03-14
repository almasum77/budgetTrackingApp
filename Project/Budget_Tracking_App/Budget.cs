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
        public  double remainingBudget;
        private DateTime monthAndYear;

        public Budget(double sumToAllocate, DateTime monthAndYear)
        {
            this.sumToAllocate = sumToAllocate;
            this.remainingBudget = sumToAllocate;
            this.monthAndYear = monthAndYear;
        }

        public void SetBudget(double amount)
        {
            sumToAllocate = amount;
        }

        public void SetremainingBudget(double amount)
        {
            remainingBudget = amount;
        }

        public void SetDate(DateTime date)
        {
            monthAndYear = date;
        }

        public double GetBudget()
        {
            return sumToAllocate;
        }

        public double GetremainingBudget()
        {
            return remainingBudget;
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
