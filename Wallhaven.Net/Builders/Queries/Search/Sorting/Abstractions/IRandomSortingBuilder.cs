namespace Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;

public interface IRandomSortingBuilder : ISortingBuilder<IRandomSortingBuilder>
{
    // string Seed { get; }
    IRandomSortingBuilder WithSeed(string seed);
}
