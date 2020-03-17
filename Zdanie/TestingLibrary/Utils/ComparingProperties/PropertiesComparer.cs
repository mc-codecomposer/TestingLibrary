using System;
using System.Collections.Generic;
using System.Linq;
using Unit.Tests;

namespace Zdanie
{
    class PropertiesComparer
    {

        private readonly Properties _argumentProperties;


        public PropertiesComparer(Properties properties)
        {
             _argumentProperties = properties;
        }

        public void Eq(object compared)
        {
            var comparedProperties = new Properties(compared);
            if (!comparedProperties.ContainsAllNames(_argumentProperties.Names)) throw new ExpectationFailedException();

            foreach (var property in _argumentProperties.PropertiesInfos)
            {
                var searchedName = property.Name;
                var searchedType = _argumentProperties.FindTypeByPropertyName(searchedName);
                var searchedValue = _argumentProperties.FindValueByPropertyName(searchedName);

                if (!comparedProperties.ContainsPropertyWithValue(
                    searchedName,
                    searchedType,
                    searchedValue
                    )
                    ) throw new ExpectationFailedException();
            }
        }

        private void ComparePropertiesLists(IEnumerable<string> argNames, IEnumerable<string> comparedNames)
        {
            if (argNames.Any(name => !comparedNames.Contains(name))) throw new ExpectationFailedException();
        }

    }
}
