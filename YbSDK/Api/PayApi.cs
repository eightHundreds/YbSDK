using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 网薪支付接口
    /// </summary>
    public class PayApi : BaseApi
    {
        #region 构造函数
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public PayApi(AccessToken token) : base(token)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="token">accesstoken</param>
        public PayApi(string token) : base(token)
        {
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班Api上下文</param>
        public PayApi(ApiContext context) : base(context)
        {
        }
        #endregion

        /// <summary>
        /// 指定用户网薪支付。
        /// </summary>
        /// <param name="pay">支付网薪数</param>
        /// <returns></returns>
        public bool PayWangXin(int pay)
        {
            var request = CreateRequest(RestSharp.Method.GET, "pay/yb_wx");
            request.AddParameter("access_token", context.Token.access_token, RestSharp.ParameterType.QueryString);
            request.AddParameter("pay", pay, RestSharp.ParameterType.QueryString);

            var response = restClient.Execute(request);

            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            //如果返回结果包括"info":true则代表执行成功
            return response.Content.ToLower().Contains("\"info\":true");
        }
    }
}