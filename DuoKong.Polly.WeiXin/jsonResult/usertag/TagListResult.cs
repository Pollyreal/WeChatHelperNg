using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class TagListResult:WxJsonResult
    {
        public string[] tagid_list { get; set; }
    }
}
