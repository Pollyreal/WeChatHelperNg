using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class SendPicsInfo
    {
        public int Count { get; set; }
        public List<PicItem> PicList { get; set; }
        public SendPicsInfo()
        {
            PicList = new List<PicItem>();
        }
    }
    public class PicItem
    {
        public Md5Sum item { get; set; }
    }
    public class Md5Sum
    {
        public string PicMd5Sum { get; set; }
    }
}
