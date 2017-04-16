using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public interface IRequestMessageCommonBase : IRequestMessageBase
    {
        string Encrypt { get; set; }
        long MsgId { get; set; }
        RequestMsgType MsgType { get; }
    }
    public class RequestMessageCommonBase : RequestMessageBase, IRequestMessageCommonBase
    {
        public RequestMessageCommonBase()
        {

        }
        public string Encrypt { get; set; }
        public long MsgId { get; set; }
        
        public virtual RequestMsgType MsgType { get { return RequestMsgType.Text; } }
    }
}
