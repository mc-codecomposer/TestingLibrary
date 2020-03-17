using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Zdanie
{
    class Properties
    { 
        public PropertyInfo[] PropertiesInfos { get; private set; }
        public readonly IEnumerable<string> Names;
        private readonly object _object;

        public Properties(object obj)
        {
            PropertiesInfos = obj.GetType().GetProperties();
            Names = PropertiesInfos.Select(p => p.Name).ToList();
            _object = obj;
        }

        public void ExcludeByValue(dynamic value)
        {
            var excludedProperty = PropertiesInfos.FirstOrDefault(p => p.GetValue(_object) == value);
            if (excludedProperty == null) return;
            PropertiesInfos = PropertiesInfos.Where(p => p != excludedProperty).ToArray();
        }

        public void ExcludeByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return;
            PropertiesInfos = PropertiesInfos.Where(p => p.Name != name).ToArray();
        }

        public bool ContainsAllNames(IEnumerable<string> propertiesNames)
        {
            if (propertiesNames == null) throw new ArgumentException("properties names list is null");
            if (!propertiesNames.Any()) return true;
            return propertiesNames.All(n => Names.Contains(n));
        }

        public object FindValueByPropertyName(string name)
        {
            var prop = FindProperty(name);
            return prop.GetValue(_object);
        }

        public Type FindTypeByPropertyName(string name)
        {
            var prop = FindProperty(name);
            return prop.PropertyType;
        }

        public bool ContainsPropertyWithValue(string name, Type type, object value)
        {
            var property = PropertiesInfos.FirstOrDefault(p => p.Name == name && p.PropertyType == type);
            if (property == null) return false;
            return Convert.ChangeType(value, type) == Convert.ChangeType(property.GetValue(_object), type);
        }

        private PropertyInfo FindProperty(string name)
        {
            var prop = PropertiesInfos.FirstOrDefault(p => p.Name == name);
            if (prop == null) throw new ArgumentException("proprety with given name not found");
            return prop;
        }
    }
}
