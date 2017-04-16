using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperMassSend
    {
        #region 群发接口//////////////////////////////////
        /// <summary>
        /// 根据分组进行群发【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="group_id"></param>
        /// <param name="sendType"></param>
        /// <param name="media">mediaId</param>
        /// <param name="is_to_all">群发到的分组的group_id，参加用户管理中用户分组接口，若is_to_all值为true，可不填写group_id</param>
        /// <returns></returns>
        public static GroupSendResult SendAllByGroup(string accessToken, string group_id, GroupSendType sendType, string media, bool is_to_all = false)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/sendall?access_token={0}", accessToken);
            dynamic jsonData = null;
            switch (sendType)
            {
                case GroupSendType.text:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id
                        },
                        text = new
                        {
                            content = media
                        },
                        msgtype = GroupSendType.text
                    };
                    break;
                case GroupSendType.image:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id,
                        },
                        image = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.image
                    };
                    break;
                case GroupSendType.voice:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id,
                        },
                        voice = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.voice
                    };
                    break;
                case GroupSendType.mpnews:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id,
                        },
                        mpnews = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpnews
                    };
                    break;
                case GroupSendType.mpvideo:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id,
                        },
                        mpvideo = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpvideo
                    };
                    break;
                case GroupSendType.wxcard:
                    jsonData = new
                    {
                        filter = new
                        {
                            is_to_all = is_to_all,
                            group_id = group_id,
                        },
                        wxcard = new
                        {
                            card_id = media
                        },
                        msgtype = GroupSendType.wxcard
                    };
                    break;
            }
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            GroupSendResult wxResult = EntityHelper.GetJsonResultToEntity<GroupSendResult>(result);
            return wxResult;

        }
        /// <summary>
        /// 根据OpenID列表群发【订阅号不可用，服务号认证后可用】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="openid"></param>
        /// <param name="sendType"></param>
        /// <param name="media"></param>
        /// <returns></returns>
        public static GroupSendResult SendAllByOpenId(string accessToken, string[] openid, GroupSendType sendType, string media)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/send?access_token={0}", accessToken);
            dynamic jsonData = null;
            switch (sendType)
            {
                case GroupSendType.text:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        text = new
                        {
                            content = media
                        },
                        msgtype = GroupSendType.text
                    };
                    break;
                case GroupSendType.image:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        image = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.image
                    };
                    break;
                case GroupSendType.voice:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        voice = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.voice
                    };
                    break;
                case GroupSendType.mpnews:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        mpnews = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpnews
                    };
                    break;
                case GroupSendType.mpvideo:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        mpvideo = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpvideo
                    };
                    break;
                case GroupSendType.wxcard:
                    jsonData = new
                    {
                        touser = openid.ToList(),
                        wxcard = new
                        {
                            card_id = media
                        },
                        msgtype = GroupSendType.wxcard
                    };
                    break;
            }
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            GroupSendResult wxResult = EntityHelper.GetJsonResultToEntity<GroupSendResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 删除群发【订阅号与服务号认证后均可用】
        /// 由于技术限制，群发只有在刚发出的半小时内可以删除，发出半小时之后将无法被删除。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg_id"></param>
        /// <returns></returns>
        public static WxJsonResult DeleteGroupSend(string accessToken, string msg_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/delete?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                msg_id = msg_id
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 预览接口【订阅号与服务号认证后均可用】
        /// 开发者可通过该接口发送消息给指定用户，在手机端查看消息的样式和排版。
        /// 为了满足第三方平台开发者的需求，在保留对openID预览能力的同时，
        /// 增加了对指定微信号发送预览的能力，但该能力每日调用次数有限制（100次），请勿滥用。
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="sendType"></param>
        /// <param name="media"></param>
        /// <param name="openid"></param>
        /// <param name="wxname"></param>
        /// <returns></returns>
        public static Msg_Id MessagePreview(string accessToken, GroupSendType sendType, string media, string openid, string wxname = null)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/preview?access_token={0}", accessToken);
            dynamic jsonData = null;
            switch (sendType)
            {
                case GroupSendType.text:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        text = new
                        {
                            content = media
                        },
                        msgtype = GroupSendType.text.ToString()
                    };
                    break;
                case GroupSendType.image:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        image = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.image.ToString()
                    };
                    break;
                case GroupSendType.voice:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        voice = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.voice.ToString()
                    };
                    break;
                case GroupSendType.mpnews:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        mpnews = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpnews.ToString()
                    };
                    break;
                case GroupSendType.mpvideo:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        mpvideo = new
                        {
                            media_id = media
                        },
                        msgtype = GroupSendType.mpvideo.ToString()
                    };
                    break;
                case GroupSendType.wxcard:
                    jsonData = new
                    {
                        towxname = wxname,
                        touser = openid,
                        wxcard = new
                        {
                            card_id = media
                        },
                        msgtype = GroupSendType.wxcard.ToString()
                    };
                    break;
            }
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            Msg_Id wxResult = EntityHelper.GetJsonResultToEntity<Msg_Id>(result);
            return wxResult;
        }
        /// <summary>
        /// 查询群发消息发送状态【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="msg_id"></param>
        /// <returns></returns>
        public static SendStatus GetSendStatus(string accessToken, string msg_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/mass/get?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                msg_id = msg_id
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            SendStatus wxResult = EntityHelper.GetJsonResultToEntity<SendStatus>(result);
            return wxResult;
        }
        #endregion

    }
}
