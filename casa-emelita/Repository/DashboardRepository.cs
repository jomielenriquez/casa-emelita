using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class DashboardRepository
    {
        public List<GraphData> MontlyReservations(int year, List<AvailableMonths> Months)
        {
            List<GraphData> returnValue = new List<GraphData>();
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            foreach(var month in Months)
            {
                DateTime from = new DateTime(year, month.value, 1, 0, 0, 0);
                DateTime to = new DateTime(month.value == 12 ? year + 1 : year, month.value == 12 ? 1 : month.value + 1, 1, 0, 0, 0);

                from = DateTime.ParseExact(from.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
                to = DateTime.ParseExact(to.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

                int count = entities.TBL_ORDER
                    .Where(ord => ord.EVENTDATE >= from && ord.EVENTDATE < to && ord.TBL_ORDER_TYPE.ORDERNAME.Equals("RESERVATION", StringComparison.OrdinalIgnoreCase))
                    .ToList().Count();

                returnValue.Add(new GraphData()
                {
                    y = count,
                    label = month.Text
                });
            }

            return returnValue;
        }
        public List<GraphData> MostOrderedPackage(List<TBL_PACKAGE> packages, int year)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<GraphData> returnValue = new List<GraphData>();

            DateTime from = new DateTime(year, 1, 1, 0, 0, 0);
            DateTime to = new DateTime(year + 1, 1, 1, 0, 0, 0);

            from = DateTime.ParseExact(from.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            to = DateTime.ParseExact(to.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            foreach (var package in packages)
            {
                int count = entities.TBL_ORDER
                    .Where(ord => ord.EVENTDATE >= from && ord.EVENTDATE < to && ord.PACKAGEID == package.PACKAGEID)
                    .ToList().Count();

                returnValue.Add(new GraphData() { 
                    y = count,
                    label = package.PACKAGENAME
                });
            }

            return returnValue;
        }
    }
    public class GraphData
    {
        public int y { get; set; }
        public string label { get; set; }
    }
}