using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class HCClientuserModel
    {

        public static void ProductWiseSales(out List<TimeSheetBarChart_Result> TimeSheet, long userid,string country,long year, string month)
        {

            LIVEDBEntities6 db = new LIVEDBEntities6();
            {
                TimeSheet = db.TimeSheetBarChart(userid,country,year,month).ToList();


            }
        }
    }
}