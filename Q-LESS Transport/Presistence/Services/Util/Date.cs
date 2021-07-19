using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Q_LESS_Transport.Presistence.Services.Util
{
    public class Date
    {
        public static DateTime StrToDateTime(DateTime date)
        {
            string strDate = date.ToString("MM/dd/yyyy");
            DateTime dateTime = DateTime.Parse(strDate);

            return dateTime;
        }
    }
}
