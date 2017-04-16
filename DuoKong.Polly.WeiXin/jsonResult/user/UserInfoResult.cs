using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class UserInfoResult:WxJsonResult
    {
        public string subscribe { get; set; }
        public string openid { get; set; }
        public string nickname { get; set; }
        public string sex { get; set; }
        public string language { get; set; }
        public string city { get; set; }
        public string province { get; set; }
        public string country { get; set; }
        public string headimgurl { get; set; }
        public long subscribe_time { get; set; }
        public string unionid { get; set; }
        public string remark { get; set; }
        public string groupid { get; set; }
        public string [] tagid_list { get; set; }
    }
}
