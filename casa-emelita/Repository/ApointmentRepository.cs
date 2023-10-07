using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class ApointmentRepository
    {
        public List<string> GetAppointmentsWithDate(DateTime reservationDate)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            DateTime enddate = reservationDate.AddDays(1);
            reservationDate = DateTime.ParseExact(reservationDate.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            enddate = DateTime.ParseExact(enddate.ToString(), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            var appointments = entities.TBL_ORDER
                .Where(a => a.EVENTDATE >= reservationDate && a.EVENTDATE < enddate)
                .Select(a => a.SLOT)
                .ToList();

            return appointments;
        }
    }
}