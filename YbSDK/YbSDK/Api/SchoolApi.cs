using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 校级接口
    /// </summary>
    public class SchoolApi : BaseApi
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public SchoolApi(AccessToken token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public SchoolApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public SchoolApi(ApiContext context) : base(context)
        {
        }

        #endregion 构造函数

        /// <summary>
        /// 获取当日用户活跃统计
        /// </summary>
        /// <returns></returns>
        public UserActive GetUserActive()
        {
            var request = CreateRequest(RestSharp.Method.GET, "school/user_active");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<UserActive>(response.Content);
        }

        /// <summary>
        /// 获取行政公共群EGPA统计
        /// </summary>
        /// <param name="groupId">行政公共群ID</param>
        /// <returns></returns>
        public Egpa GetEgpa(int groupId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "school/egpa");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("group_id", groupId, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return Deserialize<Egpa>(response.Content);
        }

        /// <summary>
        /// 获取当前应用所属开发者/可见学校其它的关联应用
        /// </summary>
        /// <param name="scName"></param>
        /// <param name="page">页码（默认1）</param>
        /// <param name="count">每页数据量(默认15，最大30)</param>
        /// <returns></returns>
        public RelateApp GetRelateApp(string scName = "", int page = 1, int count = 15)
        {
            if (count > 30)
            {
                throw new YbException("每页数据量最大30");
            }

            var request = CreateRequest(RestSharp.Method.GET, "school/relate_app");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("page", page, RestSharp.ParameterType.QueryString);
            request.AddParameter("count", count, RestSharp.ParameterType.QueryString);
            if (string.IsNullOrWhiteSpace(scName))
            {
                request.AddParameter("sc_name", scName, RestSharp.ParameterType.QueryString);
            }

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            RelateApp result = null;
            try
            {
                result = Deserialize<RelateApp>(response.Content);
            }
            catch (System.InvalidOperationException)
            {
                result = new RelateApp()
                {
                    status = "success",
                    info = new RelateApp.Info()
                };
                return result;
            }
            return result;
        }

        /// <summary>
        ///   学校活动账户向指定用户发放活动网薪
        /// </summary>
        /// <param name="uId"></param>
        /// <param name="award"></param>
        /// <returns></returns>
        public bool SendWangXin(int uId, int award)
        {
            var request = CreateRequest(RestSharp.Method.GET, "school/relate_app");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("yb_userid", uId, RestSharp.ParameterType.QueryString);
            request.AddParameter("award", award, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return response.Content.ToLower().Contains("\"info\":true");
        }
    }
}