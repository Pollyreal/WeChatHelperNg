using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class TemplateId:WxJsonResult,IWxJsonResult
    {
        public string template_id { get; set; }
    }
}
