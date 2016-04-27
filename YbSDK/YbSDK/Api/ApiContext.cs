using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (_config == null)
                {
                    _config = new YbConfig();
                }
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
        public ApiContext(AccessToken token)
        {
            this.token = token;
        }
        public ApiContext(string token)
        {
            this.token = new AccessToken() { access_token = token, expires = 0, userid =0 };
        }
        public ApiContext(AccessToken token,YbConfig config):this(token)
        {
            _config = config;
        }
        #endregion

    }
}
