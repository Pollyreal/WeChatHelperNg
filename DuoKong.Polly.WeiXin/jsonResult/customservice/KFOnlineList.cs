using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class KFOnlineList
    {
        public string kf_account { get; set; }
        /// <summary>
        /// 客服在线状态 1：pc在线，2：手机在线。若pc和手机同时在线则为 1+2=3
        /// </summary>
        public int status { get; set; }
        public string kf_id { get; set; }
        /// <summary>
        /// 客服设置的最大自动接入数
        /// </summary>
        public int auto_accept { get; set; }
        /// <summary>
        /// 客服当前正在接待的会话数
        /// </summary>
        public int accepted_case { get; set; }
    }
}
