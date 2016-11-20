using RestSharp;
using System.Net;
using YbSDK.Config;
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
        /// <param name="context">易班Api上下文</param>
        public UserApi(ApiContext context) : base(context)
        {
        }

        public UserApi(AccessToken token, YbConfig config) : base(token, config)
        {
        }

        public UserApi(string token, YbConfig config) : base(token, config)
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
            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<UserMe>(response.Content);

           
            return result;
        }

        /// <summary>
        /// 获取指定用户基本信息 other
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
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<UserOther>(response.Content);

           
            return result;
        }

        /// <summary>
        /// 获取当前用户实名信息 real_me	
        /// </summary>
        /// <returns></returns>
        public UserReal GetReal()
        {
            var request = CreateRequest(Method.GET, "user/real_me");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<UserReal>(response.Content);

           
            return result;
        }

        /// <summary>
        /// 获取当前用户校方认证信息。  verify_me
        /// </summary>
        /// <returns></returns>
        public UserVerify GetVerify()
        {
            var request = CreateRequest(RestSharp.Method.GET, "user/verify_me");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            //"status":"error"
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<UserVerify>(response.Content);

            
            return result;
        }

        /// <summary>
        /// 当前用户完成校方认证  check_verify
        /// </summary>
        /// <param name="schoolName">学校全名</param>
        /// <param name="realName">真名</param>
        /// <param name="verifyKey">认证类型</param>
        /// <param name="verifyValue">认证内容</param>
        /// <returns></returns>
        public bool CheckVerify(string schoolName,string realName, VerifyKey verifyKey, string verifyValue)
        {
            string postVerifyKey = "";
#if DEBUG
            restClient.Proxy = new WebProxy("http://127.0.0.1:8888");
#endif
            switch (verifyKey)
            {
                case VerifyKey.学号:
                    postVerifyKey = "student_id";
                    break;
                case VerifyKey.准考证号:
                    postVerifyKey = "exam_id";
                    break;
                case VerifyKey.录取通知编号:
                    postVerifyKey = "admission_id";
                    break;
                case VerifyKey.工号:
                    postVerifyKey = "employ_id";
                    break;
                default:
                    break;
            }
            var request = CreateRequest(RestSharp.Method.POST, "user/check_verify");
            request.AddParameter("access_token", context.Token.access_token);
            request.AddParameter("school_name", schoolName);
            request.AddParameter("real_name", realName);
            request.AddParameter("verify_key", postVerifyKey);
            request.AddParameter("verify_value", verifyValue);
            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<CheckVerifyResult>(response.Content);
            
            return bool.Parse(result.info);
        }

        /// <summary>
        /// 指定用户是否实名认证。 is_real
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public bool IsReal(int userId)
        {
            var request = CreateRequest(RestSharp.Method.GET, "user/is_real");
            request.AddParameter("access_token", context.Token.access_token);
            request.AddParameter("yb_userid", userId);
            IRestResponse response = null;
            response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<CheckVerifyResult>(response.Content);
            return bool.Parse(result.info);
        }

        /// <summary>
        ///  当前用户是否校方认证。 is_verify
        /// </summary>
        /// <param name="schoolName"></param>
        /// <param name="verifyKey"></param>
        /// <param name="verifyValue"></param>
        /// <returns></returns>
        public IsVerifyResult IsVerify(string schoolName, VerifyKey verifyKey, string verifyValue)
        {
            string postVerifyKey = "";
#if DEBUG
            restClient.Proxy = new WebProxy("http://127.0.0.1:8888");
#endif
            switch (verifyKey)
            {
                case VerifyKey.学号:
                    postVerifyKey = "student_id";
                    break;
                case VerifyKey.准考证号:
                    postVerifyKey = "exam_id";
                    break;
                case VerifyKey.录取通知编号:
                    postVerifyKey = "admission_id";
                    break;
                case VerifyKey.工号:
                    postVerifyKey = "employ_id";
                    break;
                default:
                    break;
            }
            var request = CreateRequest(RestSharp.Method.GET, "user/is_verify");
            request.AddParameter("access_token", context.Token.access_token);
            request.AddParameter("school_name", schoolName);
            request.AddParameter("verify_key", postVerifyKey);
            request.AddParameter("verify_value", verifyValue);
            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<IsVerifyResult>(response.Content);

            return result;

        }

    }
}