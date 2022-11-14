using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;

public interface IToplistSortingBuilder : ISortingBuilder<IToplistSortingBuilder>
{
    // TopListRange Range { get; }

    IToplistSortingBuilder WithRange(TopListRange range);
}
