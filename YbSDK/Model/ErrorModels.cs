using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{
    /// <summary>
    /// 错误信息,通常作为ErrorInfo成员,仅在获取access_token时候单独使用
    /// </summary>
    public class Error
    {
        public string code { get; set; }
        public string msgCN { get; set; }
        public string msgEN { get; set; }
    }

    /// <summary>
    /// 错误信息
    /// </summary>
    public class ErrorInfo
    {
        public string status { get; set; }
        public Error info { get; set; }
    }


}
