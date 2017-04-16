using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class KFListOnlineResult : WxJsonResult
    {
        public List<KFOnlineList> kf_online_list { get; set; }
        public KFListOnlineResult()
        {

        }
    }
}
