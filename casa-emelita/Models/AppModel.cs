using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace casa_emelita.Models
{
    public class AppModel
    {
        public Guid AdminID {
            get {
                try
                {
                    if(new Guid(HttpContext.Current.Session["AdminID"].ToString()) == Guid.Empty) {  return Guid.Empty; }
                }
                catch {
                    return Guid.Empty;
                }
                return new Guid(HttpContext.Current.Session["AdminID"].ToString());
            }
            set
            {
                HttpContext.Current.Session["AdminID"] = value.ToString();
            } 
        }
        public string ErrorMessage { get; set; }
        public List<TBL_MENU> Menu_List { get; set; }
        public string MenuIDToDelete { get; set; }
        public string PackageIDToDelete { get; set; }
        public MenuNewRecord menuNewRecord { get; set; }
        public List<TBL_CATEGORY> Category { get; set; }
        public List<TBL_PACKAGE> Package_List { get; set; }
        public TBL_PACKAGE packageNewRecord { get; set; }
        public List<TBL_EVENTTYPE> EventType_List { get; set; }
        public ChangePassModel changePassModel { get; set; }
        public Guid? SelectedCategory { get; set; }
        public Guid? SelectedEvent { get; set; }
        public TBL_ORDER Reservation { get; set; }
        public List<AvailableMonths> Months 
        {
            get { 
                return new List<AvailableMonths>() { 
                    new AvailableMonths()
                    {
                        value = 1,
                        Text = "January"
                    },
                    new AvailableMonths()
                    {
                        value = 2,
                        Text = "February"
                    },
                    new AvailableMonths()
                    {
                        value = 3,
                        Text = "March"
                    },
                    new AvailableMonths()
                    {
                        value = 4,
                        Text = "April"
                    },
                    new AvailableMonths()
                    {
                        value = 5,
                        Text = "May"
                    },
                    new AvailableMonths()
                    {
                        value = 6,
                        Text = "June"
                    },
                    new AvailableMonths()
                    {
                        value = 7,
                        Text = "July"
                    },
                    new AvailableMonths()
                    {
                        value = 8,
                        Text = "August"
                    },
                    new AvailableMonths()
                    {
                        value = 9,
                        Text = "September"
                    },
                    new AvailableMonths()
                    {
                        value = 10,
                        Text = "October"
                    },
                    new AvailableMonths()
                    {
                        value = 11,
                        Text = "November"
                    },
                    new AvailableMonths()
                    {
                        value = 12,
                        Text = "December"
                    },
                };
            } 
        }
        public int SelectedMonth { get; set; }
        public List<AvailableYears> Years 
        {
            get { 
                return new List<AvailableYears>() { 
                    new AvailableYears()
                    {
                        value = 2021,
                        Text = "2021"
                    },
                    new AvailableYears()
                    {
                        value = 2022,
                        Text = "2022"
                    },
                    new AvailableYears()
                    {
                        value = 2023,
                        Text = "2023"
                    },
                    new AvailableYears()
                    {
                        value = 2024,
                        Text = "2024"
                    },
                    new AvailableYears()
                    {
                        value = 2025,
                        Text = "2025"
                    },
                    new AvailableYears()
                    {
                        value = 2026,
                        Text = "2026"
                    },
                    new AvailableYears()
                    {
                        value = 2027,
                        Text = "2027"
                    },
                    new AvailableYears()
                    {
                        value = 2028,
                        Text = "2028"
                    },
                    new AvailableYears()
                    {
                        value = 2029,
                        Text = "2029"
                    },
                    new AvailableYears()
                    {
                        value = 2030,
                        Text = "2030"
                    },
                    new AvailableYears()
                    {
                        value = 2031,
                        Text = "2031"
                    },
                };
            }
        }
        public int SelectedYear { get; set; }
        public List<TBL_ORDER> OrderList { get; set; }
        public DateTime DateRangeFrom { get; set; }
        public DateTime DateRangeTo { get; set; }
    }
    public class MenuNewRecord
    {
        public HttpPostedFileBase file { get; set; }
        public string MenuID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid Category { get; set; }
        public string Description { get; set; }
        public Decimal Price { get; set; }
    }
    public class ChangePassModel
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}