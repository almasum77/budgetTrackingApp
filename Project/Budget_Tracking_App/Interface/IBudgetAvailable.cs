using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App.Interface
{
    public interface IBudgetAvailable
    {
        bool IsBudgetAvailable(double amount);
    }
}
