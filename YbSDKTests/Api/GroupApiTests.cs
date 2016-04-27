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
    public class GroupApiTests
    {
        private GroupApi api = null;
        [TestInitialize]
        public void Init()
        {
            api = new GroupApi(GlobalConfig.accessToken);
        }
        [TestMethod()]
        public void GetOrganGroupsTest()
        {
            var result = api.GetPublicGroups();
            Debug.WriteLine(result.info.num);
            foreach (var item in result.info.public_group)
            {
                Debug.WriteLine(item.group_id + "  " + item.group_name);
            }
            Assert.AreEqual("success", result.status);
            //Assert.Fail();
        }
        //302828
        [TestMethod()]
        public void GetGroupInfoTest()
        {
            var result = api.GetGroupInfo(GlobalConfig.groupId);
            Debug.Write(result.info.group_name);
            Debug.Write(result.info.group_id);
            Assert.AreEqual("success", result.status);
            //Assert.Fail();
        }

        [TestMethod()]
        public void GetMyGroupsTest()
        {
            var result = api.GetMyGroups();

            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetOrganGroupsTest1()
        {
            var result = api.GetOrganGroups();
            foreach (var item in result.info.organ_group)
            {
                Debug.WriteLine(item.group_name + item.group_id);
            }
            Assert.AreEqual("success", result.status);
            Assert.IsNotNull(result.info.organ_group);
        }

        [TestMethod()]
        public void GetGroupMembersTest()
        {
            var result = api.GetGroupMembers(GlobalConfig.groupId);
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.member_nick);
            }

            Assert.IsNotNull(result.info.list);
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetGroupTopicsTest()
        {
            var result = api.GetGroupTopics(GlobalConfig.groupId);
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.topic_title + item.topic_id);
            }

            Assert.IsNotNull(result.info.list);
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetHotTipsTest()
        {
            var result = api.GetHotTips();
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.topic_title);
            }
            Assert.IsNotNull(result.info.list);
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetTopicInfoTest()
        {
            var result = api.GetTopicInfo(GlobalConfig.groupId, GlobalConfig.groupTopicId);
            Debug.WriteLine(result.info.topic_title);
            Assert.IsNotNull(result.info.topic_id);
            Assert.AreEqual("success", result.status);
        }

        [TestMethod()]
        public void GetTopicCommentTest()
        {
            var result = api.GetTopicComment(GlobalConfig.groupId, GlobalConfig.groupTopicId);
            //Debug.WriteLine(result.info.list)
            foreach (var item in result.info.list)
            {
                Debug.WriteLine(item.comment_content+"  "+item.comment_id);
            }
            Assert.IsNotNull(result.info);
            Assert.AreEqual("success", result.status);
            //Assert.Fail();
        }

        [TestMethod()]
        public void SendTopicTest()
        {
            var result = api.SendTopic(GlobalConfig.groupId, "测试测试", "测试测试");
            Assert.AreEqual(true, result);
        }

        [TestMethod()]
        public void SendCommentTest()
        {
            var result = api.SendComment(GlobalConfig.groupId, GlobalConfig.groupTopicId, "测试回复");
            Assert.AreEqual(true, result);
            //Assert.Fail();
        }

        [TestMethod()]
        public void DeleteCommentTest()
        {
            //获得评论
            var result = api.GetTopicComment(GlobalConfig.groupId, GlobalConfig.groupTopicId);
            //删除评论列表中的第一评论
            var deleteResult= api.DeleteComment(GlobalConfig.groupId, GlobalConfig.groupTopicId,result.info.list.FirstOrDefault().comment_id);
            Assert.AreEqual(true, deleteResult);
        }
    }
}