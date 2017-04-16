using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperTemplateMessage
    {
        #region 模板消息//////////////////////////////////
        /// <summary>
        /// 设置所属行业
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="industry_id1">	公众号模板消息所属行业编号</param>
        /// <param name="industry_id2">	公众号模板消息所属行业编号</param>
        /// <returns></returns>
        public static WxJsonResult TemplateSetIndustry(string accessToken, int industry_id1, int industry_id2)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/api_set_industry?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                industry_id1 = industry_id1,
                industry_id2 = industry_id2
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取设置的行业信息
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="industry_id1"></param>
        /// <param name="industry_id2"></param>
        /// <returns></returns>
        public static GetIndustry TemplateGetIndustry(string accessToken, int industry_id1, int industry_id2)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={0}", accessToken);
            dynamic result = HttpService.Get(url);
            GetIndustry wxResult = EntityHelper.GetJsonResultToEntity<GetIndustry>(result);
            return wxResult;
        }
        /// <summary>
        /// 获得模板ID
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="template_id_short"></param>
        /// <returns></returns>
        public static TemplateId TemplateGetIndustry(string accessToken, string template_id_short)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/get_industry?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                template_id_short = template_id_short
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            TemplateId wxResult = EntityHelper.GetJsonResultToEntity<TemplateId>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取模板列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static TemplateList GetTemplateList(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/get_all_private_template?access_token={0}", accessToken);
            dynamic result = HttpService.Get(url);
            TemplateList wxResult = EntityHelper.GetJsonResultToEntity<TemplateList>(result);
            return wxResult;
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="template_id">	公众帐号下模板消息ID</param>
        /// <returns></returns>
        public static WxJsonResult DeleteTemplate(string accessToken, string template_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/template/del_private_template?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                template_id = template_id
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 发送模板消息-jsonData-to be continued
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid"></param>
        /// <param name="template_id"></param>
        /// <param name="jsonData"></param>
        /// <returns></returns>
        public static MsgId SendTemplateMessage(string accessToken, string openid, string template_id, dynamic jsonData)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            MsgId wxResult = EntityHelper.GetJsonResultToEntity<MsgId>(result);
            return wxResult;
        }
        #endregion

    }
}
