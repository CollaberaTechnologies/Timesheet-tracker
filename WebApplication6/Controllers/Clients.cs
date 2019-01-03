using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;


namespace WebApplication6.Controllers
{
    public class ClientsController : Controller
    {
       
        private LIVEDBEntities6 db = new LIVEDBEntities6();
        public int? buttonvalue = 1;
        // GET: Clientpie
        public void cache()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.AppendCacheExtension("no-store, must-revalidate");
        }
        public ActionResult Getdata(long[] cid, long coid, int? year , int[] month, int lob=0)
        {

            if (Session["userid"] == null)
                return RedirectToAction("Login", "Account");
            long id = (long)Session["userid"];  
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

                    } }
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

                    mymonths += "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(item) + "";
                }
            }
            short? years = (short?)year;
            string lobdata = string.Empty;
            string clientdata=string.Empty;
            if (lob == 0)
            {
               
            }
            else
            {
                lobdata = "" + lob + "";
            }
            if (cid[0] == 0)
            {
                getClient(coid, cid);
                foreach (var item in ViewBag.clients)
                {
                    if (clientdata.Length > 0)
                    {
                        clientdata += ","; // Add a comma if data already exists
                    }

                    clientdata += "" + item.Value + "";
                }
            }
            else
            {
               foreach (var item in cid)
            {
                if (clientdata.Length > 0)
                {
                    clientdata += ","; // Add a comma if data already exists
                }

                clientdata += "" + item + "";
            }
            }
            

            var value = db.TimeSheetPieChartForAppClientPage(  years, mymonths, clientdata, lobdata).FirstOrDefault();
            long Submitted = value.Submitted;
            long Received = value.Received;
            long Rejected = value.Rejected_TimeSheet;
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
        [ValidateInput(false)]
      [HttpPost]
        public ActionResult Client(hc_client_user model,HC_EMAIL_SENT_LOG obj, long[] client, long[] month, long year=0, long country = 0, long lob = 0, string Imagepath = null,string closedata=null, string uplodedfile=null)
        {
            if (Session["userid"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var userinfo = (long)Session["userid"];
                var data = db.hc_client_user.Where(x => x.Userid == userinfo).FirstOrDefault();
                if (data != null)
                {
                    if (model.buttonvalue == "1")
                    {
                        string[] clientinfo = model.clients.Split(',');
                        string[] monthinfo = model.monthdata.Split(',');
                        List<long> clientarray = new List<long>();
                        foreach (string s in clientinfo)
                        {
                            long val;

                            if (long.TryParse(s, out val))
                            {
                                clientarray.Add(val);
                            }
                        }

                        client = clientarray.ToArray();
                        List<long> montharray = new List<long>();
                        foreach (string s in monthinfo)
                        {
                            long val;

                            if (long.TryParse(s, out val))
                            {
                                montharray.Add(val);
                            }
                        }

                        month = montharray.ToArray();

                    }
                    var mesaage = string.Empty;
                    if (closedata == "0")
                    {
                        if (Session["button"].ToString() == "1")
                        {
                            mesaage = Sendmail(model, obj, Imagepath, uplodedfile, country);

                        }
                    }

                    long id = (long)Session["userid"];
                    string mymonths = string.Empty;
                    if (month[0] == 0)
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
                    string lobdata = string.Empty;
                    string clientdata = string.Empty;

                    var monthname = model.valclient;

                    getClient(country, client);
                    getlob(client, country, lob);

                    if (client[0] == 0)
                    {

                        foreach (var item in ViewBag.clients)
                        {
                            if (clientdata.Length > 0)
                            {
                                clientdata += ","; // Add a comma if data already exists
                            }

                            clientdata += "" + item.Value + "";
                        }
                    }
                    else
                    {
                        foreach (var item in client)
                        {
                            if (clientdata.Length > 0)
                            {
                                clientdata += ","; // Add a comma if data already exists
                            }

                            clientdata += "" + item + "";
                        }
                    }

                    if (lob == 0)
                    {
                        foreach (var item in ViewBag.lobs)
                        {
                            if (lobdata.Length > 0)
                            {
                                lobdata += ","; // Add a comma if data already exists
                            }

                            lobdata += "" + item.Value + "";
                        }
                    }
                    else
                        lobdata = "" + lob + "";



                    ViewBag.VALUE = db.TimeSheetappliGrid(clientdata, lobdata, year, mymonths);

                    bindState();
                    GetYears();
                    GetMonths((long)year, month);
                    ViewBag.count = country;


                    if (mesaage != null)
                    {
                        ViewBag.Status = mesaage;
                    }
                    else
                    {
                        ViewBag.Status = null;
                    }

                    return View();

                }
                else
                {
                    return RedirectToAction("Dash", "Dashboard");
                }
            }

        }
        public ActionResult getcontent(long id,string clid=null)
        {
            long uid = (long)Session["userid"];
            IHD_Timesheet_Template tm = new IHD_Timesheet_Template();
            if (clid != null)
            {
                tm.history = db.TimeSheetDetailsAgainstCandidate(clid).ToList();
            }
           tm.TemplateContent = db.IHD_Timesheet_Template.Where(x => x.TemplateID == id).Select(x=>x.TemplateContent).FirstOrDefault().ToString();
            tm.TemplateName = db.IHD_Timesheet_Template.Where(x => x.TemplateID == id).Select(x => x.TemplateName).FirstOrDefault();
            tm.TemplateAttachment = db.IHD_Timesheet_Template.Where(x => x.TemplateID == id).Select(x => x.TemplateAttachment).FirstOrDefault();
            tm.Name = db.HC_USERS.Where(x => x.RID == uid).Select(x => x.FirstName).FirstOrDefault();
            return Json(tm, JsonRequestBehavior.AllowGet);
        } 
        [HttpGet]
        public ActionResult Client([Bind(Include = "clientid,userid,countryid")] hc_client_user hC_CLIENT_USERS, long year=0)
        {
            Session["button"] = "";
            cache();
            if (Session["userid"] == null)
                return RedirectToAction("Login", "Account");
            else
            {
                var userinfo = (long)Session["userid"];
                var mapped = db.hc_client_user.Where(x => x.Userid == userinfo).FirstOrDefault();
                if (mapped != null)
                {
                    year = 2018;
                    long data = DateTime.Now.Month;


                    long uid = (long)Session["userid"];
                    var countrys = db.hc_client_user.Where(x => x.Userid == uid).OrderBy(x => x.HCM_COUNTRIES.CountryTitle).First();
                    long country = (long)countrys.Countryid;
                    var clients = db.hc_client_user.Where(x => x.Userid == uid && x.Countryid == country).OrderBy(x => x.HC_CLIENTS.ClientName).First();
                    long client = (long)clients.Clientid;
                    var lobs = db.HC_CLIENT_BRANCH.Where(m => m.ClientID == client).Join(db.hc_client_user.Where(x => x.Userid == uid),
                   d => d.ClientID,
                   f => f.Clientid,

                   (d, f) => d).OrderBy(x => x.RID).First();
                    long lobid = (long)lobs.RID;
                    ViewBag.clid = client;
                    string mymonths = "" + DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName((int)data) + "";
                    string lobdata = string.Empty;
                    string clientdata = string.Empty;

                    getClient(country, new long[] { client });
                    getlob(new long[] { client }, country);
                    ViewBag.Status = null;
                    ViewBag.year = year;
                    bindState();
                    lobdata = "";
                    clientdata = "" + client + "";
                    ViewBag.VALUE = db.TimeSheetappliGrid(clientdata, lobdata, year, mymonths);
                    templatedata();



                    GetYears();
                    GetMonths((long)year, new[] { data });

                    return View();
                }
                else
                {
                    TempData["mapped"] = "Client is not mapped to you";
                    ViewBag.mapped = "Client is not mapped to you";
                    return RedirectToAction("Dash", "Dashboard");
                }
            }


        }
        [ValidateAntiForgeryToken]
        public void templatedata()
        {
            List<SelectListItem> templates = new List<SelectListItem>();

            templates = db.IHD_Timesheet_Template.Select(c => new SelectListItem
            {
                Value = c.TemplateID.ToString()
,
                Text = c.TemplateName

            }).Distinct().ToList();

            ViewBag.template = templates;


        }
        public void bindState()
        {
            long id = (long)Session["userid"];

            List<SelectListItem> country = new List<SelectListItem>();

            country = db.hc_client_user.Where(x => x.Userid == id).Select(c => new SelectListItem
            {
                Value = c.HCM_COUNTRIES.RID.ToString()
,
                Text = c.HCM_COUNTRIES.CountryTitle

            }).Distinct().ToList();

            ViewBag.countries = country;

        }
        public JsonResult getClient(long id, long[] selected)
        {
            long uid = (long)Session["userid"];

            List<SelectListItem> liclient = db.hc_client_user.Where(x => x.Countryid == id && x.Userid == uid).Select(c => new SelectListItem
            {
                Value = c.HC_CLIENTS.RID.ToString()
   ,
                Text = c.HC_CLIENTS.ClientName



            }).Distinct().ToList();
            var allclient = new SelectListItem
            {
                Value = 0.ToString(),
                Text="ALL"

            };
            liclient.Insert(0,allclient);
            ViewBag.clients = new MultiSelectList(liclient, "Value", "Text", selected);
            return Json(new MultiSelectList(liclient, "Value", "Text"), JsonRequestBehavior.AllowGet);

        }
        public JsonResult getlob(long[] id, long country = 0, long selected = 0)
        {
            long uid = (long)Session["userid"];
            int flag = 0;
            foreach (var item in id)
            {
                if (item == 0)
                {
                    flag = 1;
                    break;
                }
            }
            if (flag == 1)
            {
                id = db.hc_client_user.Where(x => x.Countryid == country && x.Userid == uid).Select(y => y.Clientid).ToArray();

            }
            List<SelectListItem> liclob = new List<SelectListItem>();


            for (int i = 0; i < id.Length; i++)
            {
                long cid = id[i];
                List<SelectListItem> liclob1 = db.HC_CLIENT_BRANCH.Where(m => m.ClientID == cid).Join(db.hc_client_user.Where(x => x.Userid == uid),
                   d => d.ClientID,
                   f => f.Clientid,

                   (d, f) => d).Select(c => new SelectListItem
                   {
                       Value = c.RID.ToString()
  ,
                       Text = c.BranchName,
                       Selected = c.RID == selected ? true : false

                   }).Distinct().ToList();


                liclob.InsertRange(i, liclob1);
            }
            var all = new SelectListItem
            {
                Value = 0.ToString(),
                Text = "All",

            };
            liclob.Insert(0, all);
            ViewBag.lobs = liclob;
            return Json(new SelectList(liclob, "Value", "Text", JsonRequestBehavior.AllowGet));



        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult SendEmail(string cid, string month, string clid=null, string name=null, string from=null, string till=null, string bulkemail=null, long countryid=0,int lobid=0,long year=0)
        {
            templatedata();
            hc_client_user model = new hc_client_user();

            if (bulkemail != null)
            {
                ViewBag.bulk = "1";
                string[] m = bulkemail.Split(',');
                string offemail = string.Empty;
                string peremail = string.Empty;
                string bothemails = string.Empty;
                string emailids = string.Empty;
                foreach (var item in m)
                {
                    var value = db.HC_RESUME_BANK.Where(x => x.EmployeeNo == item).FirstOrDefault();
                    if (value.ExOfficialEmailID!=null) {
                        if (value.ExOfficialEmailID != "") {
                            if (offemail.Length > 0)
                            {
                                offemail += ";"; // Add a comma if data already exists
                            }

                            offemail += "" + value.ExOfficialEmailID + "";
                        }
                    }
                    if (value.EmailID!=null) {
                        if (value.EmailID != "")
                        {
                            if (peremail.Length > 0)
                            {
                                peremail += ";"; // Add a comma if data already exists
                            }

                            peremail += "" + value.EmailID + "";
                        }
                    }
                }
                ViewBag.offemail = offemail;
                ViewBag.peremail = peremail;
                if (offemail == null)
                    ViewBag.bothemail = peremail;
                if (peremail == null)
                    ViewBag.bothemail = offemail;
                if (offemail != null && peremail != null)
                    ViewBag.bothemail = offemail + ";" + peremail;

            }
            else
            {
                ViewBag.bulk = "0";

                ViewBag.a = from;
                ViewBag.b = till;
                model.name = name;

                var value = db.HC_RESUME_BANK.Where(x => x.EmployeeNo == clid).First();
                ViewBag.offemail = value.ExOfficialEmailID;
                ViewBag.peremail = value.EmailID;
                if(value.ExOfficialEmailID==null)
                    ViewBag.bothemail= value.EmailID;
                if (value.EmailID == null)
                    ViewBag.bothemail = value.ExOfficialEmailID;
                if(value.ExOfficialEmailID != null&& value.EmailID != null)
                    ViewBag.bothemail = value.ExOfficialEmailID+";"+ value.EmailID;
                model.clid = clid;
                model.from = from;
                model.till = till;
            }

            model.EmailBCC = db.IHD_Country_EmailID.Where(x => x.CountryID == countryid).Select(x => x.CounEmailID).FirstOrDefault();
            model.country = countryid;
            model.clients = cid;
            model.lob = lobid;
            model.monthdata = month;
            model.year = year;
            model.buttonvalue = "1";

            Session["button"] = "1";
            return View(model);

        }
        
        public ActionResult uploadfile()
        {
           
            cache();
            HttpFileCollectionBase files = Request.Files;
            try
            {
                string path = string.Empty;
                string dest =string.Empty;
                string _FileName = string.Empty;
                string actualfilename = string.Empty;

                    for (var i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        _FileName = Path.GetFileName(file.FileName);
               
                            path = "~/uploadfolder/" + _FileName;
                    var filedelt = Path.Combine(Request.MapPath("~/uploadfolder/"), _FileName);
                    file.SaveAs(Server.MapPath(path));
                    var bytes = new byte[0];
                    using (Stream fs = file.InputStream)
                    {
                        using (BinaryReader br = new BinaryReader(fs))
                        {
                            
                            bytes = br.ReadBytes((Int32)fs.Length);
                        }
                    }
                  
                }
                
             
                return Json(new { ImagePath = path, ImageName = _FileName });
            }
            catch(Exception ex)
            {
                string ip = Request.UserHostAddress;
                errorfile.SendErrorToText(ex,ip);
               return Json("File upload failed!!!!!", JsonRequestBehavior.AllowGet);
            }

        }
        public string mail(hc_client_user obj,string EmailSubject = null, string EMailBody = null, string ToEmail = null, string EmailBCC = null, string EmailCC = null,string fileupload=null, string fileUploader = null,long country=0)
        {
            HC_EMAIL_SENT_LOG model = new HC_EMAIL_SENT_LOG();
            try
            {
                var message = new MailMessage();
                var from = db.IHD_Country_EmailID.Where(x => x.CountryID == country).Select(x => x.CounEmailID).FirstOrDefault();
                message.From = new MailAddress(from);  // replace with valid value
                message.Subject = EmailSubject;
                message.Body = EMailBody;
                message.IsBodyHtml = true;
                var smtp = new SmtpClient
                {
                    Host = "mailbrd.collabera.com",
                    Port = 25,
                    EnableSsl = false,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                };
                if (ToEmail != null)
                {
                    if (fileupload!="")
                    {
                        string[] filesdata = fileupload.Split(',');
                        foreach (string item in filesdata)
                        {
                            Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/uploadfolder/"), item));
                            message.Attachments.Add(attachment);
                        }
                    }
                    if (fileUploader != "")
                    {
                        string[] files = fileUploader.Split(',');
                        foreach (string item in files)
                        {
                            var value = new WebClient();
                            var filepath = Path.Combine(Server.MapPath("~/uploadfolder/"), item);

                            var filedest = Path.Combine(Server.MapPath("~/uploadeddata/"), item);
                            value.DownloadFile(filepath, filedest);
                            Attachment attachment = new Attachment(filepath, MimeMapping.GetMimeMapping(filepath));

                            message.Attachments.Add(attachment);

                            value.Dispose();
                        }

                    }
                    message.To.Add(new MailAddress(ToEmail));
                    smtp.Send(message);
                    var data = db.TimeSheetDetailsAgainstCandidate(obj.clid).ToArray();
                    foreach (var datainfo in data)
                    {
                        model.employeeno = obj.clid;
                        model.TSStartdate = datainfo.StartDate;
                        model.TSEnddate = datainfo.EndDate;
                        model.TemplateId = (int)obj.tempid;
                        model.EmailSent = DateTime.Now;
                        model.DateEmailSentUserId = (long)Session["userid"];
                        db.HC_EMAIL_SENT_LOG.Add(model);
                        db.SaveChanges();

                    }
                }
                if (EmailCC != null)
                {
                    if (fileupload != "")
                    {
                        string[] filesdata = fileupload.Split(',');
                        foreach (string item in filesdata)
                        {
                            Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/uploadfolder/"), item));
                            message.Attachments.Add(attachment);
                        }
                    }
                    if (fileUploader != "")
                    {
                        string[] files = fileUploader.Split(',');
                        foreach (string item in files)
                        {
                            var value = new WebClient();
                            var filepath = Path.Combine(Server.MapPath("~/uploadfolder/"), item);
                            var filedest = Path.Combine(Server.MapPath("~/uploadeddata/"), item);
                            //FileInfo file = new FileInfo(filedest);
                            //file.Delete();
                           
                                value.DownloadFile(filepath, filedest);
                                                        Attachment attachment = new Attachment(filepath, MimeMapping.GetMimeMapping(filepath));

                            message.Attachments.Add(attachment);

                            value.Dispose();
                        }

                    }

                    message.CC.Add(new MailAddress(EmailCC));
                    smtp.Send(message);
                }
                if (EmailBCC != null)
                {
                    if (fileupload != "")
                    {
                        string[] filesdata = fileupload.Split(',');
                        foreach (string item in filesdata)
                        {
                            Attachment attachment = new Attachment(Path.Combine(Server.MapPath("~/uploadfolder/"), item));
                            message.Attachments.Add(attachment);
                        }
                    }

                    if (fileUploader != "")
                    {
                        string[] files = fileUploader.Split(',');
                        foreach (string item in files)
                        {
                            var value = new WebClient();
                            var filepath = Path.Combine(Server.MapPath("~/uploadfolder/"), item);
                            var filedest = Path.Combine(Server.MapPath("~/uploadeddata/"), item);
                            

                                value.DownloadFile(filepath, filedest);
                            
                            Attachment attachment = new Attachment(filepath, MimeMapping.GetMimeMapping(filepath));

                            message.Attachments.Add(attachment);
                            value.Dispose();


                        }

                    }

                    message.Bcc.Add(new MailAddress(EmailBCC));
                    smtp.Send(message);
                }

                return "Email Send.";

            }

            catch(Exception ex)
            {
                string ip = Request.UserHostAddress;
                errorfile.SendErrorToText(ex,ip);
                return "Problem while sending email, Please check details.";
            }

        }
       
        [ValidateInput(false)]
        [HttpPost]
        public string Sendmail(hc_client_user obj,HC_EMAIL_SENT_LOG model, string filename,string uploadefile, long country)
        {
                   string message = string.Empty;
            string mesdata = string.Empty;
            int flag = 1;
            //message= mail(obj,obj.EmailSubject, obj.EMailBody, "garima.thakore@collabera.com", null, null, uploadefile, filename, country);
            // if (message == "Problem while sending email, Please check details.")
            // {
            //     mesdata += "  Email is not sent to"+ "garima.thakore@collabera.com"+" .  ";
            //     flag = 0;
            // }
           
            if (obj.ToEmail != null)
            {

                string[] Toemail = obj.ToEmail.Split(';');
                foreach (string item in Toemail)
                {
                    message = mail(obj, obj.EmailSubject, obj.EMailBody, item, null, null, uploadefile, filename, country);
                    if (message == "Problem while sending email, Please check details.")
                    {
                        mesdata += " Email is not sent to" + item + " .  ";

                        flag = 0;
                    }
                }
            }
           
                if (obj.EmailCC != null) {
                    
                        string[] emailcc = obj.EmailCC.Split(';');
                        foreach (string item in emailcc)
                        {
                       message= mail(obj,obj.EmailSubject, obj.EMailBody,null,null,item, uploadefile, filename, country);
                    if (message == "Problem while sending email, Please check details.")
                    {
                        mesdata += " Email is not sent to" + item + " .  ";

                        flag = 0;
                    }
                        }
                    }                

                if (obj.EmailBCC != null)
                {
                    
                        string[] emailbcc = obj.EmailBCC.Split(';');
                        foreach (string item in emailbcc)
                        {
                       message= mail(obj,obj.EmailSubject, obj.EMailBody, null, item, null, uploadefile, filename, country);
                    if (message == "Problem while sending email, Please check details.")
                    {
                        mesdata += "  Email is not sent to" + item + " .  ";
                        flag = 0;
                    }
                }
                    }                

             
             
               

            if (flag == 1)
            {
                obj.message = "Email Send."+mesdata;
               
            }
            else
            {
                obj.message = mesdata+" Please check details.";
            }

            TempData["country"] = obj.country;
            TempData["client"] = obj.clients;
            TempData["lob"] = obj.lobs;
            TempData["year"] = obj.years;
            TempData["month"] = obj.monthdata;
            TempData["message"] = obj.message;


            cache();

            Session["button"] = "";

            return obj.message;
           
         

        }
        public void GetYears()
        {
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

        }
        public JsonResult GetMonths(long iSelectedYear, long[] data)
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

           
           
            ViewBag.months = new MultiSelectList(month, "Value", "Text", data);
            return Json(new MultiSelectList(month, "Value", "Text", data), JsonRequestBehavior.AllowGet);
        }

        public ActionResult getemail(string empno=null,string from=null,string till=null)
        {
            ViewBag.mail = db.timesheetmailhistory_1(empno,from,till);
            
            return View();
        }
        public ActionResult updatecomment(string empid,string from,string till,string comment)
        {

            var info = db.HC_Comment_Log.Where(x => x.employeeno == empid &&x.TSStartdate==from&&x.TSEnddate==till).FirstOrDefault();
            if (info==null)
            {
                HC_Comment_Log hC_Comment_Log = new HC_Comment_Log();
                
                hC_Comment_Log.employeeno = empid;
                hC_Comment_Log.TSEnddate = till;
                hC_Comment_Log.TSStartdate = from;
                hC_Comment_Log.Comment = comment;
                db.HC_Comment_Log.Add(hC_Comment_Log);
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
            }
            else
            {

                info.Comment = comment;
                db.Configuration.ValidateOnSaveEnabled = false;
                db.SaveChanges();
            }
            return null;
        }
    }

}
