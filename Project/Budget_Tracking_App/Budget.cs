using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Budget
    {
        private double sum_to_allocate;
        private double _remaining_budget;
        private DateTime date;

        public double SumToAllocate
        {
            get { return sum_to_allocate; }
            set { sum_to_allocate = value; }
        }

        public double RemainingBudget
        {
            get { return _remaining_budget; }
            set { _remaining_budget = value; }
        }

        public DateTime Date
        {
            get { return date; }
            set { date = value; }
        }

        public void SetBudget(double amount)
        {
             
        }

        public void SetDate(DateTime date)
        {
             
        }

        public double GetBudget()
        {
             
            return 0.0;
        }

        public DateTime GetBudgetDate()
        {
             
            return new DateTime();
        }

        public bool CreateCategory(string label)
        {
             
            return true;
        }
    }
}
