using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    /// <summary>
    /// 文本消息
    /// </summary>
    public class RequestMessageCommonText:RequestMessageCommonBase,IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Text;
            }
        }
        /// <summary>
        /// 文本消息内容
        /// </summary>
        public string Content { get; set; }
    }
    /// <summary>
    /// 图片消息
    /// </summary>
    public class RequestMessageCommonImage : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Image;
            }
        }
        /// <summary>
        /// 图片链接
        /// </summary>
        public string PicUrl { get; set; }
        /// <summary>
        /// 图片消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
    }
    /// <summary>
    /// 语音消息
    /// </summary>
    public class RequestMessageCommonVoice : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Voice;
            }
        }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
    }
    /// <summary>
    /// 语音消息-开通语音识别
    /// </summary>
    public class RequestMessageCommonVoiceRecongnition : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Voice;
            }
        }
        /// <summary>
        /// 语音格式，如amr，speex等
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// 语音消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 语音识别结果，使用UTF8编码
        /// </summary>
        public string Recognition { get; set; }
    }
    /// <summary>
    /// 视频消息
    /// </summary>
    public class RequestMessageCommonVideo : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Video;
            }
        }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 小视频消息
    /// </summary>
    public class RequestMessageCommonShortVideo : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.ShortVideo;
            }
        }
        /// <summary>
        /// 视频消息媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string MediaId { get; set; }
        /// <summary>
        /// 视频消息缩略图的媒体id，可以调用多媒体文件下载接口拉取数据。
        /// </summary>
        public string ThumbMediaId { get; set; }
    }
    /// <summary>
    /// 地理位置消息
    /// </summary>
    public class RequestMessageCommonLocation : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Location;
            }
        }
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public long Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public long Location_Y { get; set; }
        /// <summary>
        /// 地图缩放大小
        /// </summary>
        public long Scale { get; set; }
        /// <summary>
        /// 地理位置信息
        /// </summary>
        public string Label { get; set; }
    }
    /// <summary>
    /// 链接消息
    /// </summary>
    public class RequestMessageCommonLink : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Link;
            }
        }
        /// <summary>
        /// 消息标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 消息描述
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 消息链接
        /// </summary>
        public string Url { get; set; }
    }
    /// <summary>
    /// 地理位置
    /// </summary>
    public class RequestMessageLocation : RequestMessageCommonBase, IRequestMessageCommonBase
    {
        public override RequestMsgType MsgType
        {
            get
            {
                return RequestMsgType.Location;
            }
        }
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public long Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public long Location_Y { get; set; }
        /// <summary>
        /// 精度，可理解为精度或者比例尺、越精细的话 scale越高
        /// </summary>
        public long Scale { get; set; }
        /// <summary>
        /// 地理位置的字符串信息
        /// </summary>
        public string Label { get; set; }
    }
}
