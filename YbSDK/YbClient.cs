using YbSDK.Api;
using YbSDK.Config;
using YbSDK.Model;

namespace YbSDK
{
    public class YbClient
    {
        //private static OauthApi Oauther = new OauthApi();

        #region Apis
        public ShareApi share { get; set; }
        public FriendApi friend { get; set; }
        public GroupApi group { get; set; }
        public MsgApi msg { get; set; }
        public PayApi pay { get; set; }
        public SchoolApi school { get; set; }
        public UserApi user { get; set; }

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化
        /// </summary>
        public YbClient(AccessToken token,YbConfig config)
        {
            share = new ShareApi(token, config);
            friend = new FriendApi(token, config);
            group = new GroupApi(token, config);
            msg = new MsgApi(token, config);
            pay = new PayApi(token, config);
            school = new SchoolApi(token, config);
            user = new UserApi(token, config);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public YbClient(string token,YbConfig config)
        {
            share = new ShareApi(token, config);
            friend = new FriendApi(token, config);
            group = new GroupApi(token, config);
            msg = new MsgApi(token, config);
            pay = new PayApi(token, config);
            school = new SchoolApi(token, config);
            user = new UserApi(token, config);
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public YbClient(ApiContext context)
        {
            this.share = new ShareApi(context);
            this.friend = new FriendApi(context);
            this.group = new GroupApi(context);
            this.msg = new MsgApi(context);
            this.pay = new PayApi(context);
            this.school = new SchoolApi(context);
            this.user = new UserApi(context);
        }
        #endregion 构造函数

        #region 授权静态方法

        ///// <summary>
        ///// 获得Access_Token
        ///// </summary>
        ///// <param name="code"></param>
        ///// <returns></returns>
        //public static AccessToken GetAccessToken(string code)
        //{
        //    return Oauther.GetAccessToken(code);
        //}

        ///// <summary>
        ///// 获得授权地址
        ///// </summary>
        ///// <param name="state"></param>
        ///// <returns></returns>
        //public static string GetAuthorizeUrl(string state = "")
        //{
        //    return Oauther.GetAuthorizeUrl(state);
        //}

        ///// <summary>
        ///// 授权查询
        ///// </summary>
        ///// <param name="accessToken">	选填	查询的授权凭证</param>
        ///// <param name="ybUid">	选填	查询的易班用户id</param>
        ///// <returns></returns>
        //public static TokenInfo GetTokenInfo(string accessToken = "", string ybUid = "")
        //{
        //    return Oauther.GetTokenInfo();
        //}

        ///// <summary>
        ///// 注销accessToken
        ///// </summary>
        ///// <param name="accessToken"></param>
        ///// <returns></returns>
        //public static bool RevokeToken(string accessToken)
        //{
        //    return Oauther.RevokeToken(accessToken);
        //}

        ///// <summary>
        ///// 检测来访用户是否已授权(该方法仅用于站内应用或轻应用)
        ///// </summary>
        ///// <param name="verifyRequest">从请求中获得的verify_request,是易班发送给当前应用的授权信息(该信息使用AES加密)</param>
        ///// <returns></returns>
        //public static VisitOauth CheckAuthor(string verifyRequest)
        //{
        //    return Oauther.CheckAuthor(verifyRequest);
        //}

        #endregion 授权静态方法
        


    }
}