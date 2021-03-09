using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ATM_Transections
{
    public class ChangeColor
    {
        #region ChangeColor
        public static string RedOrGreen(int Number)
        {
            string Check = string.Empty;

            if (Convert.ToInt32(Number) > 0)
                Check = "green";
            else
                Check = "red";

            return Check;
        }
        #endregion ChangeColor
    }
}