namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Маркер 'vk' (кнопка).
    /// Размер: M.
    /// Без контента.
    /// </summary>
    public sealed class Marker_VK
    {
        const string style = "vk";

        /// <summary>
        /// Черная кнопка.
        /// </summary>
        public static Marker Bk => new Marker(style, "bk", true, false);

        /// <summary>
        /// Серая кнопка.
        /// </summary>
        public static Marker Gr => new Marker(style, "gr", true, false);
    }
}
