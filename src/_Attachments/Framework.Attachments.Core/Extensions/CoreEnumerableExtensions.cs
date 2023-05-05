using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Core;

namespace Framework.Attachments.Core.Extensions;

public static class CoreEnumerableExtensions
{
    public static bool HasDuplicates<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer = null)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return source.GetDuplicates(comparer).Any();
    }
}
