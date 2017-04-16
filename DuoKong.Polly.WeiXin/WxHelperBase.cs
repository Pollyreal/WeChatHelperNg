using DuoKong.WeiXin.lib;
using System;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperBase
    {
        #region 基础支持//////////////////////////////////
        /// <summary>
        /// 获取accessToken
        /// </summary>
        /// <param name="AppId">应用ID</param>
        /// <param name="Secret">应用密钥</param>
        /// <returns></returns>
        public static AccessToken GetAccessToken(string AppId = "wxc4e7d610398a338b", string Secret = "3ac9745d1943cc10c1f5cf767a8dd90c")
        {
            //var AppId = "wxc4e7d610398a338b";//换成你 的信息
            //var Secret = "3ac9745d1943cc10c1f5cf767a8dd90c";//换成你的信息
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type=client_credential&appid={0}&secret={1}", AppId,Secret);
            string result = HttpService.Get(url);
            AccessToken wxResult = EntityHelper.GetJsonResultToEntity<AccessToken>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取微信服务器IP地址
        /// </summary>
        /// <param name="accessToken">access_token</param>
        /// <returns></returns>
        public static IpList GetCallbackIP(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/getcallbackip?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            IpList wxResult = EntityHelper.GetJsonResultToEntity<IpList>(result);
            return wxResult;
        }
        #endregion
    }
}
