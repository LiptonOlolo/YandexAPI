namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Маркер 'pm'.
    /// Размер: любой.
    /// Контент:
    /// для размеров s и m — число от 1 до 99,
    /// для размера l — число от 1 до 100.
    /// </summary>
    public sealed class Marker_PM
    {
        const string style = "pm";

        /// <summary>
        /// Белый.
        /// </summary>
        public static Marker Wt => new Marker(style, "wt");

        /// <summary>
        /// Темно-оранжевый.
        /// </summary>
        public static Marker Do => new Marker(style, "do");

        /// <summary>
        /// Темно-синий.
        /// </summary>
        public static Marker Db => new Marker(style, "db");

        /// <summary>
        /// Синий.
        /// </summary>
        public static Marker Bl => new Marker(style, "bl");

        /// <summary>
        /// Зеленый.
        /// </summary>
        public static Marker Gn => new Marker(style, "gn");

        /// <summary>
        /// Серый.
        /// </summary>
        public static Marker Gr => new Marker(style, "gr");

        /// <summary>
        /// Светло-синий.
        /// </summary>
        public static Marker Lb => new Marker(style, "lb");

        /// <summary>
        /// Темная ночь.
        /// </summary>
        public static Marker Nt => new Marker(style, "nt");

        /// <summary>
        /// Оранжевый.
        /// </summary>
        public static Marker Or => new Marker(style, "or");

        /// <summary>
        /// Розовый.
        /// </summary>
        public static Marker Pn => new Marker(style, "pn");

        /// <summary>
        /// Красный.
        /// </summary>
        public static Marker Rd => new Marker(style, "rd");

        /// <summary>
        /// Фиолетовый.
        /// </summary>
        public static Marker Vv => new Marker(style, "vv");

        /// <summary>
        /// Желтый.
        /// </summary>
        public static Marker Yw => new Marker(style, "yw");

        /// <summary>
        /// С буквой 'А'.
        /// </summary>
        public static Marker A => new Marker(style, "a", false, false);

        /// <summary>
        /// С буквой 'Б'.
        /// </summary>
        public static Marker B => new Marker(style, "b", false, false);
    }
}
