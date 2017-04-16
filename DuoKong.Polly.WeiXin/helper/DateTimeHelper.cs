using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public static class DateTimeHelper
    {
        public static DateTime BaseTime = new DateTime(1970, 1, 1);//Unix起始时间
        /// <summary>
        /// 将微信时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信时间戳</param>
        /// <returns>DateTime</returns>
        public static DateTime ConvertToDateTime(long dateTimeFromXml)
        {
            DateTime startTime=TimeZone.CurrentTimeZone.ToLocalTime(BaseTime);
            return startTime.AddMilliseconds(dateTimeFromXml*1000);
        }
        /// <summary>
        /// 将微信时间戳转换为DateTime类型时间
        /// </summary>
        /// <param name="dateTimeFromXml">微信时间戳</param>
        /// <returns>DateTime</returns>
        public static DateTime ConvertToDateTime(string dateTimeFromXml)
        {
            return ConvertToDateTime(long.Parse(dateTimeFromXml));
        }
        /// <summary>
        /// 将DateTime类型时间转换为微信时间戳
        /// </summary>
        /// <param name="dateTime">DateTime</param>
        /// <returns>微信时间戳</returns>
        public static long ConvertToTimeStamp(DateTime dateTime)
        {
            DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(BaseTime);
            long t = (dateTime.Ticks - startTime.Ticks) / 10000000;
            return t;
        }
    }
}
