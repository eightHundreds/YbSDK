using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Shouldly;
namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class PayApiTests
    {
        PayApi api = new PayApi(GlobalConfig.accessToken, GlobalConfig.LightConfig);
        public PayApiTests()
        {

        }
        [TestMethod()]
        public void PayWangXinTest()
        {
            var result = api.PayWangXin(1);
            result.ShouldBe(true);
        }

        [TestMethod()]
        public void TradeWangXinTest()
        {
            var result = api.TradeWangXin(1, "http://baidu.com");
            Console.WriteLine(result.info.sign_href);
        }

        [TestMethod()]
        public void CheckTradeTest()
        {
            //trade_id=57429af8zhpbc56&trade_end=success&yb_sign=7e49e9e75e5425c6df8979027c4e6290afdebc2da544c1ed186a1bef489b35e7&end_time=1473490738
        }
    }
}