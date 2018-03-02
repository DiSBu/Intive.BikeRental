using System.Net;

namespace Intive.BikeRental.Utility
{
    public interface IHttpServiceHelper
    {
        WebRequest GetRequest(string method, string contentType, string uri, string content);

        string GetResponse(WebResponse response);

        string Post<TConvertType>(TConvertType item, string uriPart, string uriBase);

        string Post<TConvertType>(TConvertType item, string uriPart, string uriBase, string contentType);

        void PostAsync<TConvertType>(TConvertType item, string uriPart, string uriBase);

        void PostAsync<TConvertType>(TConvertType item, string uriPart, string uriBase, string contentType);

        T Get<T>(string uriPart, string uriBase);

        T Get<T>(string uriPart, string uriBase, string contentType);
    }
}