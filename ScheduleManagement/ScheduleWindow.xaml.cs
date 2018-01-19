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
using System.Windows.Shapes;

namespace ScheduleManagement
{
    /// <summary>
    /// ScheduleWindow.xaml 的交互逻辑
    /// </summary>
    public partial class ScheduleWindow
    {
        private ScheduleModel _scheduleModel;
        public ScheduleModel ScheduleModel
        {
            get { return _scheduleModel; }
            set
            {
                _scheduleModel = value;
                DataContext = null;
                DataContext = value;
            }
        }
        public ScheduleWindow()
        {
            DataContext = ScheduleModel;
            InitializeComponent();
        }

        private void BtnDel_OnClick(object sender, RoutedEventArgs e)
        {
            if(MessageBoxResult.Yes ==
                MessageBox.Show("确实删除该日程", "提示", MessageBoxButton.YesNo, MessageBoxImage.Question))
            {
                ScheduleCache.ScheduleModels.Remove(ScheduleModel);
                
                Close();
                e.Handled = true;
            }
        }

        private void BtnOK_OnClick(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
