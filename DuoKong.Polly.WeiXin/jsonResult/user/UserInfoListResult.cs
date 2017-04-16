using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class UserInfoListResult:WxJsonResult
    {
        public List<UserInfoResult> user_info_list { get; set; }
        public UserInfoListResult()
        {

        }
    }
}
