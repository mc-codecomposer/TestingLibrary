using System;
using System.Collections.Generic;
using System.Text;

namespace Zdanie.TestingLibrary.ErrorsTesting
{
    static class ErrorExtensions
    {
        public static ErrorsAssertions Expect(this Action action)
        {
            return new ErrorsAssertions(action);
        }
    }
}
