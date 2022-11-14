using Wallhaven.Net.Builders.Queries.Search.Abstractions.Transitions;

namespace Wallhaven.Net.Builders.Queries.Search.Abstractions;

public interface IInitialSearchQueryBuilder : ISearchQueryBuilder<IInitialSearchQueryBuilder>,
                                              ISupportsExactTagQueryTransition,
                                              ISupportsTagSearchQueryTransition,
                                              ISupportsSimilarToQueryTransition { }
