using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search;

public class InitialSearchQueryBuilder : IInitialSearchQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }

    internal InitialSearchQueryBuilder()
    {
        Uploader = string.Empty;
        FileType         = FileType.Unspecified;
    }

    /*Copy constructor*/
    protected InitialSearchQueryBuilder(InitialSearchQueryBuilder source)
    {
        Uploader = source.Uploader;
        FileType         = source.FileType;
    }

    public IInitialSearchQueryBuilder WithUploader(string username)
    {
        return new InitialSearchQueryBuilder( this ) {
            Uploader = username
        };
    }

    public IInitialSearchQueryBuilder WithFileType(FileType fileType)
    {
        return new InitialSearchQueryBuilder( this ) {
            FileType = fileType
        };
    }

    public IExactTagQueryBuilder AsExactTagQuery() => new ExactTagQueryBuilder(this);

    public ITagSearchQueryBuilder AsTagSearchQuery() => new TagSearchQueryBuilder(this);

    public ISimilarToQueryBuilder AsSimilarToQuery() => new SimilarToQueryBuilder(this);
}
