using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public abstract class RequestMessageEventBase : RequestMessageBase, IRequestMessageEventBase
    {
        public RequestMessageEventBase()
        {

        }
        public string Encrypt { get; set; }
        public virtual EventType Event { get { return EventType.Subscribe; } }
        
        public RequestMsgType MsgType { get { return RequestMsgType.Event; } }
    }
    public interface IRequestMessageEventBase : IRequestMessageBase
    {
        string Encrypt { get; set; }
        EventType Event { get; }
        RequestMsgType MsgType { get; }
    }
}
