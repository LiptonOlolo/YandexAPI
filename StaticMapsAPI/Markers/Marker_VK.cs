namespace YandexAPI.StaticMapsAPI.Markers
{
    /// <summary>
    /// Маркер 'vk' (кнопка).
    /// Размер: M.
    /// Без контента.
    /// </summary>
    public sealed class Marker_VK
    {
        private Marker_VK() { }

        static Marker_VK instance = null;
        internal static Marker_VK GetInstance() => instance ?? (instance = new Marker_VK());

        const string style = "vk";

        /// <summary>
        /// Черная кнопка.
        /// </summary>
        public Marker Bk => new Marker(style, "bk", true, false);

        /// <summary>
        /// Серая кнопка.
        /// </summary>
        public Marker Gr => new Marker(style, "gr", true, false);
    }
}
