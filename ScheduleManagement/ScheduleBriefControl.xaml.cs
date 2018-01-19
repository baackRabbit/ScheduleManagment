using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MonthView.Interface;

namespace ScheduleManagement
{
    /// <summary>
    /// ScheduleBriefControl.xaml 的交互逻辑
    /// </summary>
    public partial class ScheduleBriefControl : IDateTimeEventControl
    {
        public ScheduleBriefControl()
        {
            DataContext = ScheduleModel;
            InitializeComponent();
            MouseDoubleClick += ScheduleBriefControl_MouseDoubleClick;
        }

        private ScheduleModel _schedule;

        public IDateTimeEvent DateTimeEvent
        {
            get { return ScheduleModel; }
            set { ScheduleModel = value as ScheduleModel; }
        }

        public Control EventControl
        {
            get { return this; }
        }

        public ScheduleModel ScheduleModel
        {
            get { return _schedule; }
            set
            {
                _schedule = value;
                DataContext = null;
                DataContext = value;
            }
        }
        private void ScheduleBriefControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var wnd = new ScheduleWindow
            {
                ScheduleModel = ScheduleModel,
                Owner = Application.Current.MainWindow,
                Title = "修改日程",
            };
            wnd.ShowDialog();
        }

    }
}
