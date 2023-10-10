using casa_emelita.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace casa_emelita.Repository
{
    public class EventTypeRepository
    {
        public List<TBL_EVENTTYPE> GetAllEventType()
        {
            CASAEMELITAEntities entities = new CASAEMELITAEntities();
            List<TBL_EVENTTYPE> eventtype = (List<TBL_EVENTTYPE>)(from tbl_eventType in entities.TBL_EVENTTYPE select tbl_eventType).ToList();
            if (eventtype.Count() == 0)
            {
                eventtype = new List<TBL_EVENTTYPE>() { };
            }
            return (List<TBL_EVENTTYPE>)eventtype;
        }
    }
}