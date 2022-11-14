namespace Wallhaven.Net.Builders.Queries.Search;

public interface ITagSearchQueryBuilder : ISearchQueryBuilder<ITagSearchQueryBuilder>
{
    IReadOnlySet<string> Keywords { get; }
    IReadOnlySet<string> IncludeTags { get; }
    IReadOnlySet<string> ExcludeTags { get; }

    ITagSearchQueryBuilder WithKeyword(string keyword, bool append = false);

    ITagSearchQueryBuilder WithKeywords(string keyword1, string keyword2, bool append = false);

    ITagSearchQueryBuilder WithKeywords(
        string keyword1,
        string keyword2,
        string keyword3,
        bool append = false
    );

    // Assumes append=false
    ITagSearchQueryBuilder WithKeywords(params string[] keywords);

    ITagSearchQueryBuilder MustInclude(string tag, bool append = false);

    ITagSearchQueryBuilder MustInclude(string tag1, string tag2, bool append = false);

    ITagSearchQueryBuilder MustInclude(
        string tag1,
        string tag2,
        string tag3,
        bool append = false
    );

    ITagSearchQueryBuilder MustInclude(params string[] tags);

    ITagSearchQueryBuilder MustExclude(string tag, bool append = false);

    ITagSearchQueryBuilder MustExclude(string tag1, string tag2, bool append = false);

    ITagSearchQueryBuilder MustExclude(
        string tag1,
        string tag2,
        string tag3,
        bool append = false
    );

    ITagSearchQueryBuilder MustExclude(params string[] tags);
}
