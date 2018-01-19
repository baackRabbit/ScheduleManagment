using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonthView.Interface;

namespace ScheduleManagement
{
    public static class ScheduleCache
    {
        private static readonly ObservableCollection<IDateTimeEvent> InnerSchedules = new ObservableCollection<IDateTimeEvent>();

        static ScheduleCache()
        {
        }

        public static ObservableCollection<IDateTimeEvent> ScheduleModels
        {
            get { return InnerSchedules; }
        }
    }
}
