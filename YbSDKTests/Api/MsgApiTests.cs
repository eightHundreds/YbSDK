using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class MsgApiTests
    {
        [TestInitialize]
        public void Init()
        {
            api = new MsgApi(GlobalConfig.accessToken, GlobalConfig.Webconfig);
            userApi = new UserApi(GlobalConfig.accessToken, GlobalConfig.Webconfig);
        }
        public MsgApi api { get; set; }
        public UserApi userApi { get; set; }


        [TestMethod()]
        public void SendMsgTest()
        {
           
            var me = userApi.GetMe();
            var result=api.SendMsg(me.info.yb_userid, "6666");
            Assert.AreEqual(true, result);
        }
    }
}