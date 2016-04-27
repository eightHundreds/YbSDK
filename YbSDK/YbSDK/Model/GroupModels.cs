namespace YbSDK.Model
{
    public class PublicGroups
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public Group[] public_group { get; set; }
            public string num { get; set; }
        }
    }

    public class OrganGroups
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public Group[] organ_group { get; set; }
            public string num { get; set; }
        }

        public OrganGroups()
        {
        }
    }

    public class MyGroups
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public Group[] group { get; set; }
            public string num { get; set; }
        }
    }

    public class GroupInfo
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public string group_id { get; set; }
            public string group_name { get; set; }
            public string group_icon { get; set; }
            public string group_type { get; set; }
            public string adm_uid { get; set; }
            public string adm_nick { get; set; }
            public string group_mamber { get; set; }
            public Group_Notice[] group_notice { get; set; }
        }

        public class Group_Notice
        {
            public string topic_id { get; set; }
            public string topic_title { get; set; }
            public string topic_content { get; set; }
            public string create_time { get; set; }
        }
    }

    public class GroupMembers
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public List[] list { get; set; }
        }

        public class List
        {
            public string member_uid { get; set; }
            public string member_nick { get; set; }
            public string member_head { get; set; }
            public string member_remark { get; set; }
        }
    }

    public class GroupTopic
    {
        public string status { get; set; }
        public Info info { get; set; }

        public class Info
        {
            public List[] list { get; set; }
        }

        public class List
        {
            public string topic_id { get; set; }
            public string topic_title { get; set; }
            public string pub_uid { get; set; }
            public string pub_nick { get; set; }
            public string pub_head { get; set; }
            public string reply_count { get; set; }
            public string topic_content { get; set; }
            public string create_time { get; set; }
            public string reply_time { get; set; }
        }
    }

    public class HotTips
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
            public string topic_id { get; set; }
            public string topic_title { get; set; }
            public string pub_uid { get; set; }
            public string pub_nick { get; set; }
            public string pub_head { get; set; }
            public string reply_count { get; set; }
            public string topic_content { get; set; }
            public string create_time { get; set; }
            public string reply_time { get; set; }
        }
    }

    public class TopicInfo
    {
        public string status { get; set; }
        public Info info { get; set; }
        public class Info
        {
            public string topic_id { get; set; }
            public string topic_title { get; set; }
            public string pub_uid { get; set; }
            public string pub_nick { get; set; }
            public string pub_head { get; set; }
            public string reply_count { get; set; }
            public string topic_content { get; set; }
            public string create_time { get; set; }
            public string reply_time { get; set; }
        }
    }


    public class TopicComment
    {
        public string status { get; set; }
        public Info info { get; set; }
        public class Info
        {
            public List[] list { get; set; }
        }
        public class List
        {
            public string topic_id { get; set; }
            public int comment_id { get; set; }
            public string pub_uid { get; set; }
            public string pub_nick { get; set; }
            public string pub_head { get; set; }
            public string comment_content { get; set; }
            public Reply_List[] reply_list { get; set; }
            public string create_time { get; set; }
        }


        public class Reply_List
        {
            public string topic_id { get; set; }
            public string reply_id { get; set; }
            public string comment_id { get; set; }
            public string pub_uid { get; set; }
            public string pub_nick { get; set; }
            public string pub_head { get; set; }
            public string comment_content { get; set; }
            public string create_time { get; set; }
        }

    }






    #region 不能直接用的
    public class Group
    {
        public Group()
        {
        }

        public string group_id { get; set; }
        public string group_name { get; set; }
        public string group_icon { get; set; }
        public string group_type { get; set; }
        public string adm_uid { get; set; }
        public string adm_nick { get; set; }
        public string group_mamber { get; set; }
    }

    #endregion 不能直接用的
}