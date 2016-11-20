using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{

    public class TradeWangXinResult
    {
        public string status { get; set; }
        public Info info { get; set; }
        public class Info
        {
            public string trade_id { get; set; }
            public string sign_href { get; set; }
        }
    }



}
