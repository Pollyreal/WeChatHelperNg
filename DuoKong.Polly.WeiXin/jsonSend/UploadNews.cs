﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class UploadArticle
    {
        public string title { get; set; }
        public string thumb_media_id { get; set; }
        public string author { get; set; }
        public string digest { get; set; }
        public string show_cover_pic { get; set; }
        public string content { get; set; }
        public string content_source_url { get; set; }
    }
}
