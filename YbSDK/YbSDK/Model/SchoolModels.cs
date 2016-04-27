using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Model
{

    public class UserActive
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public string topic_send { get; set; }
            public string vote_send { get; set; }
        }

    }

    public class Egpa
    {
        public string status { get; set; }
        public Info info { get; set; }
        public class Info
        {
            public string all_egpa { get; set; }
            public string up_egpa { get; set; }
            public string egpa_rank { get; set; }
        }
    }


    public class RelateApp
    {
        public string status { get; set; }
        public Info info { get; set; }
        public class Info
        {
            public List[] list { get; set; }
            public string next_page { get; set; }
        }

        public class List
        {
            public string app_name { get; set; }
            public string app_intro { get; set; }
            public string app_small_logo { get; set; }
            public string app_big_logo { get; set; }
            public string app_visit_url { get; set; }
        }


    }



}
