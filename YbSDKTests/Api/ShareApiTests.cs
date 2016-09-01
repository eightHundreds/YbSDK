using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class ShareApiTests
    {
        private ShareApi api = null;
        private UserApi uapi = null;
        [TestInitialize]
        public void Init()
        {
            //string token = "e8bfb22a15f055e26afb75629ee42017ea48de54";
            api = new ShareApi(GlobalConfig.accessToken, GlobalConfig.Webconfig);
            uapi = new UserApi(GlobalConfig.accessToken, GlobalConfig.Webconfig);
        }
        [TestMethod()]
        public void GetShareInfoTest()
        {
            var result = api.GetShareInfo(GlobalConfig.feedId);
            Assert.AreEqual("success", result.status);
        }


        [TestMethod()]
        public void GetOtherShareTest()
        {
            var uId = uapi.GetMe().info.yb_userid;
            var result = api.GetOtherShare(uId);
            if (result.info.list!=null)
            {
                foreach (var item in result.info.list)
                {
                    Console.WriteLine(item.yb_feedid+":"+item.yb_content);
                }
            }
            
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetMyShareTest()
        {
            var result = api.GetMyShare();
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void PostCommentTest()
        {
            var result = api.PostComment(GlobalConfig.feedId, "啦啦啦啦");
            Assert.AreEqual(true, result);
            //Assert.Fail();
        }

        [TestMethod()]
        public void PraiseTest()
        {
            var result = api.Praise(GlobalConfig.feedId);
            Assert.AreEqual(true, result);
        }
    }
}