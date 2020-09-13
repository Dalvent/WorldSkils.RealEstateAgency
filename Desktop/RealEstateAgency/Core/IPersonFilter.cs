using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public interface IPersonFilter
    {
        IList<IPersonInfo> GetFilteredPersonInfos(string pattern);
    }
}
