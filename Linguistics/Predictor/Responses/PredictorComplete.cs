using Newtonsoft.Json;

namespace YandexAPI.Linguistics.Predictor.Responses
{
    /// <summary>
    /// Наиболее вероятное продолжение текста.
    /// </summary>
    public sealed class PredictorComplete : Error
    {
        /// <summary>
        /// Признак конца слова.
        /// </summary>
        [JsonProperty("endOfWord")]
        public bool EndOfWord { get; private set; }

        /// <summary>
        /// Позиция в слове, для которого возвращается продолжение. Позиция отсчитывается от последнего символа в запросе, переданном в элементе q.
        /// Обычно, pos принимает отрицательные значения. Например, для текста q="кот в сапо" будет возвращено pos=-4. 
        /// Если запрос содержит завершенную фразу, то может быть возвращена подсказка для следующего слова. 
        /// При этом pos будет принимать значение 0 (например, при q="кот в ") или 1 (например, q="кот в").
        /// </summary>
        [JsonProperty("pos")]
        public short Pos { get; private set; }

        /// <summary>
        /// Содержит элементы string с наиболее вероятными вариантами продолжения заданного текста.
        /// Если метод не может "продолжить" текст, то элемент не возвращается.
        /// </summary>
        [JsonProperty("text")]
        public string[] Text { get; private set; }
    }
}
