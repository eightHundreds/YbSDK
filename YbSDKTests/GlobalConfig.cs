using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YbSDK.Config;

namespace YbSDK.Api.Tests
{
    /// <summary>
    /// 测试时候用到的数据
    /// </summary>
    public class GlobalConfig
    {

        public static string accessToken = "2a67a2378d8462101ebb92c698af2b19fb40acbc";
        public static string code = "f8897c49030e2fed253fd36229daaae1a1390569";
        public static string verify_request = "82067ef8e54f9fdddfa4bdf94e5a5986e1c39c928cbde45122136215602763dcfd0915186b79b73e2b8a6683fd3d1e743557263061e584afea97ea6f9d9bb84d41567e1a0f124967edd68f99ab7caad3f345c2036c3ca5e74176b7ac9f512f0fe18dbc98955301dd5ec7ca30ef63a63b5f8fb59c871b85ff4e64ebbe7a2dfcfe26e7212dfa9a1aea158cdae9be7d2aaeb556e221b8cbdf04a9d7775d3906e4ffbdefc903f4af254536783dbc8bb1a37fc368fbb991943c9455b64d07ff0b53317eaab563260a7f8bd36148c8d6aa60db3b82e335bd3e22eddba4f46d1784697fd2b343bee714922f27ecd2a7fe15d887";
        public static string feedId = ".";
        public static int groupId = 338571;
        public static int groupTopicId = 14919307;
        public static int friendId = 1;
        //发送好友申请的时候的对方用户Id
        public static int NoMyFriendButIWillToBe = 1;
        public static YbConfig Webconfig = new YbConfig(ConfigType.YbWebConnect);
        public static YbConfig LightConfig = new YbConfig(ConfigType.YbLight);

    }
}
