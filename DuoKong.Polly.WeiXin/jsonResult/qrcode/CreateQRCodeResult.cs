using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class CreateQRCodeResult:WxJsonResult
    {
        public string ticket { get; set; }
        public string expire_seconds { get; set; }
        public string url { get; set; }
    }
}
