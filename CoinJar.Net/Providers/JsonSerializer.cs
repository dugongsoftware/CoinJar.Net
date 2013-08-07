using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Providers
{
    public class JsonSerializer<T>
    {
        public IWebProxy Proxy { get; internal set; }
        public ICredentials Credentials { get; internal set; }

        public T GetObject(Uri url)
        {
            WebRequest request = WebRequest.Create(url);

            if (this.Proxy != null)
            {
                request.Proxy = this.Proxy;
            }

            if (this.Credentials != null)
            {
                request.Credentials = this.Credentials;
            }

            using (Stream objStream = request.GetResponse().GetResponseStream())
            {
                if (objStream != null)
                {
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                    T response = (T)jsonSerializer.ReadObject(objStream);

                    return response;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
        }

        public T GetObjectFromString(String data)
        {
            using (MemoryStream ms = new MemoryStream(System.Text.Encoding.Default.GetBytes(data)))
            {
                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(T));
                T response = (T)jsonSerializer.ReadObject(ms);

                return response;
            }
        }
    }
}
