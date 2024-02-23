using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App.Interface
{
    public interface ICategory
    {
        void SetCategoryLabel(string label);
        void SetCategoryBudget(double amount);
        void SetOpeningDate(DateTime openingDate);
        void SetClosingDate(DateTime closingDate);

        string GetCategoryLabel();
        DateTime GetOpeningDate();
        DateTime GetClosingDate();
        Budget GetCategoryBudget();
        double GetCategoryBalance();
    }
}
