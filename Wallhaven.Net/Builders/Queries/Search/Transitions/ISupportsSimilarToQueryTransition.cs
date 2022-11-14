namespace Wallhaven.Net.Builders.Queries.Search.Transitions;

public interface ISupportsSimilarToQueryTransition
{
    ISimilarToQueryBuilder AsSimilarToQuery();
}