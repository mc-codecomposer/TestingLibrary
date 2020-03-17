using System;

namespace Zdanie
{
    class ObjectAssertions
    {
        private readonly object _argument;

        public ObjectAssertions(object argument)
        {
            _argument = argument;
        }

        public PropertiesComparer Properties()
        {
            return new PropertiesComparer(new Properties(_argument));
        }

        public PropertiesComparer PropertiesWithout(Func<dynamic,dynamic> func)
        {
            var propertyValue = func(_argument);
            Properties properties = new Properties(_argument);
            properties.ExcludeByValue(propertyValue);
            return new PropertiesComparer(properties);
        }

        public PropertiesComparer PropertiesWithout(string propertyName)
        {
            var properties = new Properties(_argument);
            properties.ExcludeByName(propertyName);
            return new PropertiesComparer(properties);
        }
    }
}
