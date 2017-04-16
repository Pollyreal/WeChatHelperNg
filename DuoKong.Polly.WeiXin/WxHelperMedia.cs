using DuoKong.WeiXin.lib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DuoKong.Polly.WeiXin
{
    public sealed class WxHelperMedia
    {
        #region 素材管理//////////////////////////////////
        /// <summary>
        /// 获取素材总数
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns></returns>
        public static MediaCountResult GetMediaCount(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/get_materialcount?access_token={0}", accessToken);
            string result = HttpService.Get(url);
            MediaCountResult wxResult = EntityHelper.GetJsonResultToEntity<MediaCountResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取素材列表
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="type"></param>
        /// <param name="offset"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public static string GetMediaList(string accessToken, MediaType type, int offset, int count)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/batchget_material?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                type = type.ToString(),
                offset = offset,
                count = count
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            string wxResult = result.ToString();
            return wxResult;
        }
        /// <summary>
        /// 新增临时素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileName">文件路径</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MediaResult UploadMedia(string accessToken, string fileName, MediaType type)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/upload?access_token={0}&type={1}", accessToken, type);
            dynamic result = HttpService.WeChatPostForm(url, fileName);
            MediaResult wxResult = EntityHelper.GetJsonResultToEntity<MediaResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取临时素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static string DownloadMedia(string accessToken, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/get?access_token={0}&media_id={1}", accessToken, media_id);
            string result = HttpService.Get(url);
            return result;
        }
        /// <summary>
        /// 新增永久素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="fileName">文件路径</param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static MediaResult UploadPermanentMedia(string accessToken, string fileName, MediaType type)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/add_material?access_token={0}&type={1}", accessToken, type);
            dynamic result = HttpService.WeChatPostForm(url, fileName);
            MediaResult wxResult = EntityHelper.GetJsonResultToEntity<MediaResult>(result);
            return wxResult;
        }
        /// <summary>
        /// 获取永久素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="media_id"></param>
        public static string GetPermanentMedia(string accessToken, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/get_material?access_token={0}", accessToken);
            dynamic jsonData=new{
                media_id=media_id
            };
            string result = HttpService.WeChatPost(url,JsonHelper.getJsonString(jsonData));
            return result;
        }
        /// <summary>
        /// 删除永久素材
        /// 1、请谨慎操作本接口，因为它可以删除公众号在公众平台官网素材管理模块中新建的图文消息、语音、视频等素材（但需要先通过获取素材列表来获知素材的media_id）
        /// 2、临时素材无法通过本接口删除
        /// 3、调用该接口需https协议
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="media_id"></param>
        /// <returns></returns>
        public static WxJsonResult DeletePermanentMedia(string accessToken, string media_id)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/del_material?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                media_id = media_id
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return result;
        }
        /// <summary>
        /// 上传图文消息内的图片获取URL【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="image"></param>
        /// <returns></returns>
        public static Url UploadImgGetUrl(string accessToken, string fileName)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadimg?access_token={0}", accessToken);
            dynamic result=HttpService.WeChatPostForm(url, fileName);
            Url wxResult = EntityHelper.GetJsonResultToEntity<Url>(result);
            return wxResult;
        }
        /// <summary>
        /// 新增永久图文素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="articles"></param>
        /// <returns></returns>
        public static News AddNews(string accessToken, List<UploadArticle> articles)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/material/add_news?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                articles = articles.Select(a => new
                {
                    thumb_media_id = a.thumb_media_id,
                    author = a.author,
                    title = a.title,
                    content_source_url = a.content_source_url,
                    content = a.content,
                    digest = a.digest,
                    show_cover_pic = a.show_cover_pic

                }).ToList()
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            News wxResult = EntityHelper.GetJsonResultToEntity<News>(result);
            return wxResult;
        }
        /// <summary>
        /// 上传图文消息素材【订阅号与服务号认证后均可用】
        /// </summary>
        /// <param name="accssToken"></param>
        /// <param name="articles"></param>
        /// <returns></returns>
        public static News UploadNews(string accessToken, List<UploadArticle> articles)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                articles = articles.Select(a => new
                {
                    thumb_media_id = a.thumb_media_id,
                    author = a.author,
                    title = a.title,
                    content_source_url = a.content_source_url,
                    content = a.content,
                    digest = a.digest,
                    show_cover_pic = a.show_cover_pic

                }).ToList()
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            News wxResult = EntityHelper.GetJsonResultToEntity<News>(result);
            return wxResult;
        }
        /// <summary>
        /// 修改永久图文素材
        /// </summary>
        /// <param name="accessToken"></param>
        /// <param name="a">文章</param>
        /// <param name="media_id">要修改的图文消息的id</param>
        /// <param name="index">要更新的文章在图文消息中的位置（多图文消息时，此字段才有意义），第一篇为0</param>
        /// <returns></returns>
        public static WxJsonResult EditNews(string accessToken, UploadArticle a, string media_id, int index)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/media/uploadnews?access_token={0}", accessToken);
            dynamic jsonData = new
            {
                media_id=media_id,
                index=index,
                articles = new{
                    thumb_media_id = a.thumb_media_id,
                    author = a.author,
                    title = a.title,
                    content_source_url = a.content_source_url,
                    content = a.content,
                    digest = a.digest,
                    show_cover_pic = a.show_cover_pic
                }
            };
            dynamic result = HttpService.WeChatPost(url, JsonHelper.getJsonString(jsonData));
            WxJsonResult wxResult = EntityHelper.GetJsonResultToEntity<WxJsonResult>(result);
            return wxResult;
        }
        #endregion
    }
}
