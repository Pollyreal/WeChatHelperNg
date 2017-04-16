using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    /// <summary>
    /// 微信公众平台推出新版客服功能
    /// https://mp.weixin.qq.com/cgi-bin/announce?action=getannouncement&key=1458563419&version=12&lang=zh_CN
    /// </summary>
    public sealed class WxHelperCustomService
    {
        #region 客服账号//////////////////////////////////
        #region 客服账号管理
        /// <summary>
        /// 增改删客服账号
        /// </summary>
        /// <param name="url"></param>
        /// <param name="kf_account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="nickname">客服昵称，最长6个汉字或12个英文字符</param>
        /// <param name="password">客服账号登录密码，格式为密码明文的32位加密MD5值。该密码仅用于在公众平台官网的多客服功能中使用，若不使用多客服功能，则不必设置密码</param>
        /// <returns></returns>
        private static WxJsonResult CustomAccountHelper(string url, string kf_account, string nickname, string password)
        {
            dynamic jsonData = new
            {
                kf_account = kf_account,
                nickname = nickname,
                password = password
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 添加客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="nickname">客服昵称，最长6个汉字或12个英文字符</param>
        /// <param name="password">客服账号登录密码，格式为密码明文的32位加密MD5值。该密码仅用于在公众平台官网的多客服功能中使用，若不使用多客服功能，则不必设置密码</param>
        /// <returns></returns>
        public static WxJsonResult AddCustomAccount(string accessToken, string kf_account, string nickname, string password)
        {
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/add?access_token={0}", accessToken);
            return CustomAccountHelper(url, kf_account, nickname, password);
        }
        /// <summary>
        /// 修改客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="nickname">客服昵称，最长6个汉字或12个英文字符</param>
        /// <param name="password">客服账号登录密码，格式为密码明文的32位加密MD5值。该密码仅用于在公众平台官网的多客服功能中使用，若不使用多客服功能，则不必设置密码</param>
        /// <returns></returns>
        public static WxJsonResult EditCustomAccount(string accessToken, string kf_account, string nickname, string password)
        {
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/update?access_token={0}", accessToken);
            return CustomAccountHelper(url, kf_account, nickname, password);
        }
        /// <summary>
        /// 删除客服帐号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="nickname">客服昵称，最长6个汉字或12个英文字符</param>
        /// <param name="password">客服账号登录密码，格式为密码明文的32位加密MD5值。该密码仅用于在公众平台官网的多客服功能中使用，若不使用多客服功能，则不必设置密码</param>
        /// <returns></returns>
        public static WxJsonResult DeleteCustomAccount(string accessToken, string kf_account, string nickname, string password)
        {
            string url = string.Format("https://api.weixin.qq.com/customservice/kfaccount/del?access_token={0}", accessToken);
            return CustomAccountHelper(url, kf_account, nickname, password);
        }
        /// <summary>
        /// 设置客服帐号的头像
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="kf_account">完整客服账号，格式为：账号前缀@公众号微信号</param>
        /// <param name="fileName">文件完整路径</param>
        /// <returns></returns>
        public static WxJsonResult SetCustomAccountHeadImg(string accessToken, string kf_account, string fileName)
        {
            string url = string.Format("http://api.weixin.qq.com/customservice/kfaccount/uploadheadimg?access_token={0}&kf_account={1}", accessToken, kf_account);
            dynamic result = HttpService.WeChatPostForm(url, fileName);//post/form提交图片
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取所有客服账号
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static KFListResult GetCustomAccountList(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getkflist?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            KFListResult wxResult = EntityHelper.GetJsonResultToEntity<KFListResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取在线客服接待信息
        /// 结合客服基本信息，可以开发例如“指定客服接待”等功能；结合会话记录，可以开发”在线客服实时服务质量监控“等功能。
        /// </summary>
        /// <param name="accessToken"></param>
        public static KFListOnlineResult GetOnlineCustomAccountList(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/customservice/getonlinekflist?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            KFListOnlineResult wxResult = EntityHelper.GetJsonResultToEntity<KFListOnlineResult>(result);
            return wxResult;
        }
        #endregion
        #region 客服账号-发消息
        /// <summary>
        /// 发送文本消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="content">文本消息内容</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendTextMsg(string accessToken, string openId, string content)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "text",
                text = new
                {
                    content = content
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送图片消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="media_id">发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendImageMsg(string accessToken, string openId, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "image",
                image = new
                {
                    media_id = media_id
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送语音消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="media_id">发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendVoiceMsg(string accessToken, string openId, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "voice",
                voice = new
                {
                    media_id = media_id
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送视频消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="media_id">发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID</param>
        /// <param name="thumb_media_id">缩略图的媒体ID</param>
        /// <param name="title">图文消息/视频消息/音乐消息的标题</param>
        /// <param name="description">图文消息/视频消息/音乐消息的描述</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendVideoMsg(string accessToken, string openId,
            string media_id, string thumb_media_id, string title, string description)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "video",
                video = new
                {
                    media_id = media_id,
                    thumb_media_id = thumb_media_id,
                    title = title,
                    description = description
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送音乐消息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="musicurl">	音乐链接</param>
        /// <param name="hqmusicurl">高品质音乐链接，wifi环境优先使用该链接播放音乐</param>
        /// <param name="thumb_media_id">缩略图的媒体ID</param>
        /// <param name="title">图文消息/视频消息/音乐消息的标题</param>
        /// <param name="description">图文消息/视频消息/音乐消息的描述</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendVideoMsg(string accessToken, string openId,
            string musicurl, string hqmusicurl, string thumb_media_id, string title, string description)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "music",
                music = new
                {
                    musicurl = musicurl,
                    hqmusicurl = hqmusicurl,
                    thumb_media_id = thumb_media_id,
                    title = title,
                    description = description
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送图文消息（点击跳转到外链） 图文消息条数限制在8条以内，注意，如果图文数超过8，则将会无响应。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="articles"></param>
        /// <returns></returns>
        public static WxJsonResult CustomSendNewsMsg(string accessToken, string openId,
            List<Article> articles)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);

            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "news",
                news = new
                {
                    articles = articles.Select(a => new
                    {
                        title = a.Title,
                        description = a.Description,
                        url = a.Url,
                        picurl = a.PicUrl
                    }).ToList()
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送图文消息（点击跳转到图文消息页面） 图文消息条数限制在8条以内，注意，如果图文数超过8，则将会无响应。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="media_id">发送的图片/语音/视频/图文消息（点击跳转到图文消息页）的媒体ID</param>
        /// <returns></returns>
        public static WxJsonResult CustomSendMpNewsMsg(string accessToken, string openId, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);

            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "mpnews",
                mpnews = new
                {
                    media_id = media_id
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送卡券
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openId"></param>
        /// <param name="card_id"></param>
        /// <param name="card_ext"></param>
        /// <returns></returns>
        public static WxJsonResult CustomSendWxcardMsg(string accessToken, string openId, string card_id, string card_ext)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/custom/send?access_token={0}", accessToken);

            dynamic jsonData = new
            {
                touser = openId,
                msgtype = "wxcard",
                wxcard = new
                {
                    card_id = card_id,
                    card_ext = card_ext
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        #endregion
        #endregion

    }
}
