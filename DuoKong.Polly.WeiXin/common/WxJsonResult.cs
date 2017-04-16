using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class WxJsonResult : IWxJsonResult
    {
        public ReturnCode errcode { get; set; }
        public string errmsg { get; set; }
        public void errcodeHelper(string errcode)
        {
            this.errcode=(ReturnCode)Enum.Parse(typeof(ReturnCode), errcode, true);
        }
        public WxJsonResult()
        {
        }
    }
}
