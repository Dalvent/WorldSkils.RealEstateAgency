using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public enum EstleType
    {
        None = 0,
        Flat,
        House,
        LandPlot
    }

    public static class EstleTypeConverter
    {
        public static string ToString(EstleType estleType)
        {
            switch(estleType)
            {
            case EstleType.Flat:     return "Квартира";
            case EstleType.House:    return "Дом";
            case EstleType.LandPlot: return "Участок";
            default:                 return "Неизвестный тип";
            }
        }
    }
}
