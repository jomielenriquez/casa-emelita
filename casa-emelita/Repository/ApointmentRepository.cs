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
        public List<Reservations> GetReservation()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_ORDER> result = entities.TBL_ORDER.ToList();

            List<Reservations> reservations = new List<Reservations>();
            foreach (TBL_ORDER order in result)
            {
                reservations.Add(new Reservations()
                {
                    Package = order.TBL_PACKAGE.PACKAGECODE 
                        + "<br>" + order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME 
                        + "<br>" + order.TBL_PACKAGE.INCLUSIONSDESCRIPTION
                        + "<br> good for" + order.TBL_PACKAGE.ACCOMODATION
                        + "<br> P " + order.TBL_PACKAGE.PRICE,
                    Packageid = order.TBL_PACKAGE.PACKAGEID,
                    Customer = order.CUSTOMERNAME
                        + "<br>" + order.CUSTOMEREMAIL
                        + "<br>" + order.CUSTOMERCONTACTNUMVER
                        + "<br>" + order.CUSTOMERADDRESS,
                    EventDate = order.EVENTDATE.ToString()
                        + "<br>" + order.SLOT,
                    Status = order.TBL_ORDER_STATUS.ORDERSTATUSNAME

                });
            }

            return reservations;

        }
    }
    public class Reservations
    {
        public string Package { get; set; }
        public Guid Packageid { get; set; }
        public string Customer { get; set; }
        public string EventDate { get; set; }
        public string Status { get; set; }
    }
}