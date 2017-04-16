using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class ResponseMessageBase:MessageBase,IResponseMessageBase
    {
        public ResponseMessageBase()
        {

        }
        public string Encrypt { get; set; }
        public virtual ResponseMsgType MsgType { get { return ResponseMsgType.Text; } }
    }
    public interface IResponseMessageBase : IMessageBase
    {
        string Encrypt { get; set; }
        ResponseMsgType MsgType { get; }
    }
}
