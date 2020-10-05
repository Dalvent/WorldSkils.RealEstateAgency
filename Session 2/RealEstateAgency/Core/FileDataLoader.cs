using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    /// <summary>
    /// Статический класс, загружающий и хранящий необходимые для приложения данные.
    /// </summary>
    public static class ResurceData
    {
        /// <summary>
        /// Загружает и сохраняет данные. 
        /// Необходим для инициализации класса.
        /// </summary>
        /// <param name="resurceFolder"></param>
        public static void Load(string resurceFolder)
        {
            Regions = Region.LoadFileData(resurceFolder + @"\districts.txt", Encoding.UTF8);
        }
        /// <summary>
        /// Информациия о регионах. 
        /// Ключ - название региона.
        /// </summary>
        public static IEnumerable<Region> Regions { get; private set; }

    }
}
