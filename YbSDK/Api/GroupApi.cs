using RestSharp;
using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 群话题接口
    /// </summary>
    public class GroupApi : BaseApi
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public GroupApi(AccessToken token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public GroupApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public GroupApi(ApiContext context) : base(context)
        {
        }

        #endregion 构造函数

        /// <summary>
        ///   获取当前用户已加入的公共群
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>
        public PublicGroups GetPublicGroups(int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/public_group");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<PublicGroups>(response.Content);
        }

        /// <summary>
        /// 获取当前用户已加入的机构群
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>
        public OrganGroups GetOrganGroups(int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/organ_group");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<OrganGroups>(response.Content);
        }

        /// <summary>
        /// 获取当前用户创建的机构群/公共群
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>

        public MyGroups GetMyGroups(int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/my_group");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<MyGroups>(response.Content);
        }

        /// <summary>
        /// 获取指定机构群/公共群信息
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <returns></returns>
        public GroupInfo GetGroupInfo(int groupId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "group/group_info");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }

            return Deserialize<GroupInfo>(response.Content);
        }

        /// <summary>
        /// 获取指定机构群/公共群成员列表
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>
        public GroupMembers GetGroupMembers(int groupId, int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/group_member");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }

            GroupMembers result = null;
            try
            {
                result = Deserialize<GroupMembers>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new GroupMembers()
                {
                    status = "success",
                    info = new GroupMembers.Info()
                };
                return result;
            }
            return result;
        }

        /// <summary>
        /// 获取指定机构群/公共群话题列表
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <param name="order">排序方式（默认1，1-发表时间倒序；2-最后评论时间倒序；3-回帖数倒序)</param>
        /// <returns></returns>
        public GroupTopic GetGroupTopics(int groupId, int page = 1, int count = 15, int order = 1)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/group_topic");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);
            request.AddParameter("order", order, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            GroupTopic result = null;
            try
            {
                result = Deserialize<GroupTopic>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new GroupTopic()
                {
                    status = "success",
                    info = new GroupTopic.Info()
                };
                return result;
            }
            return result;
        }

        /// <summary>
        ///  获取全站/机构号热门话题列表
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <param name="organUserid">机构号易班ID（默认表示获取全站）</param>
        /// <returns></returns>
        public HotTips GetHotTips(int page = 1, int count = 15, int organUserid = -1)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "group/hot_topic");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);
            if (organUserid != -1)
            {
                request.AddParameter("organ_userid", organUserid, RestSharp.ParameterType.QueryString);
            }
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<HotTips>(response.Content);
        }

        /// <summary>
        ///  获取指定话题内容
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="topicId">话题ID</param>
        /// <returns></returns>
        public TopicInfo GetTopicInfo(int groupId, int topicId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "group/topic_info");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_id", topicId, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<TopicInfo>(response.Content);
        }

        /// <summary>
        /// 获取指定话题评论内容
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="topicId">话题ID</param>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>
        public TopicComment GetTopicComment(int groupId, int topicId, int page = 1, int count = 15)
        {
            var request = CreateRequest(RestSharp.Method.GET, "group/topic_comment");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_id", topicId, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            TopicComment result = null;

            try
            {
                result = Deserialize<TopicComment>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new TopicComment()
                {
                    status = "success",
                    info = new TopicComment.Info()
                };
                return result;
            }
            return result;
        }

        /// <summary>
        /// 在指定机构群/公共群范围发表话题
        /// </summary>
        /// <param name="groupId">	群ID</param>
        /// <param name="topicTitle">话题标签（最多50字数）</param>
        /// <param name="topicContent">	话题内容（最多10000字数，不包含html样式）</param>
        /// <returns></returns>
        public bool SendTopic(int groupId, string topicTitle, string topicContent)
        {
            if (topicTitle.Length > 50)
            {
                throw new YbException("话题标签最多50字数");
            }
            if (topicContent.Length > 10000)
            {
                throw new YbException("话题内容最多10000字数");
            }
            var request = CreateRequest(RestSharp.Method.POST, "group/send_topic");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_title", topicTitle, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_content", topicContent, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }

            return CheckPostSuccess(response);
        }

        /// <summary>
        /// 对指定话题发表/回复评论
        /// </summary>
        /// <param name="groupId">	群ID</param>
        /// <param name="topId">话题ID</param>
        /// <param name="commentContent">评论内容（最多140字数）</param>
        /// <param name="comment_id">上级评论ID</param>
        /// <returns></returns>
        public bool SendComment(int groupId, int topId, string commentContent, int comment_id = -1)
        {
            if (commentContent.Length > 140)
            {
                throw new YbException("评论内容最多140字数");
            }
            var request = CreateRequest(RestSharp.Method.POST, "group/send_comment");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_id", topId, RestSharp.ParameterType.QueryString);
            request.AddParameter("comment_content", commentContent, RestSharp.ParameterType.QueryString);
            if (comment_id != -1)
            {
                request.AddParameter("comment_id", comment_id, RestSharp.ParameterType.QueryString);
            }
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }

            return CheckPostSuccess(response);
        }

        /// <summary>
        ///  删除当前用户发表的话题
        /// </summary>
        /// <param name="groupId">群ID</param>
        /// <param name="topId">话题ID</param>
        /// <returns></returns>
        public bool DeleteTopic(int groupId, int topId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "group/delete_topic");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_id", topId, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return CheckPostSuccess(response);
        }

        /// <summary>
        /// 删除当前用户发表的话题评论
        /// </summary>
        /// <param name="groupId">	群ID</param>
        /// <param name="topId">话题ID</param>
        /// <param name="commentId">评论ID</param>
        /// <returns></returns>
        public bool DeleteComment(int groupId, int topId, int commentId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "group/delete_comment");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);
            request.AddParameter("topic_id", topId, RestSharp.ParameterType.QueryString);
            request.AddParameter("comment_id", commentId, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return CheckPostSuccess(response);
        }

        /// <summary>
        /// 检测发送是否成功
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private bool CheckPostSuccess(IRestResponse response)
        {
            return response.Content.ToLower().Contains("\"status\":true");
        }
    }
}