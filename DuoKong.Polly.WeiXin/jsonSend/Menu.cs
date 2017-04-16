using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuoKong.Polly.WeiXin
{
    public class Menu
    {
        public string type { get; set; }
        public string name { get; set; }
        public string key { get; set; }
        public string url { get; set; }
        public string media_id { get; set; }
        public List<Menu> sub_button { get; set; }
        public Menu()
        {
            sub_button = new List<Menu>();
        }
    }
}
