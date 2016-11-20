namespace YbSDK.Model
{
    public enum VerifyKey
    {
        学号 = 1,
        准考证号 = 2,
        录取通知编号 = 3,
        工号 = 4
    }

    public class IsVerifyResult
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public string sure_schoolname { get; set; }
            public string result { get; set; }
        }
    }

    public class CheckVerifyResult
    {
        public string info { get; set; }
        public string status { get; set; }
    }

    public class IsRealResult
    {
        public string info { get; set; }
        public string status { get; set; }
    }

    public class UserMe
    {
        public Info info { get; set; }
        public string status { get; set; }

        public class Info
        {
            public string yb_exp { get; set; }
            public string yb_money { get; set; }
            public string yb_regtime { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_sex { get; set; }
            public string yb_userhead { get; set; }
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
        }
    }

    public class UserOther
    {
        public Info info { get; set; }
        public string status { get; set; }

        public class Info
        {
            public string yb_regtime { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_sex { get; set; }
            public string yb_userhead { get; set; }
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
        }
    }

    public class UserReal
    {
        public Info info { get; set; }
        public string status { get; set; }

        public class Info
        {
            public string yb_exp { get; set; }
            public string yb_identity { get; set; }
            public string yb_money { get; set; }
            public string yb_realname { get; set; }
            public string yb_regtime { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_sex { get; set; }
            public string yb_studentid { get; set; }
            public string yb_userhead { get; set; }
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
        }
    }

    /// <summary>
    /// 校方验证用户
    /// </summary>
    public class UserVerify
    {
        public Info info { get; set; }
        public string status { get; set; }

        public class Info
        {
            public string yb_admissionid { get; set; }
            public string yb_examid { get; set; }
            public string yb_realname { get; set; }
            public string yb_schoolid { get; set; }
            public string yb_schoolname { get; set; }
            public string yb_studentid { get; set; }
            public int yb_userid { get; set; }
        }
    }
}