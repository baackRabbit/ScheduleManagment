using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthView.Interface;

namespace ScheduleManagement
{
    public class ScheduleModel:IDateTimeEvent
    {
        public ScheduleModel(DateTime ht,string ct,DateTime cd,string m)
        {
            HappenTime = ht;
            Content = ct;
            CreateDate = cd;
            Memo = m;
        }
        public ScheduleModel(DateTime ht, DateTime cd)
        {
            HappenTime = ht;
            CreateDate = cd;
        }
        public DateTime HappenTime { get; set; }

        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public string Memo { get; set; }
    }
}
