using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Music3.Helper
{
    public static class IsNullOrEmptyExtension
    {
        public static bool IsNullOrEmpty <T>(this IEnumerable<T> source)
        {
            if(source != null)
            {
                return !source.Any();
            }

            return true;
        }
    }
}
