using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{

    public class RecommendFriends
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public List[] list { get; set; }
        }

        public class List
        {
            public string yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
            public string yb_sex { get; set; }
            public string yb_userhead { get; set; }
        }

    }





    public class MyFriends
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public List[] list { get; set; }
            public string num { get; set; }
        }
        public class List
        {
            public int yb_userid { get; set; }
            public string yb_username { get; set; }
            public string yb_usernick { get; set; }
            public string yb_sex { get; set; }
            public string yb_userhead { get; set; }
            public string yb_useractive { get; set; }
        }
    }





}
