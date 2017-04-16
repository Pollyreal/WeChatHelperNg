using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class MediaResult:WxJsonResult
    {
        public MediaType type { get; set; }
        public string media_id { get; set; }
        /// <summary>
        /// 媒体文件上传时间戳-临时素材才会返回
        /// </summary>
        public long created_at { get; set; }
    }
}
