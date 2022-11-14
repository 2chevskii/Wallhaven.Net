using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting;

public class RandomSortingBuilder : IRandomSortingBuilder
{

    public QuerySortingOrder Order { get; init; }
    public QuerySortingMode Mode => QuerySortingMode.Random;
    public string Seed { get; init; }

    internal RandomSortingBuilder(BasicSortingBuilder source)
    {
        Order = source.Order;
        Seed  = string.Empty;
    }

    private RandomSortingBuilder(RandomSortingBuilder source)
    {
        Order = source.Order;
        Seed  = source.Seed;
    }

    public IRandomSortingBuilder WithSortOrder(QuerySortingOrder order) =>
    new RandomSortingBuilder( this ) {
        Order = order
    };

    public ISortingOrderBuilder<IRandomSortingBuilder> OrderBy() =>
    new UniversalSortingOrderBuilder<IRandomSortingBuilder>( WithSortOrder );

    public IRandomSortingBuilder WithSeed(string seed) =>
    new RandomSortingBuilder( this ) {
        Seed = seed
    };
}
