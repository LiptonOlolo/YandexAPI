using System.Collections.Generic;

namespace YandexAPI.SpeechKitCloud.ASR.Responses
{
    /// <summary>
    /// Результат распознования голоса.
    /// </summary>
    public sealed class AsrResponse
    {
        /// <summary>
        /// Статус распознования, true - голос распознан.
        /// </summary>
        public bool Success { get; internal set; }

        /// <summary>
        /// Варианты распознования голоса.
        /// </summary>
        public List<Variant> Variants { get; } = new List<Variant>();
    }

    /// <summary>
    /// Вариант распознования текста.
    /// </summary>
    public sealed class Variant
    {
        internal Variant(string conf, string text)
        {
            Confidence = float.Parse(conf.Replace('.', ','));
            Text = text;
        }

        /// <summary>
        /// Примечание. 
        /// Значение атрибута Confidence не является цифровым эквивалентом достоверности или точности распознавания и не используется при сортировке списка гипотез.
        /// </summary>
        public float Confidence { get; }

        /// <summary>
        /// Текст распознования.
        /// </summary>
        public string Text { get; }
    }
}
