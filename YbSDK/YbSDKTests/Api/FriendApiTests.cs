using Microsoft.VisualStudio.TestTools.UnitTesting;
using YbSDK.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace YbSDK.Api.Tests
{
    [TestClass()]
    public class FriendApiTests
    {
        private FriendApi api;
        [TestInitialize]
        public void Init()
        {
            api = new FriendApi(GlobalConfig.accessToken);
        }
        [TestMethod()]
        public void GetMyFriendsTest()
        {
            var result = api.GetMyFriends();
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.yb_username + "  " + item.yb_userid);
            }
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void CheckFriendTest()
        {
            var result = api.CheckFriend(GlobalConfig.friendId);
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void ApplyFriendTest()
        {
            var result = api.ApplyFriend(GlobalConfig.NoMyFriendButIWillToBe, "申请申请");
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void GetRecommendFriendsTest()
        {
            var result = api.GetRecommendFriends();
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.yb_username + "  " + item.yb_userid);
            }
            Assert.AreEqual("success", result.status);
        }
    }
}