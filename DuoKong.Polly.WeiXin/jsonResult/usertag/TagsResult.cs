using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class TagsResult:WxJsonResult
    {
        public List<ATag> tags { get; set; }
        public TagsResult()
        {

        }
    }
    public class ATag
    {
        public string id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
    }
}
