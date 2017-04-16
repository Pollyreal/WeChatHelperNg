using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace DuoKong.Polly.WeiXin
{
    public static class JsonHelper
    {
        public static string getJsonString(dynamic myData)
        {
            StringBuilder myJson = new StringBuilder();
            var serializer = new JavaScriptSerializer();
            serializer.Serialize(myData, myJson);
            return myJson.ToString();
        }
    }
}
