using System;
using System.Collections.Generic;
using System.Text;

namespace Zdanie.TestingLibrary.ObjectsTesting
{
    static class ObjectExtensions
    {

        public static ObjectAssertions Expect<T>(this T obj) where T : class
        {
            return new ObjectAssertions(obj);
        }
    }
}
