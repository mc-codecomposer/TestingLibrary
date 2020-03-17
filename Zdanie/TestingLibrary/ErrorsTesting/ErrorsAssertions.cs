using System;
using Unit.Tests;

namespace Zdanie
{
    class ErrorsAssertions
    {
        private readonly Action _action;

        public ErrorsAssertions(Action action)
        {
            _action = action;
        }

        public void RaiseError()
        {
            try
            {
                _action();
            }
            catch (Exception)
            {
                return;
            }

            throw new ExpectationFailedException();
        }

    }
}
