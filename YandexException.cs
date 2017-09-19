using System;

namespace YandexAPI
{
    /// <summary>
    /// Ошибка при запроса на Yandex API.
    /// </summary>
    public class YandexException : Exception
    {
        /// <summary>
        /// Ошибка запроса.
        /// </summary>
        public Error APIError { get; }

        internal YandexException(Error error) => APIError = error;
    }
}
