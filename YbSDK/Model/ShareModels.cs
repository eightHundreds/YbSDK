using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{
    #region 主要用到的类

    public class MyList
    {
        public string status { get; set; }
        public ShareInfo info { get; set; }
    }

    public class OtherList
    {
        public string status { get; set; }
        public ShareInfo info { get; set; }
    }

    public class ShareDetail
    {
        public string status { get; set; }
        public class ShareInfo : ShareList
        {
            public List<ReplyList> yb_replylist;
        }
        public class ReplyList
        {
            public string reply_commid { get; set; }
            public int reply_userid { get; set; }
            public string reply_username { get; set; }
            public string reply_usernick { get; set; }
            public string reply_userhead { get; set; }
            public string reply_content { get; set; }
            public string reply_sendtime { get; set; }
        }
    }
    #endregion


    public class ShareInfo
    {
        public ShareList[] list { get; set; }
        public string page { get; set; }
    }

    public class ShareList
    {
        public string yb_feedid { get; set; }
        public string yb_content { get; set; }
        public int yb_userid { get; set; }
        public string yb_username { get; set; }
        public string yb_usernick { get; set; }
        public string yb_userhead { get; set; }
        public string yb_sendtime { get; set; }
        public string yb_goodnum { get; set; }
        public string yb_pitynum { get; set; }
        public string yb_replynum { get; set; }
        public Yb_Share[] yb_share { get; set; }
    }

    public class Yb_Share
    {
        public string share_title { get; set; }
        public string share_content { get; set; }
        public string share_href { get; set; }
        public string share_image { get; set; }
        public string share_source { get; set; }
    }

}
