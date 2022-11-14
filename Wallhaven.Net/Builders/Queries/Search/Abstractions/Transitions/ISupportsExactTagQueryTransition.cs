namespace Wallhaven.Net.Builders.Queries.Search.Abstractions.Transitions;

public interface ISupportsExactTagQueryTransition
{
    IExactTagQueryBuilder AsExactTagQuery();
}
