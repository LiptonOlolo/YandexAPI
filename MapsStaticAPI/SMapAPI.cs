using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

using static YandexAPI.MapsStaticAPI.FloatHelper;

namespace YandexAPI.MapsStaticAPI
{
    /// <summary>
    /// Yandex API статичных карт. (Static API)
    /// </summary>
    public sealed class SMapAPI
    {
        /// <summary>
        /// Стандартный размер получаемого изображения карты.
        /// </summary>
        public static readonly Size DefaultImageSize = new Size(450, 450);

        /// <summary>
        /// Асинхронно получить изображение карты.
        /// </summary>
        /// <param name="mapType">Перечень слоев, определяющих тип карты.</param>
        /// <param name="mapCenter">Долгота и широта центра карты в градусах.</param>
        /// <param name="spn">Протяженность области показа карты по долготе и широте (в градусах).</param>
        /// <param name="z">Уровень масштабирования карты (0-17).</param>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах).</param>
        /// <param name="scale">
        /// Коэффициент увеличения объектов на карте.
        /// Может принимать дробное значение от 1.0 до 4.0.
        /// </param>
        /// <param name="markers">Маркеры для карты.</param>
        /// <param name="lines">Линии на карте, обратите внимание, что при добавлении линий не нужно указывать параметр mapCenter.</param>
        /// <param name="polygons">Многоугольник на карте, обратите внимание, что при добавлении линий не нужно указывать параметр mapCenter.</param>
        /// <param name="lang">Язык карты.</param>
        /// <returns></returns>
        public async Task<Image> GetMapAsync(MapType[] mapType, MapPoint mapCenter = null, float? spn = null,
            short? z = null, Size? size = null, float? scale = null, Marker[] markers = null,
            Line[] lines = null, Polygon[] polygons = null, Lang lang = null) =>
            await Task.Run(() => GetMap(mapType, mapCenter, spn, z, size, scale, markers, lines, polygons, lang));

        /// <summary>
        /// Получить изображение карты.
        /// </summary>
        /// <param name="mapType">Перечень слоев, определяющих тип карты.</param>
        /// <param name="mapCenter">Долгота и широта центра карты в градусах.</param>
        /// <param name="spn">Протяженность области показа карты по долготе и широте (в градусах).</param>
        /// <param name="z">Уровень масштабирования карты (0-17).</param>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах).</param>
        /// <param name="scale">
        /// Коэффициент увеличения объектов на карте.
        /// Может принимать дробное значение от 1.0 до 4.0.
        /// </param>
        /// <param name="markers">Маркеры для карты.</param>
        /// <param name="lines">Линии на карте, обратите внимание, что при добавлении линий не нужно указывать параметр mapCenter.</param>
        /// <param name="polygons">Многоугольник на карте, обратите внимание, что при добавлении линий не нужно указывать параметр mapCenter.</param>
        /// <param name="lang">Язык карты.</param>
        /// <returns></returns>
        public Image GetMap(MapType[] mapType, MapPoint mapCenter = null, float? spn = null,
            short? z = null, Size? size = null, float? scale = null, Marker[] markers = null,
            Line[] lines = null, Polygon[] polygons = null, Lang lang = null)
        {
            #region check
            if (mapType.Length == 0)
                throw new ArgumentException("mapType");

            if (scale.HasValue)
                if (scale.Value < 1.0f || scale.Value > 4.0f)
                    throw new ArgumentException("scale");

            if (z.HasValue)
                if (z.Value < 0 || z.Value > 17)
                    throw new ArgumentException("z");

            if (size.HasValue)
                if (size.Value.Height < 0 || size.Value.Height > 450 ||
                    size.Value.Width < 0 || size.Value.Width > 650)
                    throw new ArgumentException("size");
            #endregion

            Dictionary<string, string> get = new Dictionary<string, string>
            {
                ["l"] = string.Join<MapType>(",", mapType),
            };

            if (mapCenter != null)
                get.Add("ll", mapCenter.ToString());

            if (spn.HasValue)
                get.Add("spn", FloatToString(spn));

            if (z.HasValue)
                get.Add("z", z.Value.ToString());

            if (size.HasValue)
                get.Add("size", $"{size.Value.Width},{size.Value.Height}");

            if (scale.HasValue)
                get.Add("scale", $"{FloatToString(scale)},{FloatToString(scale)}");

            if (markers != null)
                get.Add("pt", GetMarkers(markers));

            if (lines != null)
                get.Add("pl", string.Join<Line>("~", lines));

            if (polygons != null)
                get.Add("pl", string.Join<Polygon>("~", polygons));

            if (lang != null)
                get.Add("lang", lang.lang);

            /*
             * Вариант из Web.GetData(string, NameValueCollection) чем то ему не угодил, возможно из-за '1.x'
             */

            using (WebClient client = Web.CreateClient())
            {
                string args = "?";

                foreach (KeyValuePair<string, string> k in get)
                    args += $"{k.Key}={k.Value}&";

                return ByteToImage(client.DownloadData($"{Const.StaticMapsAPI}{args}"));
            }
        }

        string GetMarkers(Marker[] markers)
        {
            int count = markers.Length;
            string arg = "";

            for (int i = 0; i < count; i++)
            {
                Marker current = markers[i];

                arg += $"{current.Point},{current.Style}";

                if (current.Color != null)
                    arg += current.Color;

                if (current.ChangeSize)
                    if (current.Size.HasValue)
                        arg += current.Size.Value.ToString().ToLower();
                    else throw new ArgumentException("marker size");

                if (current.ChangeContent)
                    if (current.Content.HasValue)
                        arg += current.Content.Value.ToString();

                if (i + 1 < count) arg += "~";
            }

            return arg;
        }

        Image ByteToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
                return Image.FromStream(ms);
        }
    }
}
