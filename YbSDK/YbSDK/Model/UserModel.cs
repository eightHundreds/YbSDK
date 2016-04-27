namespace YbSDK.Model
{
    /// <summary>
    /// 校方验证用户
    /// </summary>
    public class UserVerify
    {
        public string status { get; set; }

        public Info info { get; set; }

        public class Info
        {
            public int yb_userid { get; set; }
            public string yb_realname { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_studentid { get; set; }
            public string yb_examid { get; set; }
            public string yb_admissionid { get; set; }
        }
    }

    public class UserReal
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
            public string yb_sex { get; set; }
            public string yb_money { get; set; }
            public string yb_exp { get; set; }
            public string yb_userhead { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_regtime { get; set; }
            public string yb_realname { get; set; }
            public string yb_studentid { get; set; }
            public string yb_identity { get; set; }
        }
    }

    public class UserOther
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
            public string yb_sex { get; set; }
            public string yb_userhead { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_regtime { get; set; }
        }
    }

    public class UserMe
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
            public string yb_sex { get; set; }
            public string yb_money { get; set; }
            public string yb_exp { get; set; }
            public string yb_userhead { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_regtime { get; set; }
        }
    }
}