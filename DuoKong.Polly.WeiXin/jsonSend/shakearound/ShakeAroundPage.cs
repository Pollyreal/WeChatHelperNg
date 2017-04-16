using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public class ShakeAroundPage
    {
        /// <summary>
        /// 摇周边页面唯一ID
        /// </summary>
        public int page_id { get; set; }
        /// <summary>
        /// 在摇一摇页面展示的主标题，不超过6个汉字或12个英文字母
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 在摇一摇页面展示的副标题，不超过7个汉字或14个英文字母
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string page_url { get; set; }
        /// <summary>
        /// 页面的备注信息，不超过15个汉字或30个英文字母
        /// </summary>
        public string comment { get; set; }
        /// <summary>
        /// 在摇一摇页面展示的图片。图片需先上传至微信侧服务器，用“素材管理-上传图片素材”接口上传图片，返回的图片URL再配置在此处
        /// </summary>
        public string icon_url { get; set; }

    }
}
