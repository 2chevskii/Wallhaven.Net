using System.Runtime.CompilerServices;

namespace Wallhaven.Net.Builders.Queries.Flags;

public class FlagsBuilder<T> where T : Enum
{
    private T _flags;

    public T Value => _flags;

    public FlagsBuilder(T value) { _flags = value; }

    public FlagsBuilder<T> Include(T value)
    {
        var flags = _flags;
        Unsafe.As<T, int>( ref flags ) |= Unsafe.As<T, int>( ref value );

        return new FlagsBuilder<T>( flags );
    }

    public FlagsBuilder<T> Exclude(T value)
    {
        var flags = _flags;
        Unsafe.As<T, int>( ref flags ) &= ~Unsafe.As<T, int>( ref value );

        return new FlagsBuilder<T>( flags );
    }
}
