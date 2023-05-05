using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Core;

namespace Framework.Attachments.Core.Extensions;

public static class CoreObjectExtensions
{
    public static Dictionary<string, object> ToPropertyDictionary(
            this object source,
            Func<string, string> propertyNameSelector = null)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        var request = from property in source.GetType().GetProperties()
                      where !property.GetIndexParameters().Any()
                      let name = propertyNameSelector == null ? property.Name : propertyNameSelector(property.Name)
                      select name.ToKeyValuePair(property.GetValue(source, Array.Empty<object>()));

        return request.ToDictionary();
    }

    public static KeyValuePair<TKey, TValue> ToKeyValuePair<TKey, TValue>(this TKey key, TValue value)
    {
        return new KeyValuePair<TKey, TValue>(key, value);
    }
}
