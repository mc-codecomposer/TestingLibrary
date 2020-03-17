using System;
using System.Collections.Generic;
using System.Text;

namespace Zdanie.TestingLibrary.NumbersTesting
{
    static class NumberExtensions
    {
        public static NumberAssertions Expect(this int arg)
        {
            return new NumberAssertions(arg);
        }

        public static RevertedNumberAssertions Not(this NumberAssertions assertions)
        {
            return new RevertedNumberAssertions(assertions.Argument);
        }
    }
}
