using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ShakeAroundApplyDeviceResult : WxJsonResult
    {
        public ShakeAroundApplyDevice data { get; set; }
        public ShakeAroundApplyDeviceResult()
        {
            data = new ShakeAroundApplyDevice();
        }
    }
    public class ShakeAroundApplyDevice
    {
        /// <summary>
        /// 审核状态。
        /// 0：审核未通过、1：审核中、2：审核已通过；
        /// 若单次申请的设备ID数量小于等于500个，系统会进行快速审核；
        /// 若单次申请的设备ID数量大于500个，会在三个工作日内完成审核；此时返回值全部为1(审核中)
        /// </summary>
        public int apply_id { get; set; }
        /// <summary>
        /// 申请的批次ID，可用在“查询设备列表”接口按批次查询本次申请成功的设备ID。
        /// </summary>
        public int audit_status { get; set; }
        /// <summary>
        /// 审核备注，对审核状态的文字说明
        /// </summary>
        public string audit_comment { get; set; }
    }
}
