using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperScan
    {
        public static string GetMerchantInfo(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/scan/merchantinfo/get?access_token={0}", accessToken);
            //dynamic jsonData = new
            //{
            //    type = 2,
            //    begin = 0,
            //    count = 10
            //};
            string result = HttpService.Get(url);
            //TagResult wxResult = EntityHelper.GetJsonResultToEntity<TagResult>(result);
            return result;
        }
    }
}
