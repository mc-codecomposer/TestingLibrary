using Unit.Tests;

namespace Zdanie
{
    class NumberAssertions
    {
        public readonly int Argument;

        public NumberAssertions(int argument)
        {
            Argument = argument;
        }

        public void Eq(int comparedValue)
        {
            if (Argument != comparedValue) throw new ExpectationFailedException();
        }

        public void IsGreater(int comparedValue)
        {
            if (Argument < comparedValue) throw new ExpectationFailedException();
        }

    }
}
