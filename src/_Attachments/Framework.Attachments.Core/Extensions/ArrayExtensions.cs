using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;

namespace Framework.Attachments.Core.Extensions;

public static class ArrayExtensions
{
    public static Type GetElementType(this Array array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));

        return array.GetType().GetElementType();
    }

    public static MemoryStream ToMemoryStream([NotNull] this byte[] source)
    {
        if (source == null) throw new ArgumentNullException(nameof(source));

        return new MemoryStream(source);
    }
}
