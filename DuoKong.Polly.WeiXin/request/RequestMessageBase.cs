using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class RequestMessageBase:MessageBase,IRequestMessageBase
    {
        public RequestMessageBase(){

        }
    }
    public interface IRequestMessageBase : IMessageBase
    {
        
    }
}
