using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperUser
    {
        #region 用户管理//////////////////////////////////
        #region 用户标签管理
        /// <summary>
        /// 创建标签
        /// 一个公众号，最多可以创建100个标签。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tag"></param>
        /// <returns></returns>
        public static TagResult CreateUserTag(string accessToken, string tag)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/create?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                tag = new
                {
                    name = tag
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            TagResult wxResult = EntityHelper.GetJsonResultToEntity<TagResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取公众号已创建的标签
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static TagsResult GetUserTag(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/get?access_token={0}", accessToken);
            dynamic result = HttpService.Get(url);
            TagsResult wxResult = EntityHelper.GetJsonResultToEntity<TagsResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 编辑标签
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static WxJsonResult EditUserTag(string accessToken, string id, string name)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/update?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                tag = new
                {
                    id = id,
                    name = name
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 删除标签 
        /// 当某个标签下的粉丝超过10w时，后台不可直接删除标签。
        /// 此时，开发者可以对该标签下的openid列表，先进行取消标签的操作，
        /// 直到粉丝数不超过10w后，才可直接删除该标签。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public static WxJsonResult DeleteUserTag(string accessToken, string id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/delete?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                tag = new
                {
                    id = id
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取标签下粉丝列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="tagid"></param>
        /// <param name="next_openid"></param>
        /// <returns></returns>
        public static TagUserResult GetUserTagUser(string accessToken, string tagid, string next_openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/tag/get?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                tagid = tagid,
                next_openid = next_openid
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            TagUserResult wxResult = EntityHelper.GetJsonResultToEntity<TagUserResult>(result);
            return wxResult;
        }
        #endregion
        #region 标签用户管理
        /// <summary>
        /// 批量为用户打标签
        /// 标签功能目前支持公众号为用户打上最多三个标签。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid_list">粉丝列表</param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static WxJsonResult BatchTagging(string accessToken, string[] openid_list, string tagid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchtagging?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                openid_list = openid_list.ToList(),
                tagid = tagid
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 批量为用户取消标签
        /// 标签功能目前支持公众号为用户打上最多三个标签。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid_list">粉丝列表</param>
        /// <param name="tagid"></param>
        /// <returns></returns>
        public static WxJsonResult BatchUnTagging(string accessToken, string[] openid_list, string tagid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/members/batchuntagging?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                openid_list = openid_list.ToList(),
                tagid = tagid
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取用户身上的标签列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid"></param>
        /// <returns></returns>
        public static TagListResult GetTagList(string accessToken, string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/tags/getidlist?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                openid = openid
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            TagListResult wxResult = EntityHelper.GetJsonResultToEntity<TagListResult>(result);
            return wxResult;
        }
        #endregion
        /// <summary>
        /// 设置用户备注名
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid"></param>
        /// <param name="remark">设置备注名</param>
        /// <returns></returns>
        public static WxJsonResult RemarkUser(string accessToken, string openid, string remark)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/updateremark?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                openid = openid,
                remark = remark
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid"></param>
        /// <param name="lang"></param>
        /// <returns></returns>
        public static UserInfoResult GetUserInfo(string accessToken, string openid, string lang = "zh_CN")
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}", accessToken, openid, lang);
            string result = HttpService.Get(url);
            UserInfoResult wxResult = EntityHelper.GetJsonResultToEntity<UserInfoResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 批量获取用户基本信息
        /// 最多支持一次拉取100条。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="user_list"></param>
        /// <returns></returns>
        public static UserInfoListResult GetUserInfoList(string accessToken, List<GetUser> user_list)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info/batchget?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                user_list = user_list.Select(a => new
                {
                    openid = a.openid,
                    lang = a.lang
                }).ToList()
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            UserInfoListResult wxResult = EntityHelper.GetJsonResultToEntity<UserInfoListResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取用户列表
        /// 一次拉取调用最多拉取10000个关注者的OpenID
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="next_openid">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        public static GetUserResult GetUserList(string accessToken, string next_openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}&next_openid={1}", accessToken, next_openid);
            string result = HttpService.Get(url);
            GetUserResult wxResult = EntityHelper.GetJsonResultToEntity<GetUserResult>(result);
            return wxResult;
        }
        #endregion

    }
}
