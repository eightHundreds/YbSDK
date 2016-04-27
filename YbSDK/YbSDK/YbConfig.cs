using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;

namespace YbSDK
{
    /// <summary>
    /// 易班配置类
    /// </summary>
    public  class YbConfig
    {
        private  string _appId;
        private  string _callback;
        private  string _type;
        private  string _appSecret;
        private string _oauthUrl;
        private NameValueCollection YbSection = (NameValueCollection)ConfigurationManager.GetSection("YbConnect");
        public   string AppId
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appId))
                {
                    _appId = YbSection["AppId"];
                }
                return _appId;
            }
            set
            {
                _appId = value;
            }
        }

        public   string Callback
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_callback))
                {
                    _callback = YbSection["Callback"];
                }
                return _callback;
            }
            set
            {
                _callback = value;
            }
        }

        public   string Type
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_type))
                {
                    _type = YbSection["Type"]?? "html";
                }
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public   string AppSecret
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_appSecret))
                {
                    _appSecret = YbSection["AppSecret"];
                }
                return _appSecret;
            }
            set
            {
                _appSecret = value;
            }
        }

        public string OauthUrl
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_callback))
                {
                    _oauthUrl = "https://openapi.yiban.cn/oauth/authorize";
                }
                return _oauthUrl;
            }
            set
            {
                _oauthUrl = value;
            }
        }
    }
}
