using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class TagResult:WxJsonResult
    {
        public ATag tag { get; set; }
        public TagResult()
        {

        }
    }
}
