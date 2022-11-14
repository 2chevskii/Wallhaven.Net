using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting;

public class BasicSortingBuilder : IBasicSortingBuilder
{
    public QuerySortingOrder Order { get; init; }
    public QuerySortingMode Mode { get; init; }

    internal BasicSortingBuilder()
    {
        Mode  = QuerySortingMode.UploadDate;
        Order = QuerySortingOrder.Descending;
    }

    private BasicSortingBuilder(BasicSortingBuilder source)
    {
        Order = source.Order;
        Mode  = source.Mode;
    }

    public IRandomSortingBuilder Random() => new RandomSortingBuilder( this );

    public IToplistSortingBuilder Top() => new ToplistSortingBuilder( this );

    public IBasicSortingBuilder UploadDate() =>
    new BasicSortingBuilder( this ) {
        Mode = QuerySortingMode.UploadDate
    };

    public IBasicSortingBuilder Relevance() =>
    new BasicSortingBuilder( this ) {
        Mode = QuerySortingMode.Relevance
    };

    public IBasicSortingBuilder Views() =>
    new BasicSortingBuilder( this ) {
        Mode = QuerySortingMode.Views
    };

    public IBasicSortingBuilder Favorites() =>
    new BasicSortingBuilder( this ) {
        Mode = QuerySortingMode.Favorites
    };

    public IBasicSortingBuilder Hot() =>
    new BasicSortingBuilder( this ) {
        Mode = QuerySortingMode.Hot
    };

    public IBasicSortingBuilder WithSortOrder(QuerySortingOrder order)
    {
        return new BasicSortingBuilder( this ) {
            Order = order
        };
    }

    public ISortingOrderBuilder<IBasicSortingBuilder> OrderBy()
    {
        return new UniversalSortingOrderBuilder<IBasicSortingBuilder>( WithSortOrder );
    }
}
