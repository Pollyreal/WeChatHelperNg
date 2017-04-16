using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperRequest
    {
        #region 接收消息//////////////////////////////////
        /// <summary>
        /// 获取XML转换后的IRequestMessageBase实例
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IRequestMessageBase GetRequestEntity(XDocument doc)
        {
            RequestMessageBase requestMessage = null;
            try
            {
                var msgType = MsgHelper.GetRequestMsgType(doc);
                switch (msgType)
                {
                    case RequestMsgType.Text:
                        requestMessage = new RequestMessageCommonText();
                        break;
                    case RequestMsgType.Voice:
                        requestMessage = new RequestMessageCommonVoice();
                        break;
                    case RequestMsgType.ShortVideo:
                        requestMessage = new RequestMessageCommonShortVideo();
                        break;
                    case RequestMsgType.Video:
                        requestMessage = new RequestMessageCommonVideo();
                        break;
                    case RequestMsgType.Image:
                        requestMessage = new RequestMessageCommonImage();
                        break;
                    case RequestMsgType.Link:
                        requestMessage = new RequestMessageCommonLink();
                        break;
                    case RequestMsgType.Location:
                        requestMessage = new RequestMessageLocation();
                        break;
                    case RequestMsgType.Event:
                        switch (doc.Root.Element("Event").Value.ToUpper())
                        {
                            case "SUBSCRIBE":
                                requestMessage = new RequestMessageEventSubscrible();
                                break;
                            case "UNSUBSCRIBE":
                                requestMessage = new RequestMessageEventUnsubscrible();
                                break;
                            case "SCAN":
                                requestMessage = new RequestMessageEventScan();
                                break;
                            case "LOCATION":
                                requestMessage = new RequestMessageEventLocation();
                                break;
                            #region 自定义菜单事件推送
                            case "CLICK":
                                requestMessage = new RequestMessageEventClick();
                                break;
                            case "VIEW":
                                requestMessage = new RequestMessageEventView();
                                break;
                            case "MASSSENDJOBFINISH"://事件推送群发结果
                                requestMessage = new RequestMessageEventMassSendJobFinish();
                                break;
                            case "TEMPLATESENDJOBFINISH"://事件推送模版消息发送任务结果
                                requestMessage = new RequestMessageEventTemplateSendJobFinish();
                                break;
                            case "SCANCODE_PUSH"://扫码推事件的事件推送
                                requestMessage = new RequestMessageEventScancodePush();
                                break;
                            case "SCANCODE_WAITMSG"://扫码推事件且弹出“消息接收中”提示框的事件推送
                                requestMessage = new RequestMessageEventScancodeWaitmsg();
                                break;
                            case "PIC_SYSPHOTO"://弹出系统拍照发图的事件推送
                                requestMessage = new RequestMessageEventPicSysphoto();
                                break;
                            case "PIC_PHOTO_OR_ALBUM"://弹出拍照或者相册发图的事件推送
                                requestMessage = new RequestMessageEventPicPhotoOrAlbum();
                                break;
                            case "PIC_WEIXIN"://弹出微信相册发图器的事件推送
                                requestMessage = new RequestMessageEventPicWeixin();
                                break;
                            case "LOCATION_SELECT"://弹出地理位置选择器的事件推送
                                requestMessage = new RequestMessageEventLocationSelect();
                                break;
                            #endregion
                            #region 微信认证事件推送
                            case "QUALIFICATION_VERIFY_SUCCESS"://资质认证成功（此时立即获得接口权限）
                                requestMessage = new RequestMessageEventQualificationVerifySuccess();
                                break;
                            case "QUALIFICATION_VERIFY_FAIL"://资质认证失败
                                requestMessage = new RequestMessageEventQualificationVerifyFail();
                                break;
                            case "NAMING_VERIFY_SUCCESS"://名称认证成功（即命名成功）
                                requestMessage = new RequestMessageEventNamingVerifySuccess();
                                break;
                            case "NAMING_VERIFY_FAIL"://名称认证失败（这时虽然客户端不打勾，但仍有接口权限）
                                requestMessage = new RequestMessageEventNamingVerifyFail();
                                break;
                            case "ANNUAL_RENEW"://年审通知
                                requestMessage = new RequestMessageEventAnnualRenew();
                                break;
                            case "VERIFY_EXPIRED"://认证过期失效通知
                                requestMessage = new RequestMessageEventVerifyExpired();
                                break;
                            #endregion
                            default:
                                Log.Debug("GetRequestEntity", string.Format("找不到相应的Event。XML：{0}", doc.ToString()));
                                break;
                        }
                        break;
                    default:
                        Log.Debug("GetRequestEntity", string.Format("找不到相应的msgType。XML：{0}", doc.ToString()));
                        break;
                }
                EntityHelper.FillWithXML(requestMessage, doc);

            }
            catch (ArgumentException e)
            {
                Log.Debug(string.Format("GetRequestEntity 失败。XML:{0}", doc.ToString()), e.ToString());
            }
            return requestMessage;
        }
        /// <summary>
        /// 获取XML转换后的IRequestMessageBase实例
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IRequestMessageBase GetRequestEntity(string doc)
        {
            return GetRequestEntity(XDocument.Parse(doc));
        }
        /// <summary>
        /// 获取XML转换后的IRequestMessageBase实例
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public static IRequestMessageBase GetRequestEntity(Stream stream)
        {
            using (XmlReader xr = XmlReader.Create(stream))
            {
                var doc = XDocument.Load(xr);
                return GetRequestEntity(doc);
            }

        }
        #endregion
    }
}
