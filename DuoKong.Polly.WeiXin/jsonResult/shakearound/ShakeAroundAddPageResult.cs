using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ShakeAroundAddPageResult:WxJsonResult
    {
        public ShakeAroundData data { get; set; }
        public ShakeAroundAddPageResult()
        {
            data = new ShakeAroundData();
        }
    }
    public class ShakeAroundData
    {
        public int page_id { get; set; }
    }
}
