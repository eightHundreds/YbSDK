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
            api = new OauthApi();
        }

        [TestMethod()]
        public void GetAuthorizeUrlTest()
        {

            string url = api.GetAuthorizeUrl("1");
            //Assert.Fail();
            Assert.AreEqual("https://openapi.yiban.cn/oauth/authorize?client_id=198cf948b42d692f&redirect_uri=http://online.cumt.edu.cn/irides/oauth/yiban&display=web&state=1", url);
        }

        [TestMethod()]
        public void GetAccessTokenTest()
        {
            var result = api.GetAccessToken(GlobalConfig.code);
            Assert.IsNotNull(result.expires);
            //Assert.AreEqual("", result.access_token);
            //Assert.Fail();
        }

        [ExpectedException(typeof(YbException))]
        [TestMethod]
        public void GetAccessTokenErrorTest()
        {
            var result = api.GetAccessToken(GlobalConfig.accessToken);
            Assert.IsNotNull(result.expires);
        }

        [TestMethod()]
        public void GetTokenInfoTest()
        {
            //var result = api.GetAccessToken("9a5ccdc30e013d689b6c86eb37a6dade0fec008");
            var result = api.GetAccessToken(GlobalConfig.code);
            Assert.IsNotNull(result.access_token);
        }

        [TestMethod()]
        public void CheckAuthorTest()
        {
            var result = api.CheckAuthor(GlobalConfig.verify_request);
            Assert.AreEqual(true, result.IsAuthorized);
        }

      
    }
}