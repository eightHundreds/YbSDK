using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class SchoolApiTests
    {
        private SchoolApi api;
        [TestInitialize]
        public void Init()
        {
            api = new SchoolApi(GlobalConfig.accessToken);
        }

        //权限不足无法测试
        [TestMethod()]
        public void GetUserActiveTest()
        {
            var result = api.GetUserActive();
            Assert.AreEqual("success", result.status);
            //Assert.Fail();
        }
    }
}