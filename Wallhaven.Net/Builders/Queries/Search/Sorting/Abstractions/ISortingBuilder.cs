using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;

public interface ISortingBuilder<T> where T : ISortingBuilder<T>
{
    /*QuerySortingOrder Order { get; }
    QuerySortingMode Mode { get; }*/

    T WithSortOrder(QuerySortingOrder order);

    ISortingOrderBuilder<T> OrderBy();
}

public interface ISortingOrderBuilder<TSource> where TSource : ISortingBuilder<TSource>
{
    TSource Ascending();

    TSource Descending();
}

public class UniversalSortingOrderBuilder<TSource> : ISortingOrderBuilder<TSource>
where TSource : ISortingBuilder<TSource>
{
    readonly Func<QuerySortingOrder, TSource> _factory;

    /*
     * for the lack of better option (others include implementing sorting order builder
     * for each ISortingOrderBuilder and using Activator)
     * we use the factory delegate
     */
    public UniversalSortingOrderBuilder(Func<QuerySortingOrder, TSource> factory)
    {
        _factory = factory;
    }

    public TSource Ascending() => _factory( QuerySortingOrder.Ascending );

    public TSource Descending() => _factory( QuerySortingOrder.Descending );
}
