namespace YandexAPI.StaticMapsAPI.Enums
{
    /// <summary>
    /// Перечень слоев, определяющих тип карты.
    /// Для использования нескольких слоев используйте оператор |.
    /// Пример: MapType.Map | MapType.Sat.
    /// </summary>
    public sealed class MapType
    {
        private MapType(string type) => Type = type;

        /// <summary>
        /// Тип карты.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// Объединение слоев карты.
        /// </summary>
        /// <param name="first">Первый слой.</param>
        /// <param name="second">Второй слой.</param>
        /// <returns></returns>
        public static MapType operator |(MapType first, MapType second) => new MapType($"{first.Type},{second.Type}{(second.Type.Contains(",") ? "," : "")}");

        /// <summary>
        /// Схема местности и названия географических объектов.
        /// </summary>
        public static MapType Map = new MapType("map");

        /// <summary>
        /// Местность, сфотографированная со спутника.
        /// </summary>
        public static MapType Sat = new MapType("sat");

        /// <summary>
        /// Названия географических объектов.
        /// </summary>
        public static MapType Skl = new MapType("skl");

        /// <summary>
        /// Слой пробок.
        /// </summary>
        public static MapType Trf = new MapType("trf");

        /// <summary>
        /// Возвращает тип карты.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Type;
    }
}
