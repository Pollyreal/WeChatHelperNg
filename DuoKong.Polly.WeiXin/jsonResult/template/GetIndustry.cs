using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class GetIndustry:WxJsonResult,IWxJsonResult
    {
        /// <summary>
        /// 帐号设置的主营行业
        /// </summary>
        Industry primary_industry { get; set; }
        /// <summary>
        /// 帐号设置的副营行业
        /// </summary>
        Industry secondary_industry { get; set; }
    }
    public class Industry
    {
        string first_class { get; set; }
        string second_class { get; set; }
    }
}
