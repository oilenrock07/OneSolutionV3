using System;
using System.Collections.Generic;
using OneSolutionV3.Common.Model;

namespace OneSolutionV3.Common.MobileData.Interface
{
    public interface IMobileData
    {
        List<ImportTransaction> ReadContent(string fullName, DateTime  startDate, DateTime  endDate);
    }
}
