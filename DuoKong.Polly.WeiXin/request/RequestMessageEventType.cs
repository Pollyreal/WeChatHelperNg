using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    /// <summary>
    /// 取消关注事件
    /// </summary>
    public sealed class RequestMessageEventUnsubscrible : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.Unsubscribe; } }
    }
    ///// <summary>
    ///// 关注事件
    ///// </summary>
    //public class RequestMessageEventSubscrible:RequestMessageEventBase,IRequestMessageEventBase
    //{
    //    public override EventType Event { get { return EventType.Subscribe; } }
    //}

    /// <summary>
    /// 关注事件
    /// </summary>
    public class RequestMessageEventSubscrible : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.Subscribe; } }
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// 未关注用户扫描带参数二维码，关注后微信将带场景值关注事件推送给开发者。
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// 未关注用户扫描带参数二维码，关注后微信将带场景值关注事件推送给开发者。
        /// </summary>
        public string Ticket { get; set; }
    }
    /// <summary>
    /// 已关注用户扫描带参数二维码事件
    /// </summary>
    public class RequestMessageEventScan : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.Scan; } }
        /// <summary>
        /// 事件KEY值，qrscene_为前缀，后面为二维码的参数值
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 二维码的ticket，可用来换取二维码图片
        /// </summary>
        public string Ticket { get; set; }
    }
    /// <summary>
    /// 地理位置
    /// </summary>
    public class RequestMessageEventLocation : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.Location; } }
        /// <summary>
        /// 地理位置维度
        /// </summary>
        public long Location_X { get; set; }
        /// <summary>
        /// 地理位置经度
        /// </summary>
        public long Location_Y { get; set; }
        /// <summary>
        /// 地理位置精度
        /// </summary>
        public long Precision { get; set; }
    }
    #region 自定义菜单事件推送
    /// <summary>
    /// 点击菜单拉取消息
    /// </summary>
    public class RequestMessageEventClick : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.Click; } }
        /// <summary>
        /// 事件KEY值，与自定义菜单接口中KEY值对应
        /// </summary>
        public string EventKey { get; set; }
    }
    /// <summary>
    /// 点击菜单跳转链接
    /// </summary>
    public class RequestMessageEventView : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.View; } }
        /// <summary>
        /// 事件KEY值，设置的跳转URL
        /// </summary>
        public string EventKey { get; set; }
        /// <summary>
        /// 指菜单ID，如果是个性化菜单，则可以通过这个字段，知道是哪个规则的菜单被点击了。
        /// </summary>
        public string MenuID { get; set; }
    }
    /// <summary>
    /// 事件推送群发结果
    /// 需要注意，由于群发任务彻底完成需要较长时间，
    /// 将会在群发任务即将完成的时候，就推送群发结果，此时的推送人数数据将会与实际情形存在一定误差
    /// </summary>
    public class RequestMessageEventMassSendJobFinish : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.MASSSENDJOBFINISH; } }
        /// <summary>
        /// 群发的消息ID
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 群发的结构，为“send success”或“send fail”或“err(num)”。
        /// 但send success时，也有可能因用户拒收公众号的消息、系统错误等原因造成少量用户接收失败。
        /// err(num)是审核失败的具体原因，可能的情况如下：
        /// err(10001), //涉嫌广告 err(20001), //涉嫌政治 err(20004), //涉嫌社会 err(20002), //涉嫌色情 err(20006), //涉嫌违法犯罪 err(20008), //涉嫌欺诈 err(20013), //涉嫌版权 err(22000), //涉嫌互推(互相宣传) err(21000), //涉嫌其他
        /// </summary>
        public string Status { get; set; }
        /// <summary>
        /// tag_id下粉丝数；或者openid_list中的粉丝数
        /// </summary>
        public int TotalCount { get; set; }
        /// <summary>
        /// 过滤（过滤是指特定地区、性别的过滤、用户设置拒收的过滤，用户接收已超4条的过滤）后，准备发送的粉丝数，
        /// 原则上，FilterCount = SentCount + ErrorCount
        /// </summary>
        public int FilterCount { get; set; }
        /// <summary>
        /// 发送成功的粉丝数
        /// </summary>
        public int SentCount { get; set; }
        /// <summary>
        /// 发送失败的粉丝数
        /// </summary>
        public int ErrorCount { get; set; }

    }
    public class RequestMessageEventTemplateSendJobFinish : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.TEMPLATESENDJOBFINISH; } }
        /// <summary>
        /// 消息id
        /// </summary>
        public string MsgID { get; set; }
        /// <summary>
        /// 发送状态为成功 success
        /// 发送状态为用户拒绝接收 failed:user block
        /// 发送状态为发送失败（非用户拒绝）failed: system failed
        /// </summary>
        public string Status { get; set; }
    }
    /// <summary>
    /// 扫码推事件的事件推送
    /// </summary>
    public class RequestMessageEventScancodePush : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.scancode_push; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public ScanCodeInfo ScanCodeInfo { get; set; }
        public RequestMessageEventScancodePush()
        {
            ScanCodeInfo = new ScanCodeInfo();
        }
    }
    /// <summary>
    /// 扫码推事件且弹出“消息接收中”提示框的事件推送
    /// </summary>
    public class RequestMessageEventScancodeWaitmsg : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.scancode_waitmsg; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public ScanCodeInfo ScanCodeInfo { get; set; }
        public RequestMessageEventScancodeWaitmsg()
        {
            ScanCodeInfo = new ScanCodeInfo();
        }
    }
    /// <summary>
    /// 弹出系统拍照发图的事件推送
    /// </summary>
    public class RequestMessageEventPicSysphoto : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.pic_sysphoto; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public SendPicsInfo SendPicsInfo { get; set; }
        public RequestMessageEventPicSysphoto()
        {
            SendPicsInfo = new SendPicsInfo();
        }
    }
    /// <summary>
    /// 弹出拍照或者相册发图的事件推送
    /// </summary>
    public class RequestMessageEventPicPhotoOrAlbum : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.pic_photo_or_album; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public SendPicsInfo SendPicsInfo { get; set; }
        public RequestMessageEventPicPhotoOrAlbum()
        {
            SendPicsInfo = new SendPicsInfo();
        }
    }
    /// <summary>
    /// 弹出微信相册发图器的事件推送
    /// </summary>
    public class RequestMessageEventPicWeixin : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.pic_weixin; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public SendPicsInfo SendPicsInfo { get; set; }
        public RequestMessageEventPicWeixin()
        {
            SendPicsInfo = new SendPicsInfo();
        }
    }
    /// <summary>
    /// 弹出地理位置选择器的事件推送
    /// </summary>
    public class RequestMessageEventLocationSelect : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.location_select; } }
        public string EventKey { get; set; }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public SendLocationInfo SendLocationInfo { get; set; }
        public RequestMessageEventLocationSelect()
        {
            SendLocationInfo = new SendLocationInfo();
        }
    }
    #endregion
    #region 微信认证事件推送
    /// <summary>
    /// 资质认证成功（此时立即获得接口权限）
    /// </summary>
    public class RequestMessageEventQualificationVerifySuccess : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.qualification_verify_success; } }
        public string ExpiredTime { get; set; }
    }
    /// <summary>
    /// 资质认证失败
    /// </summary>
    public class RequestMessageEventQualificationVerifyFail : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.qualification_verify_fail; } }
        public string FailTime { get; set; }
        public string FailReason { get; set; }

    }
    /// <summary>
    /// 名称认证成功（即命名成功）
    /// </summary>
    public class RequestMessageEventNamingVerifySuccess : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.naming_verify_success; } }
        public string ExpiredTime { get; set; }
    }
    /// <summary>
    /// 名称认证失败（这时虽然客户端不打勾，但仍有接口权限）
    /// </summary>
    public class RequestMessageEventNamingVerifyFail : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.naming_verify_fail; } }
        public string FailTime { get; set; }
        public string FailReason { get; set; }
    }
    /// <summary>
    /// 年审通知
    /// </summary>
    public class RequestMessageEventAnnualRenew : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.annual_renew; } }
        public string ExpiredTime { get; set; }

    }
    /// <summary>
    /// 认证过期失效通知
    /// </summary>
    public class RequestMessageEventVerifyExpired : RequestMessageEventBase
    {
        public override EventType Event { get { return EventType.verify_expired; } }
        public string ExpiredTime { get; set; }
    }
    #endregion
}
