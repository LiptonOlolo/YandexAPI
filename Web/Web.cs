using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using YandexAPI.Linguistics.Response;

/*
 * 
 * Пожалуйста, не смотрите код ниже, это Вас убьет.
 * 
 */

namespace YandexAPI
{
    static class Web
    {
        static string GetString(string uri) => new WebClient
        {
            Encoding = Encoding.UTF8,
            Proxy = new WebProxy()
        }.DownloadString(uri);

        static string GetUri(string uri, Dictionary<string, string> get)
        {
            uri += "?";
            foreach (KeyValuePair<string, string> value in get)
                uri += $"{value.Key}={value.Value}&";

            return uri;
        }

        static T GetStringType<T>(string uri, Dictionary<string, string> get, out string responseText)
        {
            responseText = GetString(GetUri(uri, get));
            return JsonConvert.DeserializeObject<T>(responseText);
        }

        public static T Get<T>(string uri, Dictionary<string, string> get, string apikey, bool writeApi = true, bool checkError = true)
        {
            string rText;

            if (writeApi)
                get.Add("key", apikey);

            if (!checkError)
                return GetStringType<T>(uri, get, out rText);

            Error err = GetStringType<Error>(uri, get, out rText);

            if (err)
                return JsonConvert.DeserializeObject<T>(rText);

            throw new Exception($"Get data from API error: code {err.code}, message: {err.message}");
        }

        public static IEnumerable<string> GetJsonArray(string uri, Dictionary<string, string> get, string apikey) //Слишком говнокод
        {
            if (apikey != null)
                get.Add("key", apikey);

            string response = GetString(GetUri(uri, get));

            if (response.IndexOf("code\":1") > 1 || !response.Contains("{\"code\":"))
            {
                var arr = JArray.Parse(response);
                int count = arr.Count;

                for (int i = 0; i < count; i++)
                    yield return arr[i].ToString();
            }
            else
            {
                Error err = JsonConvert.DeserializeObject<Error>(response);
                throw new Exception($"Get data from API error: code {err.code}, message: {err.message}");
            }
        }
    }
}
