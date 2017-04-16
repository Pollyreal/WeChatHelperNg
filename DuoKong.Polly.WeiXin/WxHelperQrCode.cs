using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperQrCode
    {
        #region 推广支持//////////////////////////////////
        /// <summary>
        /// 生成带参数的二维码
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="expire_seconds">该二维码有效时间，以秒为单位。 最大不超过2592000（即30天），此字段如果不填，则默认有效期为30秒。</param>
        /// <param name="qrCodeType">二维码类型，QR_SCENE为临时,QR_LIMIT_SCENE为永久,QR_LIMIT_STR_SCENE为永久的字符串参数值</param>
        /// <param name="scene_id">场景值ID，临时二维码时为32位非0整型，永久二维码时最大值为100000（目前参数只支持1--100000）</param>
        /// <param name="scene_str">场景值ID（字符串形式的ID），字符串类型，长度限制为1到64，仅永久二维码支持此字段   </param>
        public static CreateQRCodeResult CreateQRCode(string accessToken, QRCodeType qrCodeType, string expire_seconds = null, string scene_id = null, string scene_str = null)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/qrcode/create?access_token={0}", accessToken);
            dynamic jsonData = null;
            if (qrCodeType == QRCodeType.QR_SCENE)
            {
                jsonData = new
                {
                    expire_seconds = expire_seconds,
                    action_name = "QR_SCENE",
                    action_info = new
                    {
                        scene = new
                        {
                            scene_id = scene_id
                        }
                    }
                };
            }
            else if (qrCodeType == QRCodeType.QR_LIMIT_SCENE)
            {
                jsonData = new
                {
                    action_name = "QR_LIMIT_SCENE",
                    action_info = new
                    {
                        scene = new
                        {
                            scene_id = scene_id
                        }
                    }
                };
            }
            else if (qrCodeType == QRCodeType.QR_LIMIT_STR_SCENE)
            {
                jsonData = new
                {
                    action_name = "QR_LIMIT_STR_SCENE",
                    action_info = new
                    {
                        scene = new
                        {
                            scene_str = scene_str
                        }
                    }
                };
            }
            else
            {
                Log.Debug("CreateQRCode", "无该类型的QRCodeType");
            }
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            CreateQRCodeResult wxResult = EntityHelper.GetJsonResultToEntity<CreateQRCodeResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 通过ticket换取二维码
        /// </summary>
        /// <param name="ticket">获取二维码ticket后，开发者可用ticket换取二维码图片。请注意，本接口无须登录态即可调用。</param>
        /// <returns></returns>
        public static string GetQRcode(string ticket)
        {
            string url = string.Format("https://mp.weixin.qq.com/cgi-bin/showqrcode?ticket={0}", ticket);
            string result = HttpService.Get(url);
            return result;
        }
        #endregion

    }
}
