using System;
using System.Xml.Linq;

namespace DuoKong.Polly.WeiXin
{
    public static class MsgHelper
    {
        public static RequestMsgType GetRequestMsgType(XDocument doc)
        {
            return GetRequestMsgType(doc.Root.Element("MsgType").Value);
        }
        public static RequestMsgType GetRequestMsgType(string doc)
        {
            return (RequestMsgType)Enum.Parse(typeof(RequestMsgType), doc, true);
        }
        public static ResponseMsgType GetResponseMsgType(XDocument doc)
        {
            return GetResponseMsgType(doc.Root.Element("MsgType").Value);
        }
        public static ResponseMsgType GetResponseMsgType(string doc)
        {
            return (ResponseMsgType)Enum.Parse(typeof(ResponseMsgType), doc, true);
        }
    }
}
