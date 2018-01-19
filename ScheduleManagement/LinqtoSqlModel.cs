using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScheduleManagement
{
    class LinqtoSqlModel:INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=linqlesson01;Integrated Security=True;";
        public LinqtoSqlModel()
        {
            DataContext = new ScheduleDataContext(ConnectionString);
            var aSchedules = from r in DataContext.Schedule select r;
            foreach(Schedule s in aSchedules)
            {
                ScheduleModel scheduleModel=new ScheduleModel(s.OccurDate,s.Content,s.CreateDate,s.Memo);
                ScheduleCache.ScheduleModels.Add(scheduleModel);
            }

        }
        public ScheduleDataContext DataContext { get; }

       
          public void Save()
         {
            var aSchedules = from r in DataContext.Schedule select r;
            foreach (Schedule s in aSchedules)
            {
                DataContext.Schedule.DeleteOnSubmit(s);
            }
            foreach (ScheduleModel sm in ScheduleCache.ScheduleModels)
            {
                Schedule schedule = new Schedule { Content = sm.Content,OccurDate=sm.HappenTime,CreateDate=sm.CreateDate,Memo=sm.Memo };
                DataContext.Schedule.InsertOnSubmit(schedule);
            }
            DataContext.SubmitChanges();
          }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
