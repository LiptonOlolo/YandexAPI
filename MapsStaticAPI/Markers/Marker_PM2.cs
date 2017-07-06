namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Маркер 'pm2'.
    /// Размер: M, L.
    /// Контент:
    /// число от 1 до 99.
    /// </summary>
    public sealed class Marker_PM2
    {
        const string style = "pm2";

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
        /// Зеленый
        /// </summary>
        public static Marker Gn => new Marker(style, "gn");

        /// <summary>
        /// Темно-зеленый.
        /// </summary>
        public static Marker Dg => new Marker(style, "dg");

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
        /// Красный
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
        /// С буквой "А" (без указания контента).
        /// </summary>
        public static Marker A => new Marker(style, "wt", true, false);

        /// <summary>
        /// С буквой "Б" (без указания контента).
        /// </summary>
        public static Marker B => new Marker(style, "wt", true, false);

        /// <summary>
        /// Голубой (без указания контента).
        /// </summary>
        public static Marker Org => new Marker(style, "wt", true, false);

        /// <summary>
        /// Фиолетовый (без указания контента).
        /// </summary>
        public static Marker Dir => new Marker(style, "wt", true, false);

        /// <summary>
        /// Голубой с жёлтой точкой.
        /// </summary>
        public static Marker Blyw => new Marker(style, "wt");
    }
}
