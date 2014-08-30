using System.Collections.Generic;

namespace OneSolutionV3.Common.Comparer
{
    public class StringCaseComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return x.ToLower().Equals(y.ToLower());
        }

        public int GetHashCode(string obj)
        {
            obj = obj.ToLower();
            return obj.GetHashCode();
        }
    }
}
