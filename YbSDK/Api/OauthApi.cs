using RestSharp;
using System;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using YbSDK.Config;
using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// 授权接口
    /// </summary>
    public class OauthApi : BaseApi
    {
        private byte[] bKey;


        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="context">易班上下文</param>
        public OauthApi(ApiContext context) : base(context)
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="config">配置</param>
        public OauthApi(YbConfig config) : base("", config)
        {
        }
        #endregion 构造函数

        /// <summary>
        /// 获得Access_Token
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public AccessToken GetAccessToken(string code)
        {
            RestRequest request = CreateRequest(Method.POST, "oauth/access_token");
            //添加参数
            request.AddParameter("client_id", context.Config.AppId);
            request.AddParameter("client_secret", context.Config.AppSecret);
            request.AddParameter("code", code);
            request.AddParameter("redirect_uri", context.Config.Callback);

            //获得response
            IRestResponse response = null;
#if DEBUG
            restClient.Proxy = new WebProxy("http://127.0.0.1:8888");
#endif
            response = restClient.Execute(request);
            var result = Deserialize<AccessToken>(response.Content);

            //如果没有access_token就代表返回了错误
            if (result.access_token == null)
            {
                throw GenerateOAuthError(response);
            }
            return result;
        }

        /// <summary>
        /// 获得授权页面Url
        /// </summary>
        /// <param name="state">防止跨站攻击的state,需调用者自行校验</param>
        public string GetAuthorizeUrl(string state = "")
        {
            //字符串模板
            string formater = "{0}?client_id={1}&redirect_uri={2}&display={3}";
            string url = null;
            //拼接字符串
            if (!string.IsNullOrWhiteSpace(state))
            {
                formater += "&state={4}";
                url = String.Format(formater,
               context.Config.OauthUrl, context.Config.AppId, context.Config.Callback, context.Config.Type, state);
            }
            else
            {
                url = String.Format(formater,
             context.Config.OauthUrl, context.Config.AppId, context.Config.Callback, context.Config.Type);
            }
            return url;
        }

        /// <summary>
        /// 授权查询
        /// </summary>
        /// <param name="accessToken">	选填	查询的授权凭证</param>
        /// <param name="ybUid">	选填	查询的易班用户id</param>
        /// <returns></returns>
        public TokenInfo GetTokenInfo(string accessToken = "", string ybUid = "")
        {
            RestRequest request = CreateRequest(Method.POST, "oauth/token_info");
            request.AddParameter("client_id", context.Config.AppId);
            //添加参数
            if (!String.IsNullOrWhiteSpace(accessToken))
            {
                request.AddParameter("access_token", accessToken);
            }
            if (!String.IsNullOrWhiteSpace(ybUid))
            {
                request.AddParameter("yb_uid", ybUid);
            }
            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            var result = Deserialize<TokenInfo>(response.Content);

            //如果没有access_token就代表返回了错误
            if (result.access_token == null)
            {
                throw base.GenerateError(response);
            }
            return result;
        }

        /// <summary>
        ///  帮助开发者主动取消用户的授权。
        /// </summary>
        /// <param name="token">待注销的授权凭证</param>
        /// <returns></returns>
        public bool RevokeToken(string token)
        {
            RestRequest request = CreateRequest(Method.POST, "oauth/revoke_token");
            request.AddParameter("client_id", context.Config.AppId);
            request.AddParameter("access_token", token);

            //获得response
            IRestResponse response = null;
            response = restClient.Execute(request);
            //如果存在错误码500则返回false
            return !response.Content.Contains("\"500\"");
        }

        /// <summary>
        /// 检测来访用户是否已授权(该方法仅用于站内应用或轻应用)
        /// </summary>
        /// <param name="verifyRequest">从请求中获得的verify_request,是易班发送给当前应用的授权信息(该信息使用AES加密)</param>
        /// <returns></returns>
        public VisitOauth CheckAuthor(string verifyRequest)
        {
            VisitOauth result = null;
            string decryptStr = Decrypt(verifyRequest, context.Config.AppSecret, context.Config.AppId);
            if (decryptStr.Contains("\"visit_oauth\":false"))
            {
                // result = new VisitOauth() { IsAuthorized = false };
                result = new VisitOauth();
            }
            else
            {
                //我操,解密生成的数据后竟然跟一堆的\0导致反序列失败,找了n个小时才发现
                decryptStr = decryptStr.Substring(0, decryptStr.LastIndexOf('}') + 1);
                result = Deserialize<VisitOauth>(decryptStr);
                result.IsAuthorized = true;
            }
            return result;
        }

        private static byte[] strToToHexByte(string hexString)
        {
            hexString = hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString += " ";
            byte[] returnBytes = new byte[hexString.Length / 2];
            for (int i = 0; i < returnBytes.Length; i++)
                returnBytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }
        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="encryptStr">密文字符串</param>
        /// <returns>明文</returns>
        private string Decrypt(string encryptStr, string Key, string IV)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = strToToHexByte(encryptStr);
            Rijndael aes = Rijndael.Create();
            aes.Key = bKey;
            aes.IV = bIV;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.None;
            aes.KeySize = bIV.Length == 16 ? 128 : 256;//16字符长度appID应用采用AES-128-CBC对称加密算法；原32字符长度appID应用依旧采用AES-256-CBC对称加密算法。
            aes.BlockSize = bIV.Length == 16 ? 128 : 256;
            var decrypt = "";
            using (MemoryStream mStream = new MemoryStream())
            {
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                {
                    cStream.Write(byteArray, 0, byteArray.Length);
                    cStream.FlushFinalBlock();
                    decrypt = Encoding.UTF8.GetString(mStream.ToArray());
                }
            }
            aes.Clear();
            return decrypt;
        }

        /// <summary>
        /// 生成授权时的响应异常
        /// </summary>
        /// <param name="response">请求响应类</param>
        private YbException GenerateOAuthError(IRestResponse response)
        {
            ErrorInfo errorInfo = new ErrorInfo();
            errorInfo.info = Deserialize<Error>(response.Content);
            return new YbException(errorInfo, string.Format("MsgFromYiBan:{0},ErrorCode:{1}", errorInfo.info.msgCN, errorInfo.info.code));
        }
    }
}