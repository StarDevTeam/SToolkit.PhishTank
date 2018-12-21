using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
#if !NET35 && !NET40
using System.Net.Http;
#else
using System.Text;
using System.Collections.Specialized;
#endif
using System.Xml;

namespace SToolkit.PhishTank
{
    public class PhishTankApi
    {

        public WebProxy Proxy
        {
#if NET35 || NET40
            get => (WebProxy)WebClient.Proxy;
            set
            {
                if (WebClient.Proxy != value)
                    WebClient.Proxy = value;
            }
#else
            get => (WebProxy)_HttpClientHandler.Proxy;
            set
            {
                if (_HttpClientHandler.Proxy != value)
                    _HttpClientHandler.Proxy = value;
            }
#endif
        }

        private string Key { get; set; }

#if NET35 || NET40
        private WebClient WebClient { get; set; }
#else
        private HttpClient WebClient { get; set; }
        private HttpClientHandler _HttpClientHandler { get; set; }
#endif


        private const string ApiUrl = "http://checkurl.phishtank.com/checkurl/";

        public PhishTankApi(string key)
        {
            Key = key;
#if NET35 || NET40
            WebClient = new WebClient();
#else
            _HttpClientHandler = new HttpClientHandler();
            WebClient = new HttpClient(_HttpClientHandler, true);
#endif
        }

        public PhishResult Check(string url)
        {
            XmlDocument doc = new XmlDocument();
#if NET35 || NET40
            NameValueCollection values = new NameValueCollection
            {
                ["url"] = url,
                ["format"] = "xml",
                ["app_key"] = Key
            };
            doc.Load(new StringReader(Encoding.UTF8.GetString(WebClient.UploadValues(ApiUrl, values))));
#else
            FormUrlEncodedContent content = new FormUrlEncodedContent(new Dictionary<string, string>
            {
               { "url", url },
               { "format", "xml" },
               { "app_key", Key }
            });
            HttpResponseMessage response = WebClient.PostAsync(ApiUrl, content).Result;
            doc.Load(new StringReader(response.Content.ReadAsStringAsync().Result));
#endif
            if (doc["response"]["results"]["errortext"] == null)
            {
                PhishResult result = new PhishResult
                {
                    Url = doc["response"]["results"]["url0"]["url"].FirstChild.Value,
                    InDatabase = bool.Parse(doc["response"]["results"]["url0"]["in_database"].FirstChild.Value)
                };
                if (result.InDatabase)
                {
                    if (doc["response"]["results"]["url0"]["phish_id"] != null)
                        result.PhishID = int.Parse(doc["response"]["results"]["url0"]["phish_id"].FirstChild.Value);
                    if (doc["response"]["results"]["url0"]["phish_detail_page"] != null)
                        result.PhishPage = doc["response"]["results"]["url0"]["phish_detail_page"].FirstChild.Value;
                    if (doc["response"]["results"]["url0"]["verified"] != null)
                        result.Verified = bool.Parse(doc["response"]["results"]["url0"]["verified"].FirstChild.Value);
                    if (doc["response"]["results"]["url0"]["verified_at"] != null)
                        result.VerifiedDate = DateTime.Parse(doc["response"]["results"]["url0"]["verified_at"].FirstChild.Value);
                    if (doc["response"]["results"]["url0"]["valid"] != null)
                        result.IsPhish = bool.Parse(doc["response"]["results"]["url0"]["valid"].FirstChild.Value);
                }
                return result;
            }
            throw new Exception(doc["response"]["results"]["errortext"].FirstChild.Value);
        }
    }
}
