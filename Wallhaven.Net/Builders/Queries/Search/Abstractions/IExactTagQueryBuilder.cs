namespace Wallhaven.Net.Builders.Queries.Search;

public interface IExactTagQueryBuilder : ISearchQueryBuilder<IExactTagQueryBuilder>
{
    IExactTagQueryBuilder WithTag(int tagId);
}
