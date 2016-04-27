using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YbSDK.Exceptions;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class UserApiTests
    {
        private UserApi api = null;
        [TestInitialize]
        public void Init()
        {
  
            api = new UserApi(GlobalConfig.accessToken);
        }
        [TestMethod()]
        public void GetMeTest()
        {
            var me = api.GetMe();
            Assert.AreEqual("success", me.status);
            Assert.AreEqual("八百", me.info.yb_username);
            //Assert.Fail();
        }

        [ExpectedException(typeof(YbException))]
        [TestMethod]
        public void GetMeErrorTest()
        {
            //api.context.Token.access_token = "1";
            var me = api.GetMe();
        }

        [TestMethod()]
        public void GetOtherTest()
        {
            var me = api.GetMe();
            var Other = api.GetOther(me.info.yb_userid);
            Assert.AreEqual("success", Other.status);
        }

        //无权限
        [TestMethod()]
        public void GetRealTest()
        {
            var Other = api.GetReal();
            Assert.AreEqual("success", Other.status); ;
        }

        //无权限
        [TestMethod()]
        public void GetVerifyTest()
        {
            var verify = api.GetVerify();
            Assert.AreEqual("success", verify.status);
            //Assert.Fail();
        }
    }
}