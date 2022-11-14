namespace Wallhaven.Net.Builders.Queries.Search.Transitions;

public interface ISupportsTagSearchQueryTransition
{
    ITagSearchQueryBuilder AsTagSearchQuery();
}