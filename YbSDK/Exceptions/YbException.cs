using RestSharp;
using System;
using System.Runtime.Serialization;
using YbSDK.Model;

namespace YbSDK.Exceptions
{
    public  class YbException : Exception
    {
        #region 自定义构造函数

        public YbException(ErrorInfo error, string message = "") 
        {
            YbError = error;
            Response = null;
        }

        public YbException(ErrorInfo error, IRestResponse response, string message = "") : base(message)
        {
            YbError = error;
            Response = response;
        }

        #endregion 自定义构造函数

        public YbException()
        {
        }

        public YbException(string message) : base(message)
        {
        }

        public YbException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected YbException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        public ErrorInfo YbError { get; set; }
        public IRestResponse Response { get; private set; }
    }
}