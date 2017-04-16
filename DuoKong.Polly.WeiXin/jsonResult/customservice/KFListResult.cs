using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DuoKong.Polly.WeiXin
{
    public class KFListResult:WxJsonResult
    {
        public List<KFList> kf_list { get; set; }
        public KFListResult()
        {

        }
    }
}
