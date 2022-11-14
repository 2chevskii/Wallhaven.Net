namespace Wallhaven.Net.Extensions;

public static class HashSetExtensions
{
    public static void Add<T>(this HashSet<T> self, T item, bool append)
    {
        if ( !append )
            self.Clear();

        self.Add( item );
    }

    public static void AddRange<T>(
        this HashSet<T> self,
        T item1,
        T item2,
        bool append
    )
    {
        if ( !append )
            self.Clear();

        self.Add( item1 );
        self.Add( item2 );
    }

    public static void AddRange<T>(
        this HashSet<T> self,
        T item1,
        T item2,
        T item3,
        bool append
    )
    {
        if ( !append )
            self.Clear();

        self.Add( item1 );
        self.Add( item2 );
        self.Add( item3 );
    }

    /// <summary>
    ///
    /// </summary>
    /// <param name="self"></param>
    /// <param name="append">Indicates whether to append given <see cref="items"/> to <see cref="self"/>, or clear destination before adding</param>
    /// <param name="items"></param>
    /// <typeparam name="T"></typeparam>
    public static void AddRange<T>(this HashSet<T> self, bool append = true, params T[] items)
    {
        if ( !append )
            self.Clear();

        for ( var i = 0; i < items.Length; i++ ) { self.Add( items[i] ); }
    }
}
