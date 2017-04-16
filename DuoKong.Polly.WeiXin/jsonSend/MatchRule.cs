using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class MatchRule
    {
        public string tag_id { get; set; }
        public string sex { get; set; }
        public string country { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string client_platform_type { get; set; }
        public string language { get; set; }//enum
    }
}
