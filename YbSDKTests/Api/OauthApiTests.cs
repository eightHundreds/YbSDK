using YbSDK.Api;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Exceptions;
using System.Diagnostics;
using System;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class OauthApiTests
    {
        public OauthApi api { get; set; }
        [TestInitialize]
        public void Init()
        {
            api = new OauthApi(GlobalConfig.Webconfig);
        }

        [TestMethod()]
        public void GetAuthorizeUrlTest()
        {

            string url = api.GetAuthorizeUrl("1");
            Assert.AreEqual("https://openapi.yiban.cn/oauth/authorize?client_id=198cf948b42d692f&redirect_uri=http://online.cumt.edu.cn/irides/oauth/yiban&display=web&state=1", url);
        }

        [TestMethod()]
        public void GetAccessTokenTest()
        {
            var result = api.GetAccessToken(GlobalConfig.code);
            Console.WriteLine(result.access_token);
            Assert.IsNotNull(result.expires);
        }


        [TestMethod()]
        public void CheckAuthorTest()
        {
            OauthApi api = new OauthApi(GlobalConfig.LightConfig);
            var result = api.CheckAuthor(GlobalConfig.verify_request);
            Console.WriteLine(result.IsAuthorized) ;
            Console.WriteLine(result.visit_oauth);
            Console.WriteLine(result.visit_time);
            Console.WriteLine(result.visit_user);
            Assert.AreEqual(true, result.IsAuthorized);
        }

      
    }
}