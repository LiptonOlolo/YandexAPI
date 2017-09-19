using Newtonsoft.Json;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace YandexAPI.WebHelper
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
        /// <param name="uri">URL.</param>
        /// <param name="get">Параметры.</param>
        /// <returns></returns>
        public static byte[] GetData(string uri, NameValueCollection get)
        {
            using (var client = CreateClient())
                return client.UploadValues(uri, get);
        }

        /// <summary>
        /// Получить ответ от API в виде сырой строки (JSON or XML).
        /// </summary>
        /// <param name="uri">URL.</param>
        /// <param name="get">Параметры</param>
        /// <returns></returns>
        static string GetString(string uri, NameValueCollection get) =>
            Encoding.UTF8.GetString(GetData(uri, get));

        /// <summary>
        /// Получить ответ от API в указанном типе.
        /// </summary>
        /// <typeparam name="T">Тип, в котором нужно получить ответ.</typeparam>
        /// <param name="uri">URL.</param>
        /// <param name="get">Параметры.</param>
        /// <param name="apikey">null, если ключ не нужно передавать</param>
        /// <returns></returns>
        public static T Get<T>(string uri, NameValueCollection get, string apikey)
        {
            if (apikey != null)
                get.Add("key", apikey);

            try
            {
                return JsonConvert.DeserializeObject<T>(GetString(uri, get));
            }
            catch (WebException ex)
            {
                throw new YandexException(FillException(ex));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Заполнить ошибку запроса.
        /// </summary>
        /// <param name="ex">Ошибка</param>
        /// <returns></returns>
        static Error FillException(WebException ex)
        {
            string json = string.Empty;

            using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                json = reader.ReadToEnd();

            return JsonConvert.DeserializeObject<Error>(json);
        }
    }
}
