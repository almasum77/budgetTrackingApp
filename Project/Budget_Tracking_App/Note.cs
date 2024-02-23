using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budget_Tracking_App
{
    public class Note
    {
        public string Detail { get;  set; }

        public void SetDetail(string description)
        {
            Detail = description;
        }

        public string GetDetail()
        {
            return Detail;
        }
    }
}
