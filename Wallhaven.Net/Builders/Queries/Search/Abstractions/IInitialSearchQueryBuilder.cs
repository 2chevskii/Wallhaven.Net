using Wallhaven.Net.Builders.Queries.Search.Transitions;

namespace Wallhaven.Net.Builders.Queries.Search;

public interface IInitialSearchQueryBuilder : ISearchQueryBuilder<IInitialSearchQueryBuilder>,
                                              ISupportsExactTagQueryTransition,
                                              ISupportsTagSearchQueryTransition,
                                              ISupportsSimilarToQueryTransition { }
