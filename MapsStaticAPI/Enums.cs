using static YandexAPI.MapsStaticAPI.FloatHelper;

namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Долгота и широта центра карты в градусах.
    /// </summary>
    public sealed class MapPoint
    {
        /// <summary>
        /// Конструктор класса MapPoint.
        /// </summary>
        /// <param name="longitude">Долгота.</param>
        /// <param name="latitude">Широта.</param>
        public MapPoint(float longitude, float latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
        }

        /// <summary>
        /// Долгота.
        /// </summary>
        public readonly float Longitude;

        /// <summary>
        /// Широта.
        /// </summary>
        public readonly float Latitude;

        /// <summary>
        /// Получить точку карты в формате {Долгота},{Широта}.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{FloatToString(Longitude)},{FloatToString(Latitude)}";
        }
    }

    /// <summary>
    /// Перечень слоев, определяющих тип карты.
    /// </summary>
    public sealed class MapType
    {
        private MapType(string type) => this.type = type;

        /// <summary>
        /// Тип карты.
        /// </summary>
        public readonly string type;

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
        public override string ToString() => type;
    }
}
