using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class TagUserResult:WxJsonResult
    {
        public string count { get; set; }
        public OpenList data { get; set; }
        public string next_openid { get; set; }
        public TagUserResult()
        {

        }
    }
    public class OpenList{
        public string [] openid{get;set;}
    }
}
