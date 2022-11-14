namespace Wallhaven.Net.Builders.Queries.Search.Abstractions.Transitions;

public interface ISupportsTagSearchQueryTransition
{
    ITagSearchQueryBuilder AsTagSearchQuery();
}