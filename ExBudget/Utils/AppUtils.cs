using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExBudget.Utils
{
    public class AppUtils
    {
        public static void AddErrorMessage(ref string errorMessage, string msg)
        {
            if (string.IsNullOrEmpty(errorMessage.Trim()))
            {
                errorMessage += msg;
            }
            else
            {
                errorMessage += $"\n{msg}";
            }
        }
    }
}
