using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace YbSDK.Config
{
    /// <summary>
    /// 配置类型枚举
    /// </summary>
    public enum ConfigType
    {
        /// <summary>
        /// 网站接入
        /// </summary>
        YbWebConnect = 1,
        /// <summary>
        /// 轻应用
        /// </summary>
        YbLight = 2,
        /// <summary>
        /// 站内应用
        /// </summary>
        YbInSite = 3
    }

    /// <summary>
    /// 易班配置类
    /// </summary>
    public  class YbConfig
    {
        private NameValueCollection YbSection;
        private string appId;
        private string appSecret;
        private string oauthUrl;
        private string callBack;
        private string appType;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="type"></param>
        public YbConfig(ConfigType type)
        {
            switch (type)
            {
                case ConfigType.YbWebConnect:
                    YbSection = (NameValueCollection)ConfigurationManager.GetSection("YbApp/YbWebConnect");
                    break;
                case ConfigType.YbLight:
                    YbSection = (NameValueCollection)ConfigurationManager.GetSection("YbApp/YbLight");
                    appType = "html";
                    break;
                case ConfigType.YbInSite:
                    YbSection = (NameValueCollection)ConfigurationManager.GetSection("YbApp/YbInSite");
                    break;
                default:
                    break;
            }
        }

        public string AppId
        {
            get
            {
                if (string.IsNullOrEmpty(appId))
                {
                    appId = YbSection["AppId"];
                }
                return appId;
            }
        }

        public string AppSecret
        {
            get
            {
                if (string.IsNullOrEmpty(appSecret))
                {
                    appSecret = YbSection["AppSecret"];
                }
                return appSecret;
            }
        }

        public string OauthUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(oauthUrl))
                {
                    oauthUrl = "https://openapi.yiban.cn/oauth/authorize";
                }
                return oauthUrl;
            }
            set
            {
                oauthUrl = value;
            }
        }

        public string Callback
        {
            get
            {
                if (string.IsNullOrEmpty(callBack))
                {
                    callBack = YbSection["Callback"]??"";
                }
                return callBack;
            }
        }

        public string Type
        {
            get
            {
                if (string.IsNullOrEmpty(appType))
                {
                    appType = YbSection["Type"] ?? "";
                }
                return appType;
            }
        }
    }
}
