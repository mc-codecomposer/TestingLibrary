using Unit.Tests;

namespace Zdanie
{
    class RevertedNumberAssertions
    {
        public readonly int Argument;

        public RevertedNumberAssertions(int argument)
        {
            Argument = argument;
        }

        public void Eq(int comparedValue)
        {
            if (Argument == comparedValue) throw new ExpectationFailedException();
        }
    }
}
