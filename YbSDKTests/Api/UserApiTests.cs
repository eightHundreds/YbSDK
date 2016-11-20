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

            api = new UserApi(GlobalConfig.accessToken, GlobalConfig.Webconfig);
        }
        [TestMethod()]
        public void GetMeTest()
        {
            var me = api.GetMe();
            Assert.AreEqual("success", me.status);
            Console.WriteLine(me.info.yb_username);
            //Assert.AreEqual("八百", me.info.yb_username);
            //Assert.Fail();
        }


        [TestMethod()]
        public void GetOtherTest()
        {
            var me = api.GetMe();
            var Other = api.GetOther(me.info.yb_userid);
            Assert.AreEqual("success", Other.status);
        }

   
        [TestMethod()]
        public void GetRealTest()
        {
            var Other = api.GetReal();
            Assert.AreEqual("success", Other.status); ;
        }

    
        [TestMethod()]
        public void GetVerifyTest()
        {
            var verify = api.GetVerify();
            Assert.AreEqual("success", verify.status);
            //Assert.Fail();
        }

        [TestMethod()]
        public void CheckVerifyTest()
        {
            var result = api.CheckVerify("中国矿业大学", "张永红", Model.VerifyKey.学号, "08143150");
            Assert.AreEqual(false, result);
        }

        [TestMethod()]
        public void IsRealTest()
        {
            var me = api.GetMe();
            var result = api.IsReal(me.info.yb_userid);
            Assert.AreEqual(true, result);
            Console.WriteLine(result);
        }

        [TestMethod()]
        public void IsVerifyTest()
        {
            var result = api.IsVerify("中国矿业大学", Model.VerifyKey.学号, "08143178");
            Assert.AreEqual("True", result.info.result);
            Console.WriteLine(result.info.sure_schoolname);
        }
    }
}