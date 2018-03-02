using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Intive.BikeRental.Utility
{
    public class HttpServiceHelper : IHttpServiceHelper
    {
        private readonly string _serviceAccountUser;
        private readonly string _serviceAccountPassword;
        private readonly string _serviceAccountDomain;
        private readonly int _requestTimeout;

        public HttpServiceHelper()
        {
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072 | (SecurityProtocolType)768 | (SecurityProtocolType)192;
        }

        public WebRequest GetRequest(string method, string contentType, string uri, string content)
        {
            var request = this.GetRequest(method, contentType, uri);
            var dataArray = Encoding.UTF8.GetBytes(content);
            request.ContentLength = dataArray.Length;
            var requestStream = request.GetRequestStream();
            requestStream.Write(dataArray, 0, dataArray.Length);
            requestStream.Flush();
            requestStream.Close();

            return request;
        }

        public string GetResponse(WebResponse response)
        {
            var result = string.Empty;

            using (var stream = response.GetResponseStream())
            {
                if (stream != null)
                {
                    using (var reader = new StreamReader(stream))
                    {
                        result = reader.ReadToEnd();
                    }
                }
            }

            return result;
        }

        public string Post<TConvertType>(TConvertType item, string uriPart, string uriBase)
        {
            return Post<TConvertType>(item, uriPart, uriBase, "application/json");
        }

        public string Post<TConvertType>(TConvertType item, string uriPart, string uriBase, string contentType)
        {
            var result = string.Empty;
            var json = JsonConvert.SerializeObject(item);
            if (string.IsNullOrEmpty(uriBase))
                return result;

            var uri = string.Format("{0}{1}", uriBase, uriPart);
            var response = GetRequest("POST", contentType, uri, json).GetResponse();
            result = GetResponse(response);

            return result;
        }

        public void PostAsync<TConvertType>(TConvertType item, string uriPart, string uriBase)
        {
            PostAsync<TConvertType>(item, uriPart, uriBase, "application/json");
        }

        public void PostAsync<TConvertType>(TConvertType item, string uriPart, string uriBase, string contentType)
        {
            var result = string.Empty;
            var json = JsonConvert.SerializeObject(item);
            if (!string.IsNullOrEmpty(uriBase))
            {
                var uri = string.Format("{0}{1}", uriBase, uriPart);
                GetRequest("POST", contentType, uri, json).GetResponseAsync();
            }
        }

        public T Get<T>(string uriPart, string uriBase)
        {
            return Get<T>(uriPart, uriBase, "application/json");
        }

        public T Get<T>(string uriPart, string uriBase, string contentType)
        {
            var returnVal = default(T);
            if (!string.IsNullOrEmpty(uriBase))
            {
                var uri = string.Format("{0}{1}", uriBase, uriPart);
                var response = GetRequest("GET", contentType, uri).GetResponse();
                var result = GetResponse(response);
                returnVal = JsonConvert.DeserializeObject<T>(result, new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All });
            }

            return returnVal;
        }

        private WebRequest GetRequest(string method, string contentType, string uri)
        {
            var request = (HttpWebRequest)WebRequest.Create(uri);
             
            request.Credentials = new NetworkCredential(_serviceAccountUser, _serviceAccountPassword, _serviceAccountDomain);
            request.PreAuthenticate = true;
            request.Method = method;
            request.ContentType = contentType;

            if (_requestTimeout <= 0) return request;
            request.Timeout = _requestTimeout;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;

            return request;
        }
    }
}