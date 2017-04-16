using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class IpList:WxJsonResult,IWxJsonResult
    {
        public string[] ip_list { get; set; }
    }
    public class AccessToken : WxJsonResult, IWxJsonResult
    {
        public string access_token { get; set; }
        public int expires_in { get; set; }
    }
    public class Url : WxJsonResult, IWxJsonResult
    {
        public string url { get; set; }
    }
    public class News : WxJsonResult, IWxJsonResult
    {
        public string type { get; set; }
        public string media_id { get; set; }
        public long created_at { get; set; } 
    }
    public class Msg_Id : WxJsonResult, IWxJsonResult
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string msg_id { get; set; }
    }
    public  class MsgId : WxJsonResult, IWxJsonResult
    {
        /// <summary>
        /// 消息ID
        /// </summary>
        public string msgid { get; set; }
    }
}
