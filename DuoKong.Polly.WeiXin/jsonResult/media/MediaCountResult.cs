using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class MediaCountResult : WxJsonResult, IWxJsonResult
    {
        public int voice_count { get; set; }
        public int video_count { get; set; }
        public int image_count { get; set; }
        public int news_count { get; set; } 
    }
}
