﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstateAgency
{
    public interface IPersonInfo
    {
        string FirstName { get; }
        string LastName { get; }
        string MiddleName { get; }
    }
}