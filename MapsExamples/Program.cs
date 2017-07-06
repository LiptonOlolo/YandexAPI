using System;
using System.Drawing;
using System.Drawing.Imaging;
using YandexAPI.StaticMapsAPI;

namespace MapsExamples
{
    class Program
    {
        static YandexStaticMapAPI mapApi = new YandexStaticMapAPI();

        static void Main(string[] args)
        {
            MapType[] type = new[] { MapType.Map, MapType.Trf };
            MapPoint center = new MapPoint(37.62007f, 55.75363f);
            float spn = 0.1f;

            Image img1 = mapApi.GetMap(type, mapCenter: center, spn: spn);
            img1.Save("map1.png", ImageFormat.Png);

            Image img2 = mapApi.GetMap(type, center, z: 13);
            img2.Save("map2.png", ImageFormat.Png);


            Marker marker1 = Marker_Vector.Yandex;
            marker1.Point = center;

            Marker marker2 = Marker_PM2.Rd;
            marker2.Point = new MapPoint(37.65f, 55.753f);
            marker2.Size = MarkerSize.L;
            marker2.Content = 19;

            Image img3 = mapApi.GetMap(type, mapCenter: center, markers: new[] { marker1, marker2 });
            img3.Save("map3.png", ImageFormat.Png);

            Line mapLine = new Line(5, Color.Cyan, new MapPoint[]
            {
                new MapPoint(37.656577f, 55.741176f),
                new MapPoint(37.656748f, 55.741419f),
                new MapPoint(37.655131f, 55.741814f),
                new MapPoint(37.658257f, 55.742524f),
                new MapPoint(37.659811f, 55.743066f),
                new MapPoint(37.659667f, 55.743233f),
                new MapPoint(37.659551f, 55.743603f),
                new MapPoint(37.659775f, 55.743928f),
                new MapPoint(37.662398f, 55.745281f)
            });

            Image img4 = mapApi.GetMap(type, lines: new[] { mapLine });
            img4.Save("map4.png", ImageFormat.Png);

            Polygon polygon = new Polygon(5, Color.Cyan, Color.Crimson, new MapPoint[]
            {
                new MapPoint(30.310514f, 59.948631f),
                new MapPoint(30.311080f, 59.949172f),
                new MapPoint(30.310290f, 59.949842f),
                new MapPoint(30.313011f, 59.950460f),
                new MapPoint(30.312688f, 59.950275f),
                new MapPoint(30.313029f, 59.950135f),
                new MapPoint(30.315015f, 59.951091f),
                new MapPoint(30.314871f, 59.951235f),
                new MapPoint(30.314637f, 59.951199f),
                new MapPoint(30.314601f, 59.951248f),
                new MapPoint(30.315625f, 59.952023f),
                new MapPoint(30.316999f, 59.951816f),
                new MapPoint(30.316963f, 59.951744f),
                new MapPoint(30.316649f, 59.951735f),
                new MapPoint(30.316747f, 59.951541f),
                new MapPoint(30.319074f, 59.951519f),
                new MapPoint(30.319173f, 59.951708f),
                new MapPoint(30.318876f, 59.951739f),
                new MapPoint(30.318876f, 59.951812f),
                new MapPoint(30.321482f, 59.952194f),
                new MapPoint(30.321401f, 59.951478f),
                new MapPoint(30.322703f, 59.951181f),
                new MapPoint(30.322101f, 59.950748f),
                new MapPoint(30.322730f, 59.950203f),
                new MapPoint(30.320305f, 59.949604f),
                new MapPoint(30.319775f, 59.949793f),
                new MapPoint(30.318589f, 59.949293f),
                new MapPoint(30.318598f, 59.949248f),
                new MapPoint(30.318463f, 59.949180f),
                new MapPoint(30.318409f, 59.949189f),
                new MapPoint(30.318059f, 59.949049f),
                new MapPoint(30.318436f, 59.948756f),
                new MapPoint(30.317870f, 59.948252f),
                new MapPoint(30.316577f, 59.948346f),
                new MapPoint(30.316415f, 59.948585f),
                new MapPoint(30.313954f, 59.948549f),
                new MapPoint(30.313945f, 59.948351f),
                new MapPoint(30.313864f, 59.948162f),
                new MapPoint(30.311501f, 59.947869f),
                new MapPoint(30.311636f, 59.948527f),
                new MapPoint(30.310514f, 59.948631f)
            });

            Image img5 = mapApi.GetMap(type, polygons: new[] { polygon });
            img5.Save("map5.png", ImageFormat.Png);
        }
    }
}
