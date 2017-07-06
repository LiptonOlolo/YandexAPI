using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace YandexAPI
{
    static class Web
    {
        /// <summary>
        /// Получить экземпляр нового класса WebClient.
        /// </summary>
        /// <returns></returns>
        public static WebClient CreateClient() => new WebClient
        {
            Encoding = Encoding.UTF8,
            Proxy = new WebProxy()
        };

        /// <summary>
        /// Получить ответ от API в виде массива байт.
        /// </summary>
        /// <returns></returns>
        public static byte[] GetData(string uri, NameValueCollection get)
        {
            using (WebClient client = CreateClient())
                return client.UploadValues(uri, get);
        }

        static string GetString(string uri, NameValueCollection get) => Encoding.UTF8.GetString(GetData(uri, get));

        /// <summary>
        /// Получить ответ от API в нужном типе данных.
        /// </summary>
        public static T Get<T>(string uri, NameValueCollection get, string apikey)
        {
            if (apikey != null)
                get.Add("key", apikey);

            return JsonConvert.DeserializeObject<T>(GetString(uri, get));
        }
    }
}
