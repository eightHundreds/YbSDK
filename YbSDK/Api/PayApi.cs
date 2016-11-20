using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using YbSDK.Config;
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
        /// <param name="context">易班Api上下文</param>
        public PayApi(ApiContext context) : base(context)
        {
        }

        public PayApi(AccessToken token, YbConfig config) : base(token, config)
        {
        }

        public PayApi(string token, YbConfig config) : base(token, config)
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


        public TradeWangXinResult TradeWangXin(int paycount,string signBack,string userId=null)
        {
            var request = CreateRequest(RestSharp.Method.GET, "pay/trade_wx");
            request.AddParameter("access_token", context.Token.access_token);
            request.AddParameter("pay", paycount);
            request.AddParameter("sign_back", signBack);
            if (!string.IsNullOrWhiteSpace(userId))
            {
                request.AddParameter("yb_userid", userId);
            }
          
            var response = restClient.Execute(request);
            if (CheckError(response))
            {
                throw GenerateError(response);
            }
            var result = Deserialize<TradeWangXinResult>(response.Content);
            return result;
        }
    }
}