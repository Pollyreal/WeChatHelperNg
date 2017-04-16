using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ShakeAroundApplyStatusResult : WxJsonResult
    {
        public ShakeAroundApplyStatus data { get; set; }
        public ShakeAroundApplyStatusResult()
        {
            data = new ShakeAroundApplyStatus();
        }
    }
    public class ShakeAroundApplyStatus
    {
        /// <summary>
        /// 提交申请的时间戳
        /// </summary>
        public string apply_time { get; set; }
        /// <summary>
        /// 审核备注，对审核状态的文字说明
        /// </summary>
        public string audit_comment { get; set; }
        /// <summary>
        /// 审核状态。0：审核未通过、1：审核中、2：审核已通过；
        /// 若单次申请的设备ID数量小于等于500个，系统会进行快速审核；
        /// 若单次申请的设备ID数量大于500个，会在三个工作日内完成审核；
        /// </summary>
        public int audit_status { get; set; }
        /// <summary>
        /// 确定审核结果的时间戳，若状态为审核中，则该时间值为0
        /// </summary>
        public int audit_time { get; set; }
    }
}
