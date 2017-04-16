using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace WxHelperByPollyNg
{
    [Serializable]
    public class UserConfig
    {
        public string accessToken { get; set; }
        //基本设置
        public static string configPath { get{return ConfigurationManager.AppSettings["ConfigFilePath"].ToString();}  }
        public UserConfig()
        {

        }
    }
}
