using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using YandexAPI.StaticMapsAPI.Enums;
using YandexAPI.StaticMapsAPI.Markers;
using YandexAPI.WebHelper;

using static YandexAPI.StaticMapsAPI.Enums.FloatHelper;

namespace YandexAPI.StaticMapsAPI
{
    /// <summary>
    /// Набор операция для получения изображения с Yandex Maps (LINQ Style).
    /// </summary>
    public class CreateMap
    {
        /// <summary>
        /// Стандартный размер получаемого изображения карты.
        /// </summary>
        public static readonly Size DefaultImageSize = new Size(450, 450);

        #region vars
        MapType types = null;
        MapPoint mapCenter = null;
        float? spn = null;
        Bbox bbox = null;
        byte? z = null;
        Size? size = null;
        float? scale = null;
        List<Marker> markers = new List<Marker>();
        List<Line> lines = new List<Line>();
        List<Polygon> polygons = new List<Polygon>();
        Enums.Langs lang = null;
        #endregion

        /// <summary>
        /// Получить заданное изображение.
        /// </summary>
        /// <returns></returns>
        public Image DownloadImage()
        {
            Dictionary<string, string> get = new Dictionary<string, string>
            {
                ["l"] = types.ToString()
            };

            if (mapCenter != null)
                get.Add("ll", mapCenter.ToString());

            if (bbox != null)
                get.Add("bbox", bbox.ToString());

            if (spn.HasValue)
                get.Add("spn", $"{FloatToString(spn)},{FloatToString(spn)}");

            if (z.HasValue)
                get.Add("z", z.Value.ToString());

            if (size.HasValue)
                get.Add("size", $"{size.Value.Width},{size.Value.Height}");

            if (scale.HasValue)
                get.Add("scale", $"{FloatToString(scale)},{FloatToString(scale)}");

            if (markers != null)
                get.Add("pt", GetMarkers(markers));

            if (lines.Count > 0 || polygons.Count > 0)
                get.Add("pl", string.Join("~", lines.Concat(polygons)));

            if (lang != null)
                get.Add("lang", lang.Lang);

            /*
             * Вариант из Web.GetData чем то ему не угодил, возможно из-за '1.x'
             */
            using (var client = Web.CreateClient())
            {
                string args = "?";

                foreach (var k in get)
                    args += $"{k.Key}={k.Value}&";

                return ByteToImage(client.DownloadData($"{Consts.StaticMapsAPI}{args}"));
            }
        }

        /// <summary>
        /// Установить язык карты.
        /// </summary>
        /// <param name="lang">Язык карты.</param>
        /// <returns></returns>
        public CreateMap SetLang(Enums.Langs lang)
        {
            this.lang = lang;
            return this;
        }

        /// <summary>
        /// Добавить многоугольник на карту.
        /// </summary>
        /// <param name="polygon">Многоугольник.</param>
        /// <returns></returns>
        public CreateMap AddPolygon(Polygon polygon)
        {
            if (!polygons.Contains(polygon))
                polygons.Add(polygon);

            return this;
        }

        /// <summary>
        /// Добавить линию на карту.
        /// </summary>
        /// <param name="line">Линия.</param>
        /// <returns></returns>
        public CreateMap AddLine(Line line)
        {
            if (!lines.Contains(line))
                lines.Add(line);

            return this;
        }

        /// <summary>
        /// Добавить маркер на карту.
        /// </summary>
        /// <param name="marker">Маркер.</param>
        /// <returns></returns>
        public CreateMap AddMarker(Marker marker)
        {
            if (!markers.Contains(marker))
                markers.Add(marker);

            return this;
        }

        /// <summary>
        /// Установить коэффициент увеличения объектов на карте.
        /// </summary>
        /// <param name="scale">Коэффициент увеличения объектов на карте (от 1.0 до 4.0).</param>
        /// <returns></returns>
        public CreateMap SetScale(float? scale)
        {
            if (scale.HasValue)
                if (scale.Value < 1.0f || scale.Value > 4.0f)
                    throw new ArgumentException("scale");

            this.scale = scale;

            return this;
        }

        /// <summary>
        /// Установить ширину и высоту запрашиваемого изображения карты (в пикселах).
        /// </summary>
        /// <param name="size">Ширина и высота запрашиваемого изображения карты (в пикселах).</param>
        /// <returns></returns>
        public CreateMap SetSize(Size? size)
        {
            if (size.HasValue)
                if (size.Value.Height < 0 || size.Value.Height > 450 ||
                    size.Value.Width < 0 || size.Value.Width > 650)
                    throw new ArgumentException("size");

            this.size = size ?? DefaultImageSize;
            return this;
        }

        /// <summary>
        /// Установить уровень масштабирования карты (0-17).
        /// </summary>
        /// <param name="z">Уровень масштабирования карты (0-17).</param>
        /// <returns></returns>
        public CreateMap SetZoom(byte? z = null)
        {
            if (z.Value < 0 || z.Value > 17)
                throw new ArgumentException("z");

            this.z = z;
            return this;
        }

        /// <summary>
        /// Установить географические координаты углов прямоугольника, ограничивающего область просмотра.
        /// </summary>
        /// <param name="bbox">Географические координаты углов прямоугольника, ограничивающего область просмотра.</param>
        /// <returns></returns>
        public CreateMap SetBbox(Bbox bbox)
        {
            this.bbox = bbox;
            return this;
        }

        /// <summary>
        /// Установить тип карты.
        /// </summary>
        /// <param name="type">Тип карты.</param>
        /// <returns></returns>
        public CreateMap SetMapTypes(MapType type)
        {
            types = type ?? throw new ArgumentException("type");
            return this;
        }

        /// <summary>
        /// Установить центр карты.
        /// </summary>
        /// <param name="center">Центр карты.</param>
        /// <returns></returns>
        public CreateMap SetMapCenter(MapPoint center)
        {
            mapCenter = center;
            return this;
        }

        /// <summary>
        /// Установить протяженность области показа карты по долготе и широте (в градусах).
        /// </summary>
        /// <param name="spn">Протяженность области показа карты по долготе и широте (в градусах).</param>
        /// <returns></returns>
        public CreateMap SetSPN(float? spn)
        {
            this.spn = spn;
            return this;
        }

        static string GetMarkers(List<Marker> markers)
        {
            int count = markers.Count;
            string arg = "";

            for (int i = 0; i < count; i++)
            {
                Marker current = markers[i];

                arg += $"{current.Point},{current.Style}";

                if (current.Color != null)
                    arg += current.Color;

                if (current.CanResize)
                    if (current.Size.HasValue)
                        arg += current.Size.Value.ToString().ToLower();
                    else throw new ArgumentException("marker size");

                if (current.CanChangeContent)
                    if (current.Content.HasValue)
                        arg += current.Content.Value.ToString();

                if (i + 1 < count) arg += "~";
            }

            return arg;
        }

        static Image ByteToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
                return Image.FromStream(ms);
        }
    }
}
