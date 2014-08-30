using System;
using System.Collections.Generic;
using OneSolutionV3.Common.MobileData.Interface;
using OneSolutionV3.Common.Model;

namespace OneSolutionV3.Common.MobileData.Implementation
{
    public class OneSolution : IMobileData
    {

        public List<ImportTransaction> ReadContent(string fullName, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
