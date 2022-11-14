using System.Runtime.CompilerServices;

namespace Wallhaven.Net.Builders.Queries.Flags;

public static partial class FlagsBuilderExtensions
{
    public static FlagsBuilder<T> Include<T>(this FlagsBuilder<T> self, params T[] values)
    where T : Enum
    {
        return self.Include( values.BOr() );
    }

    public static FlagsBuilder<T> Exclude<T>(this FlagsBuilder<T> self, params T[] values)
    where T : Enum
    {
        return self.Exclude( values.BOr() );
    }

    public static T BOr<T>(this IEnumerable<T> self) where T : Enum
    {
        return self.Aggregate(
            (a, b) => {
                var result = Unsafe.As<T, int>( ref a ) | Unsafe.As<T, int>( ref b );

                return Unsafe.As<int, T>( ref result );
            }
        );
    }
}
