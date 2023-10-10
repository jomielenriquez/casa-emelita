using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class OrderRepository
    {
        public List<TBL_ORDER> GetOrdersWithDateRange(DateTime firstdate, DateTime lastdate)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            lastdate = lastdate.AddDays(1);
            firstdate = DateTime.ParseExact(firstdate.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            lastdate = DateTime.ParseExact(lastdate.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            return entities.TBL_ORDER
                .Where(order => order.EVENTDATE >= firstdate && order.EVENTDATE < lastdate)
                .ToList();
        }
    }
}