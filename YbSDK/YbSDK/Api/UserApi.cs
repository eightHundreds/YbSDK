using RestSharp;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 用户接口
    /// </summary>
    public class UserApi : BaseApi
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public UserApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public UserApi(AccessToken token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public UserApi(ApiContext context) : base(context)
        {
        }

        #endregion 构造函数

        /// <summary>
        /// 获取当前用户基本信息
        /// </summary>
        /// <returns></returns>
        public UserMe GetMe()
        {
            var request = CreateRequest(RestSharp.Method.GET, "user/me");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            var result = Deserialize<UserMe>(response.Content);

            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return result;
        }

        /// <summary>
        /// 获取指定用户基本信息
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <returns></returns>
        public UserOther GetOther(int userId)
        {
            //user/other
            var request = CreateRequest(RestSharp.Method.GET, "user/other");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);
            request.AddParameter("yb_userid", userId, ParameterType.QueryString);
            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            var result = Deserialize<UserOther>(response.Content);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return result;
        }

        /// <summary>
        /// 获取当前用户实名信息
        /// </summary>
        /// <returns></returns>
        public UserReal GetReal()
        {
            var request = CreateRequest(Method.GET, "user/real_me");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            var result = Deserialize<UserReal>(response.Content);

            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return result;
        }

        /// <summary>
        /// 获取当前用户校方认证信息。
        /// </summary>
        /// <returns></returns>
        public UserVerify GetVerify()
        {
            var request = CreateRequest(RestSharp.Method.GET, "user/verify_me");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            var result = Deserialize<UserVerify>(response.Content);

            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            return result;
        }
    }
}