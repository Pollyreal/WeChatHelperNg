using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Configuration;
using DuoKong.Polly.WeiXin;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace WxHelperByPollyNg
{
    public partial class Form1 : Form
    {
        UserConfig userConfig;//加载配置
        //获取accessToken
        public string accessToken { get { return userConfig.accessToken; } }
        /// <summary>
        /// my appId and secret
        /// </summary>
        public string GetAccessToken { get { return DuoKong.Polly.WeiXin.WxHelperBase.GetAccessToken("appId", "secret").access_token; } }
        
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //初始化下拉框
            comboBox1.SelectedIndex = 0;
            //初始化文件对话框
            openFileDialog1.FileName = "";

            //标题
            this.Text = "wxHelperTest " + UserConfig.configPath;

            //序列化文件
            string filePath = UserConfig.configPath;
            if (filePath.Trim() == "") filePath = "userConfig.dat";
            if (!File.Exists(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Create);
                UserConfig userConfig = new UserConfig();
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, userConfig);
                fs.Close();
            }
            //反序列化
            FileStream fss = new FileStream(UserConfig.configPath, FileMode.Open);
            BinaryFormatter bff = new BinaryFormatter();
            this.userConfig = bff.Deserialize(fss) as UserConfig;
            responseBox.Text = "当前accesstoken：\n" + this.userConfig.accessToken;
            fss.Close();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            responseBox.Clear();

            //获取ip
            var result = DuoKong.Polly.WeiXin.WxHelperBase.GetCallbackIP(accessToken);
            //ip地址
            if (result.errcode == ReturnCode.请求成功)
            {
                foreach (var i in result.ip_list)
                {
                    responseBox.AppendText(i + "\n");
                }
            }
            else{
                responseBox.Text = result.errcode.ToString()+"\n"+result.errmsg.ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //获取客服列表
            var result = DuoKong.Polly.WeiXin.WxHelperCustomService.GetCustomAccountList(accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" ;
                foreach (var i in result.kf_list)
                {
                    responseBox.AppendText("kf_id" + i.kf_id + "\n");
                    responseBox.AppendText("kf_nick" + i.kf_nick + "\n");
                    responseBox.AppendText("kf_account" + i.kf_account + "\n");
                    responseBox.AppendText("kf_headimgurl" + i.kf_headimgurl + "\n");
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }
        private List<DuoKong.Polly.WeiXin.Menu> getConditionalMenu()
        {
            //创建自定义菜单
            var menu = new List<DuoKong.Polly.WeiXin.Menu>();
            var menu0 = new DuoKong.Polly.WeiXin.Menu();
            var menu1 = new DuoKong.Polly.WeiXin.Menu();
            var menu2 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button00 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button01 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button02 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button03 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button04 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button10 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button11 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button12 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button13 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button14 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button20 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button21 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button22 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button23 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button24 = new DuoKong.Polly.WeiXin.Menu();

            menu0.name = "Vk";
            sub_button00.type = ButtonType.view.ToString();
            sub_button00.name = "Main";
            sub_button00.url = "http://wxtest.yomelife.com/";
            sub_button01.type = ButtonType.view.ToString();
            sub_button01.name = "Vk";
            sub_button01.url = "http://wxtest.yomelife.com/Vk";

            menu1.name = "一级菜单";
            sub_button10.type = ButtonType.click.ToString();
            sub_button10.name = "click";
            sub_button10.key = "click_1";
            sub_button11.type = ButtonType.scancode_push.ToString();
            sub_button11.name = ButtonType.scancode_push.ToString();
            sub_button11.key = "scancode_push_1";
            sub_button12.type = ButtonType.scancode_waitmsg.ToString();
            sub_button12.name = ButtonType.scancode_waitmsg.ToString();
            sub_button12.key = "scancode_waitmsg_1";
            sub_button13.type = ButtonType.pic_sysphoto.ToString();
            sub_button13.name = ButtonType.pic_sysphoto.ToString();
            sub_button13.key = "pic_sysphoto_1";
            sub_button14.type = ButtonType.pic_photo_or_album.ToString();
            sub_button14.name = ButtonType.pic_photo_or_album.ToString();
            sub_button14.key = "pic_photo_or_album_1";
            menu2.name = "一级菜单";
            sub_button20.type = ButtonType.pic_weixin.ToString();
            sub_button20.name = ButtonType.pic_weixin.ToString();
            sub_button20.key = "pic_weixin_1";
            sub_button21.type = ButtonType.location_select.ToString();
            sub_button21.name = ButtonType.location_select.ToString();
            sub_button21.key = "location_select_1";
            sub_button22.type = ButtonType.click.ToString();
            sub_button22.name = "音乐";
            sub_button22.key = "click_2";
            sub_button23.type = ButtonType.click.ToString();
            sub_button23.name = "图片";
            sub_button23.key = "click_3";
            //sub_button22.type = ButtonType.media_id.ToString();
            //sub_button22.name = ButtonType.media_id.ToString();
            //sub_button22.media_id = "media_id_1";
            //sub_button23.type = ButtonType.view_limited.ToString();
            //sub_button23.name = ButtonType.view_limited.ToString();
            //sub_button23.media_id = "view_limited_1";

            menu0.sub_button.Add(sub_button00);
            menu0.sub_button.Add(sub_button01);

            menu1.sub_button.Add(sub_button10);
            menu1.sub_button.Add(sub_button11);
            menu1.sub_button.Add(sub_button12);
            menu1.sub_button.Add(sub_button13);
            menu1.sub_button.Add(sub_button14);

            menu2.sub_button.Add(sub_button20);
            menu2.sub_button.Add(sub_button21);
            menu2.sub_button.Add(sub_button22);
            menu2.sub_button.Add(sub_button23);

            menu.Add(menu0);
            menu.Add(menu1);
            menu.Add(menu2);

            return menu;
        }
        private List<DuoKong.Polly.WeiXin.Menu> getMenu()
        {
            //创建自定义菜单
            var menu = new List<DuoKong.Polly.WeiXin.Menu>();
            var menu0 = new DuoKong.Polly.WeiXin.Menu();
            var menu1 = new DuoKong.Polly.WeiXin.Menu();
            var menu2 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button00 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button01 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button02 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button03 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button04 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button10 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button11 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button12 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button13 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button14 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button20 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button21 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button22 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button23 = new DuoKong.Polly.WeiXin.Menu();
            var sub_button24 = new DuoKong.Polly.WeiXin.Menu();

            menu0.type = ButtonType.scancode_waitmsg.ToString();
            menu0.name = "扫码核销";
            menu0.key = "CardVerify";

            menu1.type = ButtonType.view.ToString();
            menu1.name = "输码核销";
            menu1.url = "http://xzs.duokongkeji.com/Verification/Verification/Index";

            menu2.name = "个人中心";

            sub_button20.type = ButtonType.view.ToString();
            sub_button20.name = "我的账号";
            sub_button20.url = "http://xzs.duokongkeji.com/Verification/Verification/Account";
            sub_button21.type = ButtonType.view.ToString();
            sub_button21.name = "核销记录";
            sub_button21.url = "http://xzs.duokongkeji.com/Verification/Verification/Record";

            menu2.sub_button.Add(sub_button20);
            menu2.sub_button.Add(sub_button21);
            
            menu.Add(menu0);
            menu.Add(menu1);
            menu.Add(menu2);

            return menu;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //创建自定义菜单
            var menu = getMenu();
            //返回结果
            var result = DuoKong.Polly.WeiXin.WxHelperMenu.CreateMenu(menu, accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //获取当前菜单
            var result = DuoKong.Polly.WeiXin.WxHelperMenu.GetCurrentMenu(accessToken);
            responseBox.Text = result;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            //自定义菜单查询
            var result = DuoKong.Polly.WeiXin.WxHelperMenu.GetMenu(accessToken);
            responseBox.Text = result;
        }
        private void button4_Click(object sender, EventArgs e)
        {
            string xml = "<xml>" +
             "<ToUserName>touser</ToUserName>" +
             "<FromUserName>fromuser</FromUserName>" +
             "<CreateTime>1348831860</CreateTime>" +
             "<MsgType>text</MsgType>" +
             "<Content>this is a test</Content>" +
             "<MsgId>1234567890123456</MsgId>" +
             "</xml>";
            string xmlImage = "<xml>" +
             "<ToUserName><![CDATA[toUser]]></ToUserName>" +
             "<FromUserName><![CDATA[fromUser]]></FromUserName>" +
             "<CreateTime>1348831860</CreateTime>" +
             "<MsgType><![CDATA[image]]></MsgType>" +
             "<PicUrl><![CDATA[this is a url]]></PicUrl>" +
             "<MediaId><![CDATA[media_id]]></MediaId>" +
             "<MsgId>1234567890123456</MsgId>" +
             "</xml>";
            string xmlClick = "<xml>" +
              "<ToUserName><![CDATA[gh_4de0c537e7b7]]></ToUserName>" +
              "<FromUserName><![CDATA[oxRYfv448CTs9cVpbhFL10aZ_Gx4]]></FromUserName>" +
              "<CreateTime>1470643770</CreateTime>" +
              "<MsgType><![CDATA[event]]></MsgType>" +
              "<Event><![CDATA[CLICK]]></Event>" +
              "<EventKey><![CDATA[click_1]]></EventKey>" +
            "</xml>";
            var requestEntity = DuoKong.Polly.WeiXin.WxHelperRequest.GetRequestEntity(xmlClick) as RequestMessageBase;
            var doc=EntityHelper.ConvertEntityToXml(requestEntity);
            var responseEntity = DuoKong.Polly.WeiXin.WxHelperResponse.GetResponseEntityFromRequest(requestEntity, ResponseMsgType.Text) as ResponseMessageText;
            responseEntity.Content = "hhhh";
            responseBox.Text = doc.ToString();
            responseBox.AppendText(EntityHelper.ConvertEntityToXml(responseEntity).ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //删除自定义菜单
            var result = DuoKong.Polly.WeiXin.WxHelperMenu.DeleteMenu(accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var menu = getConditionalMenu();
            //创建个性化菜单
            var matchrule = new DuoKong.Polly.WeiXin.MatchRule();
            matchrule.tag_id = "100";
            matchrule.language = "zh_CN";
            var result = WxHelperMenu.CreateConditionalMenu(menu, matchrule, accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" +result.menuid;
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            //responseBox.Text = "暂不可用，未配置user tag";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var menuid = textBox1.Text.Trim();
            if (menuid == "") { responseBox.Text = "请在文本框中输入menuid"; return; }
            var result = WxHelperMenu.DeleteConditionalMenu(accessToken, menuid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" ;
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //测试个性化菜单匹配结果
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在文本框中输入openid或微信号"; return; }
            var result = WxHelperMenu.TryMatchConditionalMenu(accessToken, openid);
            responseBox.Text = result;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //创建标签
            //返回的json有错误
            var tag = textBox1.Text.Trim();
            if (tag == "") { responseBox.Text = "请在文本框中输入tag"; return; }
            var result = WxHelperUser.CreateUserTag(accessToken,tag);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("tag:"+result.tag.id +"\nname"+ result.tag.name);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            var result = WxHelperUser.GetUserTag(accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                foreach (var a in result.tags)
                {
                    responseBox.AppendText("==============================\n");
                    responseBox.AppendText("id:"+a.id+"\n"+"name:"+a.name+"\n"+"count:"+a.count.ToString()+"\n");
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //编辑标签
            var id = textBox1.Text.Trim();
            if (id == "") { responseBox.Text = "请在第一个文本框中输入id"; return; }
            var tag = textBox2.Text.Trim();
            if (tag == "") { responseBox.Text = "请在第二个文本框中输入tag"; return; }
            var result=WxHelperUser.EditUserTag(accessToken, id, tag);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //删除标签
            var id = textBox1.Text.Trim();
            if (id == "") { responseBox.Text = "请在第一个文本框中输入id"; return; }
            var result = WxHelperUser.DeleteUserTag(accessToken, id);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //获取标签下粉丝列表
            var id = textBox1.Text.Trim();
            if (id == "") { responseBox.Text = "请在第一个文本框中输入tagid"; return; }
            var nextopenid = textBox2.Text.Trim();
            var result = WxHelperUser.GetUserTagUser(accessToken, id, nextopenid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" ;
                responseBox.AppendText("==============================\n");
                if (Convert.ToInt32(result.count) == 0)
                {
                    responseBox.AppendText("count:" + result.count + "\n");
                }
                else
                {
                    responseBox.AppendText("count:" + result.count + "\n" + "openid:\n");
                    foreach(var a in result.data.openid){
                        responseBox.AppendText(a+"\n");
                    }
                    responseBox.AppendText("next_openid:" + result.next_openid + "\n");
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //批量为用户打标签
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid列表,以“,”间隔"; return; }
            var tagid = textBox2.Text.Trim();
            var openidlist = openid.Split(new char[]{','});
            if (tagid == "") { responseBox.Text = "请在第二个文本框中输入tagid"; return; }
            var result = WxHelperUser.BatchTagging(accessToken, openidlist, tagid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }

        }

        private void button16_Click(object sender, EventArgs e)
        {
            //批量为用户取消标签
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid列表,以“,”间隔"; return; }
            var tagid = textBox2.Text.Trim();
            if (tagid == "") { responseBox.Text = "请在第二个文本框中输入tagid"; return; }
            var openidlist = openid.Split(new char[] { ',' });
            var result = WxHelperUser.BatchUnTagging(accessToken, openidlist, tagid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //获取用户身上的标签列表
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid"; return; }
            var result = WxHelperUser.GetTagList(accessToken, openid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("======================\n标签列表\n");
                foreach(var a in result.tagid_list){
                    responseBox.AppendText(a + "\n");
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //获取存储accesstoken
            var accesstoken=GetAccessToken;
            responseBox.Text = "accessToken :"+accesstoken+"\n已获取，请勿重复点击";
            userConfig.accessToken = accesstoken;

            //序列化文件
            FileStream fs;
            if (!File.Exists(UserConfig.configPath))
            { fs = new FileStream(UserConfig.configPath, FileMode.Create); }
            else
            { fs = new FileStream(UserConfig.configPath, FileMode.Open); }
            //修改userConfig
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs, userConfig);
            fs.Close();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //设置用户备注名
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid"; return; }
            var remark = textBox2.Text.Trim();
            if (remark == "") { responseBox.Text = "请在第二个文本框中输入remark备注名"; return; }
            var result = WxHelperUser.RemarkUser(accessToken, openid, remark);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //设置用户备注名
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid"; return; }
            var lang = textBox2.Text.Trim();
            var result = WxHelperUser.GetUserInfo(accessToken, openid, lang);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "subscribe:" + result.subscribe + "\n" +
                    "openid:" + result.openid + "\n" +
                    "nickname:" + result.nickname + "\n" +
                    "sex:" + result.sex + "\n" +
                    "language:" + result.language + "\n" +
                    "city:" + result.city + "\n" +
                    "province:" + result.province + "\n" +
                    "country:" + result.country + "\n" +
                    "headimgurl:" + result.headimgurl + "\n" +
                    "subscribe_time:" + DateTimeHelper.ConvertToDateTime(Convert.ToInt64(result.subscribe_time)).ToLocalTime() + "\n" +
                    "unionid:" + result.unionid + "\n" +
                    "remark:" + result.remark + "\n" +
                    "groupid:" + result.groupid+ "\n" +
                    "tagid_list:\n"
                    );
                foreach (var a in result.tagid_list)
                {
                    responseBox.AppendText(a);
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            //批量获取用户基本信息
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid列表,以“,”间隔"; return; }
            var lang = textBox2.Text.Trim();
            var openidlist = openid.Split(new char[] { ',' });
            List<GetUser> user_list=new List<GetUser>();
            foreach (var a in openidlist)
            {
                GetUser user = new GetUser();
                user.openid = a;
                user_list.Add(user);
            }
            var result = WxHelperUser.GetUserInfoList(accessToken, user_list);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                foreach (var a in result.user_info_list)
                {
                    responseBox.AppendText("=========================\n");
                    responseBox.AppendText(
                    "subscribe:" + a.subscribe + "\n" +
                    "openid:" + a.openid + "\n" +
                    "nickname:" + a.nickname + "\n" +
                    "sex:" + a.sex + "\n" +
                    "language:" + a.language + "\n" +
                    "city:" + a.city + "\n" +
                    "province:" + a.province + "\n" +
                    "country:" + a.country + "\n" +
                    "headimgurl:" + a.headimgurl + "\n" +
                    "subscribe_time:" + DateTimeHelper.ConvertToDateTime(Convert.ToInt64(a.subscribe_time)).ToLocalTime() + "\n" +
                    "unionid:" + a.unionid + "\n" +
                    "remark:" + a.remark + "\n" +
                    "groupid:" + a.groupid + "\n" +
                    "tagid_list:\n"
                    );
                    foreach (var aa in a.tagid_list)
                    {
                        responseBox.AppendText(aa);
                    }
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            //获取用户列表
            var nextopenid = textBox1.Text.Trim();
            //if (nextopenid == "") { responseBox.Text = "请在第一个文本框中输入tagid"; return; }
            var result = WxHelperUser.GetUserList(accessToken, nextopenid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("==============================\n");
                if (Convert.ToInt32(result.count) == 0)
                {
                    responseBox.AppendText("total:" + result.total + "\n");
                    responseBox.AppendText("count:" + result.count + "\n");
                }
                else
                {
                    responseBox.AppendText("total:" + result.total + "\n");
                    responseBox.AppendText("count:" + result.count + "\n" + "openid:\n");
                    foreach (var a in result.data.openid)
                    {
                        responseBox.AppendText(a + "\n");
                    }
                    responseBox.AppendText("next_openid:" + result.next_openid + "\n");
                }
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button23_Click(object sender, EventArgs e)
        {
            //上传文件
            openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "全部文件|*.*";
            openFileDialog1.FilterIndex = 2;
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                responseBox.Text = openFileDialog1.FileName;
            }
        }

        private void button24_Click(object sender, EventArgs e)
        {
            //新增临时素材
            if (openFileDialog1.FileName == "") {responseBox.Text = "请上传文件"; return; }
            MediaType type = (MediaType)Enum.Parse(typeof(MediaType), comboBox1.SelectedItem.ToString(), true);
            var result = WxHelperMedia.UploadMedia(accessToken, openFileDialog1.FileName, type);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "type:"+result.type.ToString()+"\n"+
                    "media_id:"+result.media_id+"\n"+
                    "created_at:"+DateTimeHelper.ConvertToDateTime(Convert.ToInt64(result.created_at)).ToLocalTime()+"\n"
                    );
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            //获取临时素材
            var mediaid = textBox1.Text.Trim();
            if (mediaid == "") { responseBox.Text = "请在第一个文本框中输入mediaid"; return; }
            string result = WxHelperMedia.DownloadMedia(accessToken, mediaid);
            responseBox.Text = result;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            //生成带参数的二维码
            var scene_id = textBox1.Text.Trim();
            if (scene_id == "") { responseBox.Text = "请在第一个文本框中输入scene_id"; return; }
            var result = WxHelperQrCode.CreateQRCode(accessToken, QRCodeType.QR_SCENE, "3600", scene_id, null);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "expire_seconds:" + result.expire_seconds + "\n" +
                    "ticket:" + result.ticket + "\n" +
                    "url:" + result.url + "\n"
                    );
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button27_Click(object sender, EventArgs e)
        {
            
            //获取公众号的自动回复规则
            string result = WxHelperResponse.GetCurrentAutoreplyInfo(accessToken);
            responseBox.Text = result;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            //添加客服帐号
            var kf_account = textBox1.Text.Trim();
            if (kf_account == "") { responseBox.Text = "请在第1个文本框中输入kf_account\n完整客服账号，格式为：账号前缀@公众号微信号\n此处输入账号前缀"; return; }
            kf_account+="@"+ConfigurationManager.AppSettings["ConfigFilePath"].ToString();
            var nickname = textBox2.Text.Trim();
            if (nickname == "") { responseBox.Text = "请在第2个文本框中输入nickname\n客服昵称，最长6个汉字或12个英文字符"; return; }
            var password = textBox3.Text.Trim();
            if (password == "") { responseBox.Text = "请在第3个文本框中输入password"; return; }
            var MD5password = MD5UtilHelper.GetMD5(password, null);
            var result = WxHelperCustomService.AddCustomAccount(accessToken, kf_account, nickname, MD5password);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
                
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button29_Click(object sender, EventArgs e)
        {
            //修改客服帐号
        }

        private void button30_Click(object sender, EventArgs e)
        {
            //删除客服帐号
        }

        private void button32_Click(object sender, EventArgs e)
        {
            //获取在线客服接待信息
        }

        private void button33_Click(object sender, EventArgs e)
        {
            //新增永久素材
            if (openFileDialog1.FileName == "") { responseBox.Text = "请上传文件"; return; }
            MediaType type = (MediaType)Enum.Parse(typeof(MediaType), comboBox1.SelectedItem.ToString(), true);
            var result = WxHelperMedia.UploadPermanentMedia(accessToken, openFileDialog1.FileName, type);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "type:" + result.type.ToString() + "\n" +
                    "media_id:" + result.media_id + "\n" +
                    "created_at:" + DateTimeHelper.ConvertToDateTime(Convert.ToInt64(result.created_at)).ToLocalTime() + "\n"
                    );
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button34_Click(object sender, EventArgs e)
        {
            //上传图文消息内的图片获取URL
            if (openFileDialog1.FileName == "") { responseBox.Text = "请上传文件"; return; }
            MediaType type = (MediaType)Enum.Parse(typeof(MediaType), comboBox1.SelectedItem.ToString(), true);
            var result = WxHelperMedia.UploadImgGetUrl(accessToken, openFileDialog1.FileName);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "Url:" + result.url+"\n" 
                    );
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button35_Click(object sender, EventArgs e)
        {
            //获取永久素材
        }

        private void button36_Click(object sender, EventArgs e)
        {
            //删除永久素材
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //获取素材总数
            var result = WxHelperMedia.GetMediaCount(accessToken);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText(
                    "image_count:" + result.image_count + "\n" +
                    "news_count:" + result.news_count + "\n" +
                    "video_count:" + result.video_count + "\n" +
                    "voice_count:" + result.voice_count + "\n"
                    );
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button38_Click(object sender, EventArgs e)
        {
            //获取素材总数
            MediaType type = (MediaType)Enum.Parse(typeof(MediaType), comboBox1.SelectedItem.ToString(), true);
            var result = WxHelperMedia.GetMediaList(accessToken, type, 0, 20);
            responseBox.Text = result.ToString();
        }

        private void button39_Click(object sender, EventArgs e)
        {
            //上传图文消息素材
            List<UploadArticle> articles=new List<UploadArticle>();
            UploadArticle article1 = new UploadArticle();
            UploadArticle article2 = new UploadArticle();
            article1.thumb_media_id = "MMg1Xg17qxzAdAPe8UZ7Aiej7_k4LvIXtC2eRmRRN9E";
            article1.title = "图文消息1的标题";
            article1.content_source_url = "";
            article1.content = "图文消息页面的内容，支持HTML标签。具备微信支付权限的公众号，可以使用a标签，其他公众号不能使用";
            article1.digest = "";
            article1.show_cover_pic = "1";
            article1.author = "";

            article2.thumb_media_id = "MMg1Xg17qxzAdAPe8UZ7Aiej7_k4LvIXtC2eRmRRN9E";
            article2.title = "图文消息2的标题";
            article2.content_source_url = "";
            article2.content = "图文消息页面的内容，支持HTML标签。具备微信支付权限的公众号，可以使用a标签，其他公众号不能使用";
            article2.digest = "";
            article2.show_cover_pic = "0";
            article2.author = "";

            articles.Add(article1);
            articles.Add(article2);
            var result=WxHelperMedia.AddNews(accessToken, articles);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("media_id:" + result.media_id);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            //根据分组进行群发
            var group_id = textBox1.Text.Trim();
            if (group_id == "") { responseBox.Text = "请在第1个文本框中输入group_id\n"; return; }
            var mediaid = "MMg1Xg17qxzAdAPe8UZ7AnKjesKaqbiQqBe5GKYoeVI";
            var result=WxHelperMassSend.SendAllByGroup(accessToken,group_id,GroupSendType.mpnews,mediaid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("msg_id:" + result.msg_id);
                responseBox.AppendText("\nmsg_data_id:" + result.msg_data_id);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button41_Click(object sender, EventArgs e)
        {
            //根据OpenID列表群发
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid列表,以“,”间隔"; return; }
            var tagid = textBox2.Text.Trim();
            var openidlist = openid.Split(new char[] { ',' });
            var mediaid = "MMg1Xg17qxzAdAPe8UZ7AnKjesKaqbiQqBe5GKYoeVI";
            var result = WxHelperMassSend.SendAllByOpenId(accessToken, openidlist, GroupSendType.mpnews, mediaid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("msg_id:" + result.msg_id);
                responseBox.AppendText("\nmsg_data_id:" + result.msg_data_id);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button43_Click(object sender, EventArgs e)
        {
            //预览接口
            var openid = textBox1.Text.Trim();
            if (openid == "") { responseBox.Text = "请在第一个文本框中输入openid"; return; }
            var mediaid = "MMg1Xg17qxzAdAPe8UZ7AnKjesKaqbiQqBe5GKYoeVI";
            var result = WxHelperMassSend.MessagePreview(accessToken, GroupSendType.mpnews, mediaid, openid);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("msg_id:" + result.msg_id);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button44_Click(object sender, EventArgs e)
        {
            //查询群发消息发送状态
            var msg_id = textBox1.Text.Trim();
            if (msg_id == "") { responseBox.Text = "请在第一个文本框中输入msg_id"; return; }
            var result = WxHelperMassSend.GetSendStatus(accessToken, msg_id);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n";
                responseBox.AppendText("msg_id:" + result.msg_id);
                responseBox.AppendText("\nmsg_status:" + result.msg_status);
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button42_Click(object sender, EventArgs e)
        {
            //删除群发-!
            var msg_id = textBox1.Text.Trim();
            if (msg_id == "") { responseBox.Text = "请在第一个文本框中输入msg_id"; return; }
            var result = WxHelperMassSend.DeleteGroupSend(accessToken, msg_id);
            if (result.errcode == ReturnCode.请求成功)
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
            else
            {
                responseBox.Text = result.errcode.ToString() + "\n" + result.errmsg.ToString();
            }
        }

        private void button45_Click(object sender, EventArgs e)
        {
            //var result=WxHelperShake.SearchPageByRange(accessToken);
            //responseBox.Text = result.ToString();
        }

        private void button46_Click(object sender, EventArgs e)
        {
            var result = WxHelperScan.GetMerchantInfo(accessToken);
            responseBox.Text = result.ToString();
        }

        
    }
}
