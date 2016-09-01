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

        public static string accessToken = "863048aa592732e19cceb9752fb7a3031814ab0e";
        public static string code = "f8897c49030e2fed253fd36229daaae1a1390569";
        public static string verify_request = "94f0228da9e0f017b205c682c36ca2f91110e71802d2d3c06b091a92ecb25ee71071de4aba49a080e8a748cab6e6187f5f3bb38de7a417746ea4b141bbb239849a761a31f2dd1ca9646c764d5fc269f894d594aeb3527ba4075c64be74deb3e66d30d343b257e50e1f3bc7509cb0619df9c43d34ef1e4da69408efb68c1a9932d7c0d1077650e259d5db3d4861a982d6b100fb7d6ada3d9e9076f376928b95d3a46bc9e655e9c35417c67153cbca7b627cb07348f6cadf42f5c7b1e74c40d6e1134e505ab827f37b5ab870086b277ab2d7f346e836e8d2c70df0862c3691b45693aebf1774ae72c6b1f06307427038f4";
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
