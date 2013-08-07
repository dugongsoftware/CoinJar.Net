using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;

namespace Providers
{
    public abstract class BaseCoinJar
    {
        public String ApiKey { get; set; }
        public IWebProxy Proxy { get; set; }

        /// <summary>
        /// Post to coinjar
        /// </summary>
        /// <param name="url">CoinJar url</param>
        /// <param name="postData">Post data as string</param>
        /// <returns></returns>
        internal WebResponse Post(Uri url, String postData)
        {
            WebRequest httpWebRequest = WebRequest.Create(url);
            httpWebRequest.Credentials = new NetworkCredential(this.ApiKey, "");
            httpWebRequest.ContentType = "application/x-www-form-urlencoded"; //"text/json";
            httpWebRequest.Method = "POST";

            if (this.Proxy != null)
            {
                httpWebRequest.Proxy = this.Proxy;
            }

            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            httpWebRequest.ContentLength = byteArray.Length;

            using (Stream requestStream = httpWebRequest.GetRequestStream())
            {
                // Write the data to the request stream.
                requestStream.Write(byteArray, 0, byteArray.Length);

                // Close the Stream object.
                requestStream.Close();

                // Get the response.
                WebResponse response = httpWebRequest.GetResponse();
                return response;
            }
        }
    }
}
