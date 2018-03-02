using System.Net;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Intive.BikeRental.Utility.Test
{
    [TestClass]
    public class HttpServiceHelperTest
    {
        private const string SzMethod = "POST";
        private const string SzContentType = "text/plain";
        private const string SzUriPost = "https://www.google-analytics.com/collect";
        private const string SzUriGet = "http://www.google.com/";
        private const string SzContent = "ContentTest";

        private static HttpServiceHelper _httpServiceHelperController;

        [ClassInitialize]
        public static void Init(TestContext context)
        {
            _httpServiceHelperController = new HttpServiceHelper();
        }

        [TestMethod]
        public void GetRequest_GetNewRequest_ShouldReturnCorrectRequest()
        {
            var request = _httpServiceHelperController.GetRequest(SzMethod, SzContentType, SzUriGet, SzContent);
            Assert.IsNotNull(((HttpWebRequest)request).Address);
            Assert.IsFalse(string.IsNullOrEmpty(((HttpWebRequest)request).ContentType));
            Assert.IsFalse(string.IsNullOrEmpty(((HttpWebRequest)request).Method));
        }

        [TestMethod]
        public void GetResponse_GetNewResponse_ShouldReturnCorrectResponse()
        {
            var response = _httpServiceHelperController.GetResponse(GetFakeWebResponse());
            Assert.IsNotNull(response);
        }

        [TestMethod]
        public void Post_NewPost_ShouldReturnCorrectResponse()
        {
            var responseOne = _httpServiceHelperController.Post(string.Empty, string.Empty, SzUriPost);
            Assert.IsNotNull(responseOne);

            var responseTwo = _httpServiceHelperController.Post<string>(string.Empty, string.Empty, SzUriPost);
            Assert.IsNotNull(responseTwo);
            Assert.IsFalse(string.IsNullOrEmpty(responseTwo));

            var responseThree = _httpServiceHelperController.Post<string>(string.Empty, string.Empty, null);
            Assert.IsTrue(string.IsNullOrEmpty(responseThree));
        }

        [TestMethod]
        public void PostAsync_NewPostAsync_ShouldReturnCorrectResponse()
        {
            _httpServiceHelperController.PostAsync<string>(string.Empty, string.Empty, SzUriPost);
        }
        
        private static WebResponse GetFakeWebResponse()
        {
            return System.Net.WebRequest.Create(SzUriGet).GetResponse();
        }
    }
}
