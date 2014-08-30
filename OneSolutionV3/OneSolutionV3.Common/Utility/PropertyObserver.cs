using System;
using System.Linq.Expressions;

namespace OneSolutionV3.Common.Utility
{
    public static class PropertyObserver
    {
        public static string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            return (((MemberExpression)(expression.Body)).Member).Name;
        }
    }
}
