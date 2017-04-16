using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ApplyDevice
    {
        /// <summary>
        /// 是否必须：是
        /// 申请的设备ID的数量，单次新增设备超过500个，需走人工审核流程
        /// </summary>
        public int quantity { get; set; }
        /// <summary>
        /// 是否必须：是
        /// 申请理由，不超过100个汉字或200个英文字母
        /// </summary>
        public string apply_reason { get; set; }
        /// <summary>
        /// 是否必须：否
        /// 备注，不超过15个汉字或30个英文字母
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 是否必须：否
        /// 设备关联的门店ID，关联门店后，在门店1KM的范围内有优先摇出信息的机会。门店相关信息具体可查看门店相关的接口文档
        /// </summary>
        public int poi_id { get; set; }
    }
}
