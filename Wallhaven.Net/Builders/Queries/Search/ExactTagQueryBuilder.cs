using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search;

public class ExactTagQueryBuilder : IExactTagQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public int TagId { get; init; }

    internal ExactTagQueryBuilder(IInitialSearchQueryBuilder source)
    {
        Uploader = source.Uploader;
        FileType = source.FileType;
        TagId    = 0;
    }

    private ExactTagQueryBuilder(ExactTagQueryBuilder source)
    {
        Uploader = source.Uploader;
        FileType = source.FileType;
        TagId    = source.TagId;
    }

    public IExactTagQueryBuilder WithUploader(string uploaderUsername) =>
    new ExactTagQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public IExactTagQueryBuilder WithFileType(FileType fileType) =>
    new ExactTagQueryBuilder( this ) {
        FileType = fileType
    };

    public IExactTagQueryBuilder WithTag(int tagId) =>
    new ExactTagQueryBuilder( this ) {
        TagId = tagId
    };
}
