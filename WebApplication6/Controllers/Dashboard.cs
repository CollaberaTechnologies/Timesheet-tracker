using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class DashboardController : Controller
    {
        private LIVEDBEntities6 db = new LIVEDBEntities6();

        // GET: HC_CLIENT_USERS

        // GET: HC_CLIENT_USERS/Details/5

        public void cache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.AppendCacheExtension("no-store, must-revalidate");
        }

        //piechart actions
        public ActionResult Getdata(int? year,int[] month, long country=0)
        {
            long id = (long)Session["userid"];
            var values = Request.Form["month"];
            string countries = string.Empty; // Initialize a string to hold the comma-delimited data as empty
            if (country != 0)
            {
                countries = "" + country + "";
            }
            else
            {
                bindState();
                IEnumerable<SelectListItem> count = (IEnumerable<SelectListItem>)TempData["country"];
                foreach (var item in count)
                {
                    if (countries.Length > 0)
                    {
                        countries += ","; // Add a comma if data already exists
                    }

                    countries += "" + item.Value + "";
                }
            }
            string mymonths = string.Empty;
            if (month[0] == 0) {

                if (year == 2018)
                {
                    for (int i = 1; i <= DateTime.Now.Month; i++)

                    {
                        if (mymonths.Length > 0)
                        {
                            mymonths += ","; // Add a comma if data already exists
                        }

                        mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "";

                    }
                }
                else
                    mymonths += "" + "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec" + "";
            }
            else
            {
                foreach (var item in month) {
                    if (mymonths.Length > 0)
                    {
                        mymonths += ","; // Add a comma if data already exists
                    }

                    mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(item) + "";
                }

               

            }
            short? years = (short?)year;
            
           
             var value = db.TimeSheetPieChartForApplicationDashboard(id, countries,years,mymonths).FirstOrDefault();
            long Submitted = value.Submitted;
            long Received = value.Received;
            long Rejected = value.Rejected;
            long Approved = value.Approved;
            int? MissingTScount = value.MissingTScount;


            ratio obj = new ratio();
            obj.admin = Submitted;
            obj.Finance = Received;
            obj.sales = Rejected;
            obj.delivery = Approved;
            obj.superuser = MissingTScount;
            return Json(obj, JsonRequestBehavior.AllowGet);

            
            
                }
    
        
        public class ratio
        {
            public long admin { get; set; }
            public long Finance { get; set; }
            public long sales { get; set; }
            public long delivery { get; set; }
            public int? superuser { get; set; }

        }
        


        //dropdown actions
        [HttpPost]
        public ActionResult Dash(hc_client_user client, FormCollection form,long[] months, long country = 0, long year = 0)
        {
            cache();
  
                long userid = (long)Session["userid"];
            string countries = string.Empty; // Initialize a string to hold the comma-delimited data as empty
            if (country != 0)
            {
                countries = "" + country + "";
            }
            else
            {
                bindState();
                IEnumerable<SelectListItem> count = (IEnumerable<SelectListItem>)TempData["country"];
                foreach (var item in count)
                {
                    if (countries.Length > 0)
                    {
                        countries += ","; // Add a comma if data already exists
                    }

                    countries += "" + item.Value + "";
                }
            }
            string mymonths = string.Empty;
            if (months[0] == 0)
            {
                if (year == 2018)
                {
                    for (int i = 1; i <= DateTime.Now.Month; i++)

                    {
                        if (mymonths.Length > 0)
                        {
                            mymonths += ","; // Add a comma if data already exists
                        }

                        mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "";

                    }
                }
                else
                    mymonths += "" + "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec" + "";
            }
            else
            {
                foreach (var item in months)
                {
                    if (mymonths.Length > 0)
                    {
                        mymonths += ","; // Add a comma if data already exists
                    }

                    mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)item) + "";
                }

            }
            ViewBag.viewall = db.TimeSheetBarChartDashBoardViewAll(userid,countries,year,mymonths);
                bindState(country);
                BarChart(client, country, year, months);
                GetYears();
                GetMonths(year, months);
            clientmapping();
            var countrys = db.HCM_COUNTRIES.OrderBy(x => x.CountryTitle).Select(x => x.RID).FirstOrDefault();
            getclient(countrys,0);
            var mapped = db.hc_client_user.Where(x => x.Userid == userid).FirstOrDefault();
            if (mapped == null)
            {
                ViewBag.mapped = "Client is not mapped to you";

            }



            return View();
        }

       
        [HttpGet]

        public ActionResult Dash([Bind(Include = "clientid,userid,countryid")] hc_client_user hC_CLIENT_USERS)
        {
            if (TempData["mapped"]!=null)
            {
                ViewBag.mapped = TempData["mapped"];
            }
            else
            {
                ViewBag.mapped = "";
            }
            cache();
            if (Session["userid"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                long country = 0;
                
                long year = 2018;
                long data = 0;
                if (year != 2018)
                {
                    data = 0;
                }
                else
                {
                    data = DateTime.Now.Month;
                }
                long[] months = new[] { data };
                string countries = string.Empty; // Initialize a string to hold the comma-delimited data as empty
                if (country != 0)
                {
                    countries = "" + country + "";
                }
                else
                {
                    bindState();
                    IEnumerable<SelectListItem> count = (IEnumerable<SelectListItem>)TempData["country"];
                    foreach (var item in count)
                    {
                        if (countries.Length > 0)
                        {
                            countries += ","; // Add a comma if data already exists
                        }

                        countries += "" + item.Value + "";
                    }
                }
                string mymonths = string.Empty;
                if (months[0] == 0)
                {
                    if (year == 2018)
                    {
                        for (int i = 1; i <= DateTime.Now.Month; i++)

                        {
                            if (mymonths.Length > 0)
                            {
                                mymonths += ","; // Add a comma if data already exists
                            }

                            mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "";

                        }
                    }
                    else
                        mymonths += "" + "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec" + "";
                }
                else
                {
                    foreach (var item in months)
                    {
                        if (mymonths.Length > 0)
                        {
                            mymonths += ","; // Add a comma if data already exists
                        }

                        mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)item) + "";
                    }

                }
                long userid = (long)Session["userid"];
                    bindState();
                    BarChart(hC_CLIENT_USERS,0,year, new[] { data });
                    GetYears();
                clientmapping();
                var countrys = db.HCM_COUNTRIES.OrderBy(x => x.CountryTitle).Select(x => x.RID).FirstOrDefault();
                getclient(countrys,0);
                    GetMonths(year, new[] { data});
                    ViewBag.viewall = db.TimeSheetBarChartDashBoardViewAll(userid,countries,year,mymonths);
                var mapped = db.hc_client_user.Where(x => x.Userid == userid).FirstOrDefault();
                if (mapped == null)
                {
                    ViewBag.mapped = "Client is not mapped to you";

                }
                    return View();
            }
        }
        public JsonResult getclient( long countryid,long userid)
        {
            var clientname = db.HC_CLIENTS.Where(x => x.CountryID == countryid).OrderBy(x => x.ClientName).Select(x => x.RID).FirstOrDefault();
            long[] selected = new long[] { clientname };
      //      if (userid == 0)
      //      {

      //          List<SelectListItem> client = db.HC_CLIENTS.Where(x => x.CountryID == countryid).Select(c => new SelectListItem
      //          {
      //              Value = c.RID.ToString()
      //,
      //              Text = c.ClientName,


      //          }).Distinct().ToList();
      //          var allclient = new SelectListItem
      //          {
      //              Value = 0.ToString(),
      //              Text = "ALL"

      //          };
      //          client.Insert(0, allclient);
      //          ViewBag.allclient = new MultiSelectList(client, "Value", "Text", selected);
      //          return Json(new MultiSelectList(client, "Value", "Text"), JsonRequestBehavior.AllowGet);

      //      }
          
                List<CLIENTUSERMAPPING_Result> client = db.CLIENTUSERMAPPING(countryid, userid).ToList();
                ViewBag.allclient = new MultiSelectList(client, "rid", "clientname", selected);

              
                return Json(client, JsonRequestBehavior.AllowGet);
                   }
        public void clientmapping()
        {
            IEnumerable<SelectListItem> country = db.HCM_COUNTRIES.Select(c => new SelectListItem
            {
                Value = c.RID.ToString()
,
                Text = c.CountryTitle
               
            }).Distinct();
//            var countrys = db.HCM_COUNTRIES.OrderBy(x => x.CountryTitle).Select(x=>x.RID).FirstOrDefault();
//            IEnumerable<SelectListItem> client = db.HC_CLIENTS.Where(x=>x.CountryID==countrys).Select(c => new SelectListItem
//            {
//                Value = c.RID.ToString()
//,
//                Text = c.ClientName

//            }).Distinct();
            IEnumerable<SelectListItem> users = db.HC_USERS.Where(x=>x.RightsID!=4).Select(c => new SelectListItem
            {
                Value = c.RID.ToString()
    ,
                Text = c.FirstName

            }).Distinct();

            ViewBag.allcountry = country;
            //ViewBag.allclient = client;
            ViewBag.alluser = users;
        }

        [ValidateAntiForgeryToken]
        public void bindState(long selectcontry =0)
        {
            cache();
            long id = (long)Session["userid"];
            IEnumerable<SelectListItem> country = db.hc_client_user.Where(x => x.Userid == id).Select(c => new SelectListItem
            {
                Value = c.HCM_COUNTRIES.RID.ToString()
,
                Text = c.HCM_COUNTRIES.CountryTitle,
                Selected= c.HCM_COUNTRIES.RID==selectcontry? true:false

            }).Distinct();
            ViewBag.countries = country;
            TempData["country"] = country;
        }
        public JsonResult getCity(int id)
        {
            long uid = (long)Session["userid"];
            IEnumerable<SelectListItem> liclient = db.hc_client_user.Where(x => x.Countryid == id && x.Userid == uid).Select(c => new SelectListItem
            {
                Value = c.HCM_COUNTRIES.RID.ToString()
    ,
                Text = c.HC_CLIENTS.ClientName

            }).Distinct();
            return Json(new SelectList(liclient, "Value", "Text", JsonRequestBehavior.AllowGet));
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public void BarChart([Bind(Include = "clientid,userid,countryid")] hc_client_user hC_CLIENT_USERS,long country,long year,long[] month)
        {
            long id = (long)Session["userid"];
            try
            {
                string countries = string.Empty; // Initialize a string to hold the comma-delimited data as empty
                if (country != 0)
                {
                    countries = "" + country + "";
                }
                else
                {
                    bindState();
                    IEnumerable<SelectListItem> count = (IEnumerable<SelectListItem>)TempData["country"];
                    foreach (var item in count)
                    {
                        if (countries.Length > 0)
                        {
                            countries += ","; // Add a comma if data already exists
                        }

                        countries += "" + item.Value + "";
                    }
                }
                string mymonths = string.Empty;
                if (month[0] == 0)
                {
                    if (year == 2018)
                    {
                        for (int i = 1; i <= DateTime.Now.Month; i++)

                        {
                            if (mymonths.Length > 0)
                            {
                                mymonths += ","; // Add a comma if data already exists
                            }

                            mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i) + "";

                        }
                    }
                    else
                        mymonths += "" + "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec" + "";
                }
                else
                {
                    foreach (var item in month)
                    {
                        if (mymonths.Length > 0)
                        {
                            mymonths += ","; // Add a comma if data already exists
                        }

                        mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)item) + "";
                    }

                }
                List<long> lstClientID = new List<long>();
                List<int?> lstTSCount = new List<int?>();
                List<TimeSheetBarChart_Result> TimeSheet = new List<TimeSheetBarChart_Result>();
                HCClientuserModel.ProductWiseSales(out TimeSheet, id,countries,year,mymonths);

                ViewBag.TimeSheet = TimeSheet;

            }
            catch (Exception ex)
            {
                string ip = Request.UserHostAddress;
                errorfile.SendErrorToText(ex,ip);
                throw;
            }
        }
        public JsonResult GetYears()
        {
            cache();
            int CurrentYear = DateTime.Now.Year;
            List<SelectListItem> years = new List<SelectListItem>();

            for (int i = CurrentYear; i >= 2010; i--)
            {
                years.Add(new SelectListItem
                {
                    Text = i.ToString(),
                    Value = i.ToString()
                });
            }
            //Default It will Select Current Year  
            ViewBag.years = years;
            return Json(years, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetMonths(long iSelectedYear, long[] data )
        {
            cache();
            var months = Enumerable.Range(1, 12).Select(i => new
            {
                A = i,
                B = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i)
            });
            int CurrentMonth = 1;
            List<SelectListItem> month = new List<SelectListItem>();
            if (iSelectedYear == DateTime.Now.Year)
            {
                CurrentMonth = DateTime.Now.Month;
                months = Enumerable.Range(1, CurrentMonth).Select(i => new
                {
                    A = i,
                    B = DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(i)
                });
            }
            month.Add(new SelectListItem { Text = "All", Value = 0.ToString() });
            foreach (var item in months)
            {
                month.Add(new SelectListItem { Text = item.B.ToString(), Value = item.A.ToString() });
            }
            ViewBag.months = new MultiSelectList(month,"Value","Text",data);
            return Json(new MultiSelectList(month, "Value", "Text", data), JsonRequestBehavior.AllowGet);
        }
    }
}
   


