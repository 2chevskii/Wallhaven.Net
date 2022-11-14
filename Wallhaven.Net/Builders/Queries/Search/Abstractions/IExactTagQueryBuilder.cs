namespace Wallhaven.Net.Builders.Queries.Search.Abstractions;

public interface IExactTagQueryBuilder : ISearchQueryBuilder<IExactTagQueryBuilder>
{
    IExactTagQueryBuilder WithTag(int tagId);
}
