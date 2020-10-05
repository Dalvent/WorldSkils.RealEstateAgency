using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace RealEstateAgency
{
    /// <summary>
    /// Представляет регион с именем и границами.
    /// </summary>
    public class Region
    {
        public Region(string name, PointF[] polygon)
        {
            Name = name;
            Polygon = polygon;
        }
        public string Name { get; private set; }
        public PointF[] Polygon { get; private set; }

        /// <summary>
        /// Получение информации о регионах из файла.
        /// Возращает словарь, где ключ имя региона.
        /// </summary>
        public static Region[] LoadFileData(string filePath, Encoding encoding)
        {
            var regions = new List<Region>();
            using(var reader = new StreamReader(filePath, encoding))
            {
                reader.ReadLine();
                while(!reader.EndOfStream)
                {
                    var lineInfo = reader.ReadLine().Split(new string[] { ";\"" }, StringSplitOptions.None);
                    regions.Add(new Region(lineInfo[0], GetPointFromString(lineInfo[1])));
                }
            }
            return regions.ToArray();
        }

        private static PointF[] GetPointFromString(string pointsLineInfo)
        {
            var pointsInfos = pointsLineInfo.Substring(1, pointsLineInfo.Length - 2)
                .Split('(', ')').Where(item => item != ";" && item != String.Empty).ToArray();
            var points = new PointF[pointsInfos.Length];

            for(int i = 0; i < points.Length; i++)
            {
                var valueInfos = pointsInfos[i].Split(';');

                points[i] = new PointF
                {
                    X = Convert.ToSingle(valueInfos[0], new CultureInfo("en-US")),
                    Y = Convert.ToSingle(valueInfos[1], new CultureInfo("en-US"))
                };
            }

            return points;
        }
    }
}