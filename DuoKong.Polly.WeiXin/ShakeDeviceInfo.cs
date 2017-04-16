using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ShakeDeviceInfo
    {
        /// <summary>
        /// 设备编号，若填了UUID、major、minor，则可不填设备编号，若二者都填，则以设备编号为优先
        /// </summary>
        public int device_id { get; set; }
        /// <summary>
        /// UUID、major、minor，三个信息需填写完整，若填了设备编号，则可不填此信息。
        /// </summary>
        public string uuid { get; set; }
        /// <summary>
        /// UUID、major、minor，三个信息需填写完整，若填了设备编号，则可不填此信息。
        /// </summary>
        public int major { get; set; }
        /// <summary>
        /// UUID、major、minor，三个信息需填写完整，若填了设备编号，则可不填此信息。
        /// </summary>
        public int minor { get; set; }
    }
}
