using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class TemplateList
    {
        public List<Template> template_list { get; set; }
    }
    public class Template
    {
        public string template_id { get; set; }
        public string title { get; set; }
        public string primary_industry { get; set; }
        public string deputy_industry { get; set; }
        public string content { get; set; }
        public string example { get; set; }
    }
}
