namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Векторные маркеры.
    /// Без размера и контента.
    /// </summary>
    public sealed class Marker_Vector
    {
        /// <summary>
        /// Голубая метка с хвостиком
        /// </summary>
        public static Marker Org => new Marker("org", "", false, false);

        /// <summary>
        /// Голубая метка с кругом в центре.
        /// </summary>
        public static Marker Comma => new Marker("comma", "", false, false);

        /// <summary>
        /// Голубая метка с в виде круга
        /// </summary>
        public static Marker Round => new Marker("round", "", false, false);

        /// <summary>
        /// Значок дома.
        /// </summary>
        public static Marker Home => new Marker("home", "", false, false);

        /// <summary>
        /// Значок работы.
        /// </summary>
        public static Marker Work => new Marker("work", "", false, false);

        /// <summary>
        /// Значок с логотипом Яндекса.
        /// </summary>
        public static Marker Yandex => new Marker("ya_ru", "", false, false);
    }
}
