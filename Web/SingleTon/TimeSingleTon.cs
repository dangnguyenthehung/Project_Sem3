using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Mvc;
using Model.Models;
using Web.Models;

namespace Web.SingleTon
{
    public class TimeSingleTon
    {
        private TimeSingleTon()
        {
            //
        }
        
        private TimeSingleTon _timeSingleTon = new TimeSingleTon();

        private static List<string> GioBegin = new List<string>()
        {
            "10:00",
            "10:30",
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
        };
        private static List<string> GioEnd = new List<string>()
        {
            "11:00",
            "11:30",
            "12:00",
            "12:30",
            "13:00",
            "13:30",
            "14:00",
            "14:30",
            "15:00",
            "15:30",
            "16:00",
            "16:30",
            "17:00",
            "17:30",
            "18:00",
            "18:30",
            "19:00",
            "19:30",
            "20:00",
            "20:30",
            "21:00",
            "21:30",
            "22:00",
            "22:30",
            "23:00",
            "23:30",
            "24:00"
        };

        public static SelectList GetListBegin(DateTime beginTime)
        {
            var imbalance = int.Parse(WebConfigurationManager.AppSettings["ServerHourImbalance"]);
            var beginIndex = 0;
            var dateTimeNow = DateTime.Now.AddHours(imbalance);
            
            if (dateTimeNow.Date == beginTime)
            {
                if (dateTimeNow.Hour >= 10 && dateTimeNow.Hour <= 23)
                {
                    string minute = "30";
                    string now = (dateTimeNow.Hour) + ":" + minute;

                    if (dateTimeNow.Minute > 30)
                    {
                        minute = "00";
                        now = (dateTimeNow.Hour + 1) + ":" + minute;
                    }
                    
                    beginIndex = GioBegin.IndexOf(now);
                    //GioBegin.RemoveRange(0, beginIndex);
                }
            }

            var response = new List<SelectListItem>();
            for (var i = beginIndex; i < GioBegin.Count; i++)
            {
                response.Add(new SelectListItem()
                {
                    Text = GioBegin[i],
                    Value = GioBegin[i]
                });
            }

            return new SelectList(response, "Value","Text");
        }

        public static SelectList GetListEnd(string beginTime)
        {
            var beginIndex = GioEnd.IndexOf(beginTime) + 2;
            GioEnd.RemoveRange(0, beginIndex);

            var response = new List<SelectListItem>();
            foreach (var item in GioEnd)
            {
                response.Add(new SelectListItem()
                {
                    Text = item,
                    Value = item
                });
            }

            return new SelectList(response, "Value", "Text");
        }
    }
}
