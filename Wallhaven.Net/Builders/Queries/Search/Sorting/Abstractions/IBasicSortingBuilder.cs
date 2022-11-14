using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions.Transitions;

namespace Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;

public interface IBasicSortingBuilder : ISortingBuilder<IBasicSortingBuilder>,
                                        ISupportsRandomTransition,
                                        ISupportsToplistTransition
{
    IBasicSortingBuilder UploadDate();

    IBasicSortingBuilder Relevance();

    IBasicSortingBuilder Views();

    IBasicSortingBuilder Favorites();

    IBasicSortingBuilder Hot();
}
