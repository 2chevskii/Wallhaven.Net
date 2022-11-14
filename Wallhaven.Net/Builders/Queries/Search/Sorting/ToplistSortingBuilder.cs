using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting;

public class ToplistSortingBuilder : IToplistSortingBuilder
{
    public QuerySortingOrder Order { get; init; }
    public QuerySortingMode Mode => QuerySortingMode.TopList;
    public TopListRange Range { get; init; }

    internal ToplistSortingBuilder(BasicSortingBuilder source)
    {
        Order = source.Order;
        Range = TopListRange.Month;
    }

    private ToplistSortingBuilder(ToplistSortingBuilder source)
    {
        Order = source.Order;
        Range = source.Range;
    }

    public IToplistSortingBuilder WithRange(TopListRange range) =>
    new ToplistSortingBuilder( this ) {
        Range = range
    };

    public IToplistSortingBuilder WithSortOrder(QuerySortingOrder order) =>
    new ToplistSortingBuilder( this ) {
        Order = order
    };

    public ISortingOrderBuilder<IToplistSortingBuilder> OrderBy() =>
    new UniversalSortingOrderBuilder<IToplistSortingBuilder>( WithSortOrder );

}
