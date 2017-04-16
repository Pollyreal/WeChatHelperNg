using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperResponse
    {
        #region 发送消息//////////////////////////////////
        /// <summary>
        ///  发送指定格式消息，根据请求消息openID
        /// </summary>
        /// <param name="request"></param>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static IResponseMessageBase GetResponseEntityFromRequest(IRequestMessageBase request, ResponseMsgType msgType)
        {
            ResponseMessageBase responseMessage = null;
            try
            {
                switch (msgType)
                {
                    case ResponseMsgType.Text:
                        responseMessage = new ResponseMessageText();
                        break;
                    case ResponseMsgType.Image:
                        responseMessage = new ResponseMessageImage();
                        break;
                    case ResponseMsgType.Voice:
                        responseMessage = new ResponseMessageVoice();
                        break;
                    case ResponseMsgType.Video:
                        responseMessage = new ResponseMessageVideo();
                        break;
                    case ResponseMsgType.Music:
                        responseMessage = new ResponseMessageMusic();
                        break;
                    case ResponseMsgType.News:
                        responseMessage = new ResponseMessageNews();
                        break;
                    default:
                        Log.Debug("CreateResponseEntity", "找不到相应的msgType");
                        break;
                }
                responseMessage.ToUserName = request.FromUserName;
                responseMessage.FromUserName = request.ToUserName;
                responseMessage.CreateTime = DateTime.Now;

            }
            catch (Exception e)
            {

            }

            return responseMessage;
        }
        /// <summary>
        /// 发送指定格式消息
        /// </summary>
        /// <param name="msgType"></param>
        /// <returns></returns>
        public static IResponseMessageBase CreateResponseEntity(ResponseMsgType msgType)
        {
            ResponseMessageBase responseMessage = null;
            try
            {
                //var msgType = MsgHelper.GetResponseMsgType(doc);
                switch (msgType)
                {
                    case ResponseMsgType.Text:
                        responseMessage = new ResponseMessageText();
                        break;
                    case ResponseMsgType.Image:
                        responseMessage = new ResponseMessageImage();
                        break;
                    case ResponseMsgType.Voice:
                        responseMessage = new ResponseMessageVoice();
                        break;
                    case ResponseMsgType.Video:
                        responseMessage = new ResponseMessageVideo();
                        break;
                    case ResponseMsgType.Music:
                        responseMessage = new ResponseMessageMusic();
                        break;
                    case ResponseMsgType.News:
                        responseMessage = new ResponseMessageNews();
                        break;
                    default:
                        Log.Debug("CreateResponseEntity", "找不到相应的msgType");
                        break;
                }

            }
            catch (Exception e)
            {

            }

            return responseMessage;
        }
        /// <summary>
        /// 获取公众号的自动回复规则
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string GetCurrentAutoreplyInfo(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/get_current_autoreply_info?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            return result;
        }
        #endregion

    }
}
