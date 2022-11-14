#define JETBRAINS_ANNOTATIONS

using JetBrains.Annotations;

namespace Wallhaven.Net.Extensions;

public static class NullabilityExtensions
{
    [ContractAnnotation("null => false")]
    public static bool IsNotNull<T>(this T? obj) where T : class
    {
        return obj is not null;
    }

    public static bool IsNotNull<T>(this T? self) where T : struct
    {
        return self.HasValue;
    }
}
