using System;

namespace Framework.Attachments.Core.Extensions;

public static class ArrayExtensions
{
    public static Type GetElementType(this Array array)
    {
        if (array == null) throw new ArgumentNullException(nameof(array));

        return array.GetType().GetElementType();
    }
}
