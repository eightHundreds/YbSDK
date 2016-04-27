using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YbSDK.Config;
using YbSDK.Model;


namespace YbSDK.Api
{
    /// <summary>
    /// Api上下文
    /// </summary>
    public class ApiContext
    {
        private YbConfig _config;
        private AccessToken token;

        /// <summary>
        /// 易班配置,从配置文件中读取
        /// </summary>
        public YbConfig Config
        {
            get
            {
                return _config;
            }
        }

        /// <summary>
        /// 易班AccessToken
        /// </summary>
        public AccessToken Token
        {
            get
            {
                return token;
            }
            set
            {
                token = value;
            }
        }
       
        #region 构造函数
        public ApiContext(string token, YbConfig config)
        {
            this.token = new AccessToken() { access_token = token, expires = 0, userid =0 };
            _config = config;
        }
        public ApiContext(AccessToken token,YbConfig config)
        {
            this.token = token;
            _config = config;
        }
        #endregion

    }
}
