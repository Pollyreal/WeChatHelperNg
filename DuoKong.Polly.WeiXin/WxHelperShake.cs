using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperShake
    {


        #region 页面管理
        /// <summary>
        /// 查询页面列表
        /// </summary>
        /// <param name="type">查询类型。
        /// 1： 查询页面id列表中的页面信息；
        /// 2：分页查询所有页面信息
        /// 3：分页查询某次申请的所有设备信息
        /// </param>
        /// <param name="page_ids">	指定页面的id列表；当type为1时，此项为必填</param>
        /// <param name="begin">页面列表的起始索引值；当type为2时，此项为必填</param>
        /// <param name="count">待查询的页面数量，不能超过50个；当type为2时，此项为必填</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string SearchPage(int type, int[] page_ids, int begin, int count, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/page/search?access_token={0}", accessToken);
            dynamic jsonData = null;
            if (type == 1)
            {
                jsonData = new
                {
                    type = type,
                    page_ids = page_ids.ToArray()
                };
            }
            else if (type == 2)
            {
                jsonData = new
                {
                    type = type,
                    begin = begin,
                    count = count
                };
            }
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            //TagResult wxResult = EntityHelper.GetJsonResultToEntity<TagResult>(result);
            return result;
        }
       

        /// <summary>
        /// 微信摇一摇新增页面
        /// </summary>
        /// <param name="shakePage"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ShakeAroundAddPageResult AddPage(ShakeAroundPage shakePage, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/page/add?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                title = shakePage.title,
                description = shakePage.description,
                page_url = shakePage.page_url,
                comment = shakePage.comment,
                icon_url = shakePage.icon_url
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            ShakeAroundAddPageResult wxResult = EntityHelper.GetJsonResultToEntity<ShakeAroundAddPageResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 微信摇一摇编辑页面信息
        /// </summary>
        /// <param name="shakePage"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ShakeAroundAddPageResult UpdatePage(ShakeAroundPage shakePage, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/page/update?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                page_id = shakePage.page_id,
                title = shakePage.title,
                description = shakePage.description,
                page_url = shakePage.page_url,
                comment = shakePage.comment,
                icon_url = shakePage.icon_url
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            ShakeAroundAddPageResult wxResult = EntityHelper.GetJsonResultToEntity<ShakeAroundAddPageResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 删除页面
        /// 只有页面与设备没有关联关系时，才可被删除。
        /// </summary>
        /// <param name="page_id"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ShakeAroundAddPageResult DeletePage(int page_id, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/page/delete?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                page_id = page_id
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            ShakeAroundAddPageResult wxResult = EntityHelper.GetJsonResultToEntity<ShakeAroundAddPageResult>(result);
            return wxResult;
        }
        #endregion
        #region 设备管理
        /// <summary>
        /// 申请设备ID
        /// </summary>
        /// <param name="apply"></param>
        /// <param name="accessToken"></param>
        /// <returns>
        /// 审核状态。
        /// 申请的批次ID，可用在“查询设备列表”接口按批次查询本次申请成功的设备ID。
        /// </returns>
        public static ShakeAroundApplyDeviceResult ApplyId(ApplyDevice apply, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/device/applyid?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                quantity = apply.quantity,
                apply_reason = apply.apply_reason,
                comment = apply.comment,
                poi_id = apply.poi_id,
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            ShakeAroundApplyDeviceResult wxResult = EntityHelper.GetJsonResultToEntity<ShakeAroundApplyDeviceResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 查询设备ID申请审核状态
        /// </summary>
        /// <param name="apply_id">批次ID，申请设备ID时所返回的批次ID</param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static ShakeAroundApplyStatusResult ApplyStatus(int apply_id, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/device/applystatus?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                apply_id = apply_id,
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            ShakeAroundApplyStatusResult wxResult = EntityHelper.GetJsonResultToEntity<ShakeAroundApplyStatusResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 编辑设备信息
        /// 编辑设备的备注信息。可用设备ID或完整的UUID、Major、Minor指定设备，二者选其一。
        /// </summary>
        /// <param name="deviceinfo"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WxJsonResult UpdateDevice(ShakeDeviceInfo deviceinfo, string comment, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/device/update?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                device_identifier = new
                {
                    device_id = deviceinfo.device_id,
                    uuid = deviceinfo.uuid,
                    major = deviceinfo.major,
                    minor = deviceinfo.minor,
                },
                comment = comment
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 配置设备与门店的关联关系
        /// 修改设备关联的门店ID。可用设备ID或完整的UUID、Major、Minor指定设备，二者选其一。
        /// </summary>
        /// <param name="deviceinfo"></param>
        /// <param name="poi_id"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static WxJsonResult BindLocation(ShakeDeviceInfo deviceinfo, int poi_id, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/device/update?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                device_identifier = new
                {
                    device_id = deviceinfo.device_id,
                    uuid = deviceinfo.uuid,
                    major = deviceinfo.major,
                    minor = deviceinfo.minor,
                },
                poi_id = poi_id
            };
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 查询设备列表
        /// </summary>
        /// <param name="type">3</param>
        /// <param name="page_ids"></param>
        /// <param name="begin"></param>
        /// <param name="count"></param>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static string SearchDevice(int type, int[] page_ids, int apply_id, int begin, int count, string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/shakearound/device/search?access_token={0}", accessToken);
            dynamic jsonData = null;
            if (type == 1)
            {
                jsonData = new
                {
                    type = type,
                    page_ids = page_ids.ToArray()
                };
            }
            else if (type == 2)
            {
                jsonData = new
                {
                    type = type,
                    begin = begin,
                    count = count
                };
            }
            else if (type == 3)
            {
                jsonData = new
                {
                    type = type,
                    apply_id = apply_id,
                    begin = begin,
                    count = count
                };
            }
            string result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            //TagResult wxResult = EntityHelper.GetJsonResultToEntity<TagResult>(result);
            return result;
        }
        #endregion
        #region 管理设备与页面的关联关系
        #endregion
    }
}
