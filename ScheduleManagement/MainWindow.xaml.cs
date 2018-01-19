using MonthView.EventArgs;
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
using System.Xml.Linq;

namespace ScheduleManagement
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        private LinqtoSqlModel _sqlModel;
        private string xmlFileName = "default.xml";
        public MainWindow()
        {
            InitializeComponent();
            _sqlModel = new LinqtoSqlModel();
            this.DataContext = _sqlModel;
            TestMonthControl.DateTimeEvents = ScheduleCache.ScheduleModels;

            TestMonthControl.DateTimeEventControlFactory = new ScheduleBriefControlFactory();
            TestMonthControl.DayBlankDoubleClicked += AddNewSchedule;
        }

        private void AddNewSchedule(DayEventArgs e)
        {
            XDocument aXDocument = XDocument.Load(xmlFileName);
            var scheduleModel = new ScheduleModel(e.DayTime,DateTime.Now);
            scheduleModel.Content = aXDocument.Root.Element("Content").Value;
            scheduleModel.Memo = aXDocument.Root.Element("Memo").Value;
            var wnd = new ScheduleWindow
            {
                ScheduleModel = scheduleModel,
                Title = "添加日程",
                Owner = Application.Current.MainWindow
            };
            if (true == wnd.ShowDialog())
            {
                ScheduleCache.ScheduleModels.Add(wnd.ScheduleModel);
            }
        }

        
        private void OnWindow_Closed(object sender, EventArgs e)
        {
            _sqlModel.Save();
        }
    }
}
