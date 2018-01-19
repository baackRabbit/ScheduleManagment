using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthView.Interface;

namespace ScheduleManagement
{
    public class ScheduleBriefControlFactory:IDateTimeEventControlFactory
    {
        public IDateTimeEventControl GetControl(IDateTimeEvent dateTimeEvent)
        {
            var breifControl = new ScheduleBriefControl { DateTimeEvent = dateTimeEvent };
            return breifControl;
        }
    }
}
