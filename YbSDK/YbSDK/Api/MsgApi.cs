using RestSharp;
using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 消息接口
    /// </summary>
    public class MsgApi : BaseApi
    {
        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public MsgApi(AccessToken token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public MsgApi(string token) : base(token)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public MsgApi(ApiContext context) : base(context)
        {
        }

        #endregion 构造函数

        /// <summary>
        ///  向指定用户发送易班站内信应用提醒。
        /// </summary>
        /// <param name="to_yb_uid">目标用户Id</param>
        /// <param name="content">发送内容不超过300字</param>
        /// <returns></returns>
        public bool SendMsg(int to_yb_uid, string content)
        {
            if (content.Length > 300)
            {
                throw new YbException("信息内容过长");
            }
            RestRequest request = CreateRequest(Method.POST, "msg/letter");
            request.AddParameter("access_token", context.Token.access_token, ParameterType.QueryString);
            request.AddParameter("to_yb_uid", to_yb_uid, ParameterType.QueryString);
            request.AddParameter("content", content, ParameterType.QueryString);

            var response = restClient.Execute(request);

            return !CheckError(response);
        }
    }
}