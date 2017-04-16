using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperMenu
    {
        #region 界面丰富//////////////////////////////////
        /// <summary>
        /// 自定义菜单创建接口
        /// </summary>
        /// <param name="jsonData"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WxJsonResult CreateMenu(List<Menu> menu, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                button = menu.Select(a => new
                {
                    type = a.type,
                    name = a.name,
                    key = a.key,
                    url = a.url,
                    media_id = a.media_id,
                    sub_button = a.sub_button.Select(b => new
                    {
                        type = b.type,
                        name = b.name,
                        key = b.key,
                        url = b.url,
                        media_id = b.media_id
                    }).ToList()
                }).ToList()
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 自定义菜单查询接口
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string GetMenu(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 获取自定义菜单配置接口
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string GetCurrentMenu(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/get_current_selfmenu_info?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 删除当前使用的自定义菜单。另请注意，在个性化菜单时，调用此接口会删除默认菜单及全部个性化菜单。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WxJsonResult DeleteMenu(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        #region 个性化菜单接口
        /// <summary>
        /// 创建个性化菜单
        /// 出于安全考虑，一个公众号的所有个性化菜单，最多只能设置为跳转到3个域名下的链接
        /// </summary>
        /// <param name="menu">菜单</param>
        /// <param name="matchRule">菜单匹配规则</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static MenuIdResult CreateConditionalMenu(List<Menu> menu, MatchRule matchRule, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/addconditional?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                button = menu.Select(a => new
                {
                    type = a.type,
                    name = a.name,
                    key = a.key,
                    url = a.url,
                    media_id = a.media_id,
                    sub_button = a.sub_button.Select(b => new
                    {
                        type = b.type,
                        name = b.name,
                        key = b.key,
                        url = b.url,
                        media_id = b.media_id
                    }).ToList()
                }).ToList(),
                matchrule = new
                {
                    tag_id = matchRule.tag_id,
                    sex = matchRule.sex,
                    country = matchRule.country,
                    province = matchRule.province,
                    city = matchRule.city,
                    client_platform_type = matchRule.client_platform_type,
                    language = matchRule.language
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            MenuIdResult wxResult = EntityHelper.GetJsonResultToEntity<MenuIdResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 删除个性化菜单
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="menuid">menuid为菜单id，可以通过自定义菜单查询接口获取。</param>
        /// <returns></returns>
        public static WxJsonResult DeleteConditionalMenu(string accessToken, string menuId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delconditional?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                menuid = menuId
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 测试个性化菜单匹配结果
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static string TryMatchConditionalMenu(string accessToken, string userId)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/trymatch?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                user_id = userId
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            return result.ToString();
        }
        #endregion
        #endregion

    }
}
