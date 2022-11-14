namespace Wallhaven.Net.Builders.Queries.Search.Abstractions;

public interface ITagSearchQueryBuilder : ISearchQueryBuilder<ITagSearchQueryBuilder>
{
    ITagSearchQueryBuilder WithKeyword(string keyword);

    ITagSearchQueryBuilder WithKeywords(string keyword1, string keyword2);

    ITagSearchQueryBuilder WithKeywords(string keyword1, string keyword2, string keyword3);

    // Assumes append=false
    ITagSearchQueryBuilder WithKeywords(params string[] keywords);

    ITagSearchQueryBuilder MustInclude(string tag);

    ITagSearchQueryBuilder MustInclude(string tag1, string tag2);

    ITagSearchQueryBuilder MustInclude(string tag1, string tag2, string tag3);

    ITagSearchQueryBuilder MustInclude(params string[] tags);

    ITagSearchQueryBuilder MustExclude(string tag);

    ITagSearchQueryBuilder MustExclude(string tag1, string tag2);

    ITagSearchQueryBuilder MustExclude(string tag1, string tag2, string tag3);

    ITagSearchQueryBuilder MustExclude(params string[] tags);
}
