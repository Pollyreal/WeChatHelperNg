using System;
namespace DuoKong.Polly.WeiXin
{
    interface IWxJsonResult
    {
        global::DuoKong.Polly.WeiXin.ReturnCode errcode { get; set; }
        void errcodeHelper(string errcode);
        string errmsg { get; set; }
    }
}
