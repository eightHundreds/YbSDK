using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 分享接口
    /// </summary>
    public class ShareApi : BaseApi
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token"></param>
        public ShareApi(AccessToken token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token"></param>
        public ShareApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public ShareApi(ApiContext context) : base(context)
        {
        }

        #endregion 构造函数

        /// <summary>
        ///  获取指定用户动态列表。
        /// </summary>
        /// <param name="userId">查询的易班用户id</param>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量(默认15，最大30)</param>
        /// <returns></returns>
        public OtherList GetOtherShare(int userId, int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "share/other_list");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("yb_userid", userId, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<OtherList>(response.Content);
        }

        /// <summary>
        /// 获取指定动态内容。
        /// </summary>
        /// <param name="feedsId">查询的动态id</param>
        /// <returns></returns>
        public ShareDetail GetShareInfo(string feedsId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "share/info_share");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("feeds_id", feedsId, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<ShareDetail>(response.Content);
        }

        /// <summary>
        ///  获取当前用户动态列表。
        /// </summary>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量（默认15，最大30）</param>
        /// <returns></returns>
        public MyList GetMyShare(int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("	每页数据量不可超过30");
            }
            var request = CreateRequest(RestSharp.Method.GET, "share/me_list");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<MyList>(response.Content);
        }

        /// <summary>
        ///  对指定分享动态发表评论/回复指定评论。
        /// </summary>
        /// <param name="feedId">回复的动态id</param>
        /// <param name="content">	发送的评论内容（最多500字数）</param>
        /// <returns></returns>
        public bool PostComment(string feedId, string content)
        {
            if (content.Length > 500)
            {
                throw new YbException("	评论不可超过500字");
            }
            var request = CreateRequest(RestSharp.Method.POST, "share/send_comment");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("feeds_id", feedId, RestSharp.ParameterType.QueryString);
            request.AddParameter("content", content, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 对指定分享动态点赞/同情。
        /// </summary>
        /// <param name="feedId">指定的动态id</param>
        /// <param name="isPraise">操作类型（true-点赞；false-同情）</param>
        /// <returns></returns>
        public bool Praise(string feedId, bool isPraise = true)
        {
            var request = CreateRequest(RestSharp.Method.GET, "share/praise");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("feeds_id", feedId, RestSharp.ParameterType.QueryString);
            request.AddParameter("action", isPraise ? "1" : "2", RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}