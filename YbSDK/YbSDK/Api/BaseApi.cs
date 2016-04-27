using RestSharp;
using RestSharp.Deserializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using YbSDK.Exceptions;
using YbSDK.Model;

namespace YbSDK.Api
{
    /// <summary>
    /// Api基类
    /// </summary>
    public abstract class BaseApi
    {
        /// <summary>
        /// 易班Api上下文
        /// </summary>
        public ApiContext context;
        protected IRestClient restClient = new RestClient("https://openapi.yiban.cn");
        private System.Web.Script.Serialization.JavaScriptSerializer jss = new System.Web.Script.Serialization.JavaScriptSerializer();

        #region 构造函数,抽象类的构造函数,子类必须实现
        protected BaseApi(string token)
        {
            this.context = new ApiContext(token);
        }
        protected BaseApi(AccessToken token)
        {
            this.context = new ApiContext(token);
        }
        protected BaseApi(ApiContext context)
        {
            this.context = context;
        }
        #endregion


        /// <summary>
        /// 检测是否响应存在错误,当响应结果字符串中包含检测字符串则返回true
        /// </summary>
        /// <param name="response">被检测响应</param>
        /// <param name="checkStr">检测字符串</param>
        /// <returns></returns>
        protected bool CheckError(IRestResponse response, string checkStr = "\"status\":\"error\"")
        {
            return response.Content.Contains(checkStr);
        }

        /// <summary>
        /// 生成请求
        /// </summary>
        /// <param name="method">请求方法</param>
        /// <param name="resource"></param>
        /// <returns></returns>
        protected RestRequest CreateRequest(RestSharp.Method method, string resource)
        {
            RestRequest request = null;
            switch (method)
            {
                case Method.GET:
                    request = new RestRequest(Method.GET);
                    break;
                case Method.POST:
                    request = new RestRequest(Method.POST);
                    request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
                    break;
                case Method.PUT:
                    break;
                case Method.DELETE:
                    break;
                default:
                    break;
            }

            request.Resource = resource;
            request.RequestFormat = DataFormat.Json;
            return request;
        }

        /// <summary>
        /// json字符串转换成model类
        /// </summary>
        /// <typeparam name="T">model类型</typeparam>
        /// <param name="content">json字符串</param>
        /// <returns></returns>
        protected T Deserialize<T>(string content)
        {
            return jss.Deserialize<T>(content);
            //return RestResponse
          
        }

        /// <summary>
        /// 生成异常
        /// </summary>
        /// <param name="response">请求响应类</param>
        protected YbException GenerateError(IRestResponse response)
        {
            ErrorInfo errorInfo = new ErrorInfo();
            errorInfo = Deserialize<ErrorInfo>(response.Content);
            return new YbException(errorInfo, errorInfo.info.msgCN);
        }

        
    }
}
