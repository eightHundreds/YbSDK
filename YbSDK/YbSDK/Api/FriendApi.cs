using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 好友分组接口
    /// </summary>
    public class FriendApi : BaseApi
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public FriendApi(AccessToken token) : base(token)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public FriendApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public FriendApi(ApiContext context) : base(context)
        {
        }
        #endregion

        /// <summary>
        /// 获取当前用户好友列表。
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量(默认15，最大30)</param>
        /// <returns></returns>
        public MyFriends GetMyFriends(int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("每页数据量最大30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "friend/me_list");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }

            MyFriends result = null;
            try
            {
                result = Deserialize<MyFriends>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new MyFriends()
                {
                    status = "success",
                    info = new MyFriends.Info()
                };
                return result;
            }
            return result;
        }

        /// <summary>
        /// 当前用户与指定用户是否为好友关系。
        /// </summary>
        /// <returns></returns>
        public bool CheckFriend(int uId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "friend/check");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("yb_friend_uid", uId, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return response.Content.ToLower().Contains("\"info\":true");
        }

        /// <summary>
        /// 获取推荐好友列表。
        /// </summary>
        /// <param name="count">获取数据量（默认20，最大20）</param>
        /// <returns></returns>
        public RecommendFriends GetRecommendFriends(int count = 20)
        {
            if (count > 20)
            {
                throw new YbException("最大显示推荐好友数为20");
            }

            var request = CreateRequest(RestSharp.Method.GET, "friend/recommend");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            RecommendFriends result = null;
            try
            {
                result = Deserialize<RecommendFriends>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new RecommendFriends()
                {
                    status = "success",
                    info = new RecommendFriends.Info()
                };
                return result;
            }
            return result;
        }


        /// <summary>
        /// 发送好友申请。
        /// </summary>
        /// <param name="uId">	接收方易班用户ID</param>
        /// <param name="content">申请理由（最多50字数）</param>
        /// <returns></returns>
        public bool ApplyFriend(int uId, string content = null)
        {
            if (content != null && content.Length > 50)
            {
                throw new YbException("申请理由最多50字数");
            }
            var request = CreateRequest(RestSharp.Method.POST, "friend/apply");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("to_yb_uid", uId, RestSharp.ParameterType.QueryString);
            request.AddParameter("content", content, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return response.Content.ToLower().Contains("\"info\":true");
        }

        /// <summary>
        /// 删除指定好友
        /// </summary>
        /// <param name="friendUId">好友Id</param>
        /// <returns></returns>
        public bool RemoveFriend(int friendUId)
        {
            var request = CreateRequest(RestSharp.Method.POST, "friend/apply");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("yb_friend_uid", friendUId, RestSharp.ParameterType.QueryString);
            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return response.Content.ToLower().Contains("\"info\":true");
        }
    }
}
