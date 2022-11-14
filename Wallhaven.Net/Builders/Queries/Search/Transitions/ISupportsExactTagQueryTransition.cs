namespace Wallhaven.Net.Builders.Queries.Search.Transitions;

public interface ISupportsExactTagQueryTransition
{
    IExactTagQueryBuilder AsExactTagQuery();
}
