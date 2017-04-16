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
    public class ResponseMessageText:ResponseMessageBase,IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.Text; } }
        public string Content { get; set; }
    }
    /// <summary>
    /// 图片消息
    /// </summary>
    public class ResponseMessageImage : ResponseMessageBase, IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.Image; } }
        public Image Image { get; set; }
        public ResponseMessageImage()
        {
            Image = new Image();
        }
    }
    /// <summary>
    /// 语音消息
    /// </summary>
    public class ResponseMessageVoice : ResponseMessageBase, IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.Voice; } }
        public Voice Voice { get; set; }
        public ResponseMessageVoice()
        {
            Voice = new Voice();
        }
    }
    /// <summary>
    /// 视频消息
    /// </summary>
    public class ResponseMessageVideo : ResponseMessageBase, IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.Video; } }
        public Video Video { get; set; }
        public ResponseMessageVideo()
        {
            Video = new Video();
        }
    }
    /// <summary>
    /// 音乐消息
    /// </summary>
    public class ResponseMessageMusic : ResponseMessageBase, IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.Music; } }
        public Music Music { get; set; }
        public ResponseMessageMusic()
        {
            Music = new Music();
        }
    }
    /// <summary>
    /// 图文消息
    /// </summary>
    public class ResponseMessageNews : ResponseMessageBase, IResponseMessageBase
    {
        public override ResponseMsgType MsgType { get { return ResponseMsgType.News; } }
        public int ArticleCount { get { return Articles == null ? 0 : Articles.Count; } set { } }
        public List<Article> Articles { get; set; }
        public ResponseMessageNews()
        {
            Articles = new List<Article>();
        }
    }

}
