using System;

namespace MonthView.EventArgs
{
    /// <summary>
    /// 日期事件参数
    /// </summary>
    public struct DayEventArgs
    {
        /// <summary>
        /// 当时时间
        /// </summary>
        public DateTime DayTime { get; set; }
    }
}