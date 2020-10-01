using RealEstateAgency.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency.Core
{
    /// <summary>
    /// Фильтрация с помощью координат региона.
    /// </summary>
    class RegionFilter : ICollectionFilter
    {
        private Dictionary<string, Region> regionDictionary;
        public RegionFilter(IEnumerable<Region> regions)
        {
            regionDictionary = new Dictionary<string, Region>();
            foreach(var region in regions)
            {
                regionDictionary.Add(region.Name, region);
            }
        }
        public IEnumerable UseFilter(IEnumerable collection, string pattern)
        {
            if(!regionDictionary.ContainsKey(pattern))
                throw new Exception("Unown region");

            var polygon = regionDictionary[pattern].Polygon;
            var filterItems = new List<Estate>();
            foreach(var item in collection)
            {
                var itemEstle = item as Estate;
                if(itemEstle == null || 
                    !(itemEstle.CoordinateLatitude.HasValue 
                    && itemEstle.CoordinateLongitude.HasValue)) 
                    continue;

                if(IsPointIn(polygon, new PointF(
                    itemEstle.CoordinateLatitude.Value, 
                    itemEstle.CoordinateLongitude.Value)))
                {
                    filterItems.Add(itemEstle);
                }
            }
            return filterItems;
        }

        public bool IsPointIn(PointF[] points, PointF point)
        {
            var coef = points.Skip(1).Select((p, i) =>
            {
                return (point.Y - points[i].Y) * (p.X - points[i].X) -
                    (point.X - points[i].X) * (p.Y - points[i].Y);
            }
            ).ToList();

            if(coef.Any(p => p == 0))
                return true;

            for(int i = 1; i < coef.Count(); i++)
            {
                if(coef[i] * coef[i - 1] < 0)
                    return false;
            }
            return true;
        }
    }
}
