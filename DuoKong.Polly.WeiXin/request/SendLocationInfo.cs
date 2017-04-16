using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class SendLocationInfo
    {
        public string Location_X { get; set; }
        public string Location_Y { get; set; }
        /// <summary>
        /// 精度，可理解为精度或者比例尺、越精细的话 scale越高
        /// </summary>
        public string Scale { get; set; }
        /// <summary>
        /// 地理位置的字符串信息
        /// </summary>
        public string Label { get; set; }
        /// <summary>
        /// 朋友圈POI的名字，可能为空
        /// </summary>
        public string Poiname { get; set; }

    }
}
