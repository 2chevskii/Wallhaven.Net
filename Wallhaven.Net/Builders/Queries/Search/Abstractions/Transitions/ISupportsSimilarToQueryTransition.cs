namespace Wallhaven.Net.Builders.Queries.Search.Abstractions.Transitions;

public interface ISupportsSimilarToQueryTransition
{
    ISimilarToQueryBuilder AsSimilarToQuery();
}