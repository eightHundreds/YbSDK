using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{
    public class AccessToken
    {
        /// <summary>
        /// 授权凭证
        /// </summary>
        public string access_token { get; set; }
        /// <summary>
        /// 授权用户id
        /// </summary>
        public int userid { get; set; }
        /// <summary>
        /// 截止有效期
        /// </summary>
        public int expires { get; set; }


    }

    public class TokenInfo
    {
        public string status { get; set; }
        public int userid { get; set; }
        public string access_token { get; set; }
        public string create_at { get; set; }
        public string expire_in { get; set; }
    }


    /// <summary>
    /// 站内应用，轻应用授权检测结果
    /// </summary>
    public class VisitOauth
    {
        /// <summary>
        /// 是否已授权
        /// </summary>
        public bool IsAuthorized { get; set; }
        public string visit_time { get; set; }
        public Visit_User visit_user { get; set; }
        public Visit_Oauth visit_oauth { get; set; }
        public class Visit_User
        {
            public string userid { get; set; }
            public string username { get; set; }
            public string usernick { get; set; }
            public string usersex { get; set; }
        }
        public class Visit_Oauth
        {
            public string access_token { get; set; }
            public string token_expires { get; set; }
        }

    }


}
