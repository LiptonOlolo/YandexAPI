namespace YandexAPI.Linguistics.Dictionary
{
    /// <summary>
    /// Опции поиска.
    /// </summary>
    public enum DictionaryFlags : int
    {
        /// <summary>
        /// Нет фильтров.
        /// </summary>
        None = 0x0000,

        /// <summary>
        /// Применить семейный фильтр.
        /// </summary>
        Family = 0x0001,

        /// <summary>
        /// Отображать названия частей речи в краткой форме.
        /// </summary>
        ShortPos = 0x0002,

        /// <summary>
        /// Включает поиск по форме слова.
        /// </summary>
        Morpho = 0x0004,

        /// <summary>
        /// Включает фильтр, требующий соответствия частей речи искомого слова и перевода.
        /// </summary>
        PosFilter = 0x0008,
    }
}
