using static YandexAPI.StaticMapsAPI.Enums.FloatHelper;

namespace YandexAPI.StaticMapsAPI
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
        public float Longitude { get; }

        /// <summary>
        /// Широта.
        /// </summary>
        public float Latitude { get; }

        /// <summary>
        /// Получить точку карты в формате {Долгота},{Широта}.
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{FloatToString(Longitude)},{FloatToString(Latitude)}";
    }
}
