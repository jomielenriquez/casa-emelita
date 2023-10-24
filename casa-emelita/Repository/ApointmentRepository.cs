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
            reservationDate = DateTime.ParseExact(reservationDate.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            enddate = DateTime.ParseExact(enddate.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);

            var appointments = entities.TBL_ORDER
                .Where(a => a.EVENTDATE >= reservationDate && a.EVENTDATE < enddate)
                .Select(a => a.SLOT)
                .ToList();

            return appointments;
        }
        public List<Reservations> GetReservation()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_ORDER> result = entities.TBL_ORDER
                .Where(ord => ord.TBL_ORDER_TYPE.ORDERNAME.Equals("RESERVATION", StringComparison.OrdinalIgnoreCase))
                .ToList();

            List<Reservations> reservations = new List<Reservations>();
            foreach (TBL_ORDER order in result)
            {
                reservations.Add(new Reservations()
                {
                    Package = order.TBL_PACKAGE.PACKAGECODE 
                        + "<br>" + order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME 
                        + "<br>" + order.TBL_PACKAGE.INCLUSIONSDESCRIPTION
                        + "<br> good for" + order.TBL_PACKAGE.ACCOMODATION
                        + "<br> P " + order.TBL_PACKAGE.PRICE.ToString("N2"),
                    Packageid = order.TBL_PACKAGE.PACKAGEID,
                    Customer = order.CUSTOMERNAME
                        + "<br>" + order.CUSTOMEREMAIL
                        + "<br>" + order.CUSTOMERCONTACTNUMVER
                        + "<br>" + order.CUSTOMERADDRESS,
                    EventDate = order.EVENTDATE.ToString("MM/dd/yyyy")
                        + "<br>" + order.SLOT,
                    AppointmentDate = order.APPOINTMENTDATE.ToString("MM/dd/yyyy"),
                    Status = order.TBL_ORDER_STATUS.ORDERSTATUSNAME,
                    PackageCode = order.TBL_PACKAGE.PACKAGECODE,
                    EventName = order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME,
                    Inclusions = order.TBL_PACKAGE.INCLUSIONSDESCRIPTION,
                    Accomodation = order.TBL_PACKAGE.ACCOMODATION.ToString(),
                    Price = order.TBL_PACKAGE.PRICE.ToString("N2"),
                    DealPrice = (int)(order.DEALPRICE == null ? 0 : order.DEALPRICE),
                    CustomerName = order.CUSTOMERNAME,
                    CustomerAddress = order.CUSTOMERADDRESS,
                    CustomerNumber = order.CUSTOMERCONTACTNUMVER,
                    CustormerEmail = order.CUSTOMEREMAIL,
                    ReservationPrice = (int)order.TBL_PACKAGE.PRICE,
                    OrderID = order.ORDERID
                });
            }

            return reservations;
        }
        public List<Reservations> GetReservationWithDateRange(DateTime from, DateTime to)
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            from = DateTime.ParseExact(from.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            to = DateTime.ParseExact(to.ToString("MM/dd/yyyy hh:mm:ss tt"), "MM/dd/yyyy hh:mm:ss tt", CultureInfo.InvariantCulture);
            List<TBL_ORDER> result = entities.TBL_ORDER
                .Where(ord => ord.EVENTDATE >= from && ord.EVENTDATE <= to)
                .ToList();

            List<Reservations> reservations = new List<Reservations>();
            foreach (TBL_ORDER order in result)
            {
                reservations.Add(new Reservations()
                {
                    Package = order.TBL_PACKAGE.PACKAGECODE
                        + "<br>" + order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME
                        + "<br>" + order.TBL_PACKAGE.INCLUSIONSDESCRIPTION
                        + "<br> good for" + order.TBL_PACKAGE.ACCOMODATION
                        + "<br> P " + order.TBL_PACKAGE.PRICE.ToString("N2"),
                    Packageid = order.TBL_PACKAGE.PACKAGEID,
                    Customer = order.CUSTOMERNAME
                        + "<br>" + order.CUSTOMEREMAIL
                        + "<br>" + order.CUSTOMERCONTACTNUMVER
                        + "<br>" + order.CUSTOMERADDRESS,
                    EventDate = order.EVENTDATE.ToString()
                        + "<br>" + order.SLOT,
                    AppointmentDate = order.APPOINTMENTDATE.ToString("MM/dd/yyyy"),
                    Status = order.TBL_ORDER_STATUS.ORDERSTATUSNAME,
                    PackageCode = order.TBL_PACKAGE.PACKAGECODE,
                    EventName = order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME,
                    Inclusions = order.TBL_PACKAGE.INCLUSIONSDESCRIPTION,
                    Accomodation = order.TBL_PACKAGE.ACCOMODATION.ToString(),
                    Price = order.TBL_PACKAGE.PRICE.ToString("N2"),
                    DealPrice = (int)(order.DEALPRICE == null ? 0 : order.DEALPRICE),
                    CustomerName = order.CUSTOMERNAME,
                    CustomerAddress = order.CUSTOMERADDRESS,
                    CustomerNumber = order.CUSTOMERCONTACTNUMVER,
                    CustormerEmail = order.CUSTOMEREMAIL,
                    ReservationPrice = (int)order.TBL_PACKAGE.PRICE,
                    OrderID = order.ORDERID
                });
            }

            return reservations;
        }
        public List<Reservations> GetOrders()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_ORDER> result = entities.TBL_ORDER
                .Where(ord => ord.TBL_ORDER_TYPE.ORDERNAME.Equals("ORDER", StringComparison.OrdinalIgnoreCase)
                && !ord.TBL_ORDER_STATUS.ORDERSTATUSNAME.Equals("COMPLETED", StringComparison.OrdinalIgnoreCase)
                && !ord.TBL_ORDER_STATUS.ORDERSTATUSNAME.Equals("CANCELLED", StringComparison.OrdinalIgnoreCase))
                .OrderBy(ord => ord.CREATEDDATE)
                .ToList();

            List<Reservations> reservations = new List<Reservations>();
            foreach (TBL_ORDER order in result)
            {
                reservations.Add(new Reservations()
                {
                    //Package = order.TBL_PACKAGE.PACKAGECODE
                    //    + "<br>" + order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME
                    //    + "<br>" + order.TBL_PACKAGE.INCLUSIONSDESCRIPTION
                    //    + "<br> good for" + order.TBL_PACKAGE.ACCOMODATION
                    //    + "<br> P " + order.TBL_PACKAGE.PRICE.ToString("N2"),
                    //Packageid = order.TBL_PACKAGE.PACKAGEID,
                    Customer = order.CUSTOMERNAME
                        + "<br>" + order.CUSTOMEREMAIL
                        + "<br>" + order.CUSTOMERCONTACTNUMVER
                        + "<br>" + order.CUSTOMERADDRESS,
                    EventDate = order.EVENTDATE.ToString("MM/dd/yyyy")
                        + "<br>" + order.SLOT,
                    AppointmentDate = order.APPOINTMENTDATE.ToString("MM/dd/yyyy"),
                    Status = order.TBL_ORDER_STATUS.ORDERSTATUSNAME,
                    //PackageCode = order.TBL_PACKAGE.PACKAGECODE,
                    //EventName = order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME,
                    //Inclusions = order.TBL_PACKAGE.INCLUSIONSDESCRIPTION,
                    //Accomodation = order.TBL_PACKAGE.ACCOMODATION.ToString(),
                    //Price = order.TBL_PACKAGE.PRICE.ToString("N2"),
                    DealPrice = (int)(order.DEALPRICE == null ? 0 : order.DEALPRICE),
                    CustomerName = order.CUSTOMERNAME,
                    CustomerAddress = order.CUSTOMERADDRESS,
                    CustomerNumber = order.CUSTOMERCONTACTNUMVER,
                    CustormerEmail = order.CUSTOMEREMAIL,
                    //ReservationPrice = (int)order.TBL_PACKAGE.PRICE,
                    OrderID = order.ORDERID
                });
            }

            return reservations;
        }
        public List<Reservations> GetNotApprovedAppointments()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_ORDER> result = entities.TBL_ORDER
                .Where(Apmts => (Apmts.DEALPRICE == null || Apmts.DEALPRICE == 0) && Apmts.TBL_ORDER_TYPE.ORDERNAME.Equals("RESERVATION", StringComparison.OrdinalIgnoreCase))
                .OrderByDescending(apmts => apmts.EVENTDATE)
                .ToList();

            List<Reservations> reservations = new List<Reservations>();
            foreach (TBL_ORDER order in result)
            {
                reservations.Add(new Reservations()
                {
                    Package = order.TBL_PACKAGE.PACKAGECODE
                        + "<br>" + order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME
                        + "<br>" + order.TBL_PACKAGE.INCLUSIONSDESCRIPTION
                        + "<br> good for" + order.TBL_PACKAGE.ACCOMODATION
                        + "<br> P " + order.TBL_PACKAGE.PRICE.ToString("N2"),
                    Packageid = order.TBL_PACKAGE.PACKAGEID,
                    Customer = order.CUSTOMERNAME
                        + "<br>" + order.CUSTOMEREMAIL
                        + "<br>" + order.CUSTOMERCONTACTNUMVER
                        + "<br>" + order.CUSTOMERADDRESS,
                    EventDate = order.EVENTDATE.ToString("MM/dd/yyyy")
                        + "<br>" + order.SLOT,
                    AppointmentDate = order.APPOINTMENTDATE.ToString("MM/dd/yyyy"),
                    Status = order.TBL_ORDER_STATUS.ORDERSTATUSNAME,
                    PackageCode = order.TBL_PACKAGE.PACKAGECODE,
                    EventName = order.TBL_PACKAGE.TBL_EVENTTYPE.EVENTNAME,
                    Inclusions = order.TBL_PACKAGE.INCLUSIONSDESCRIPTION,
                    Accomodation = order.TBL_PACKAGE.ACCOMODATION.ToString(),
                    Price = order.TBL_PACKAGE.PRICE.ToString("N2"),
                    DealPrice = (int)(order.DEALPRICE == null ? 0 : order.DEALPRICE),
                    CustomerName = order.CUSTOMERNAME,
                    CustomerAddress = order.CUSTOMERADDRESS,
                    CustomerNumber = order.CUSTOMERCONTACTNUMVER,
                    CustormerEmail = order.CUSTOMEREMAIL,
                    ReservationPrice = (int)order.TBL_PACKAGE.PRICE,
                    OrderID = order.ORDERID
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
        public string AppointmentDate { get; set; }
        public string Status { get; set; }
        public string PackageCode { get; set; }
        public string EventName { get; set; }
        public string Inclusions { get; set; }
        public string Accomodation { get; set; }
        public string Price { get; set; }
        public int DealPrice { get; set; }
        public string CustomerName { get; set; }
        public string CustomerNumber { get; set; }
        public string CustormerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public int ReservationPrice { get; set; }
        public Guid OrderID { get; set; }
    }
}