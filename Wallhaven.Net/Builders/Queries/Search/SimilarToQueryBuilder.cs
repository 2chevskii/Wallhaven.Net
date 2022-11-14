using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search;

public class SimilarToQueryBuilder : ISimilarToQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public string WallpaperId { get; private init; }

    internal SimilarToQueryBuilder(IInitialSearchQueryBuilder source)
    {
        Uploader    = source.Uploader;
        FileType    = source.FileType;
        WallpaperId = string.Empty;
    }

    private SimilarToQueryBuilder(SimilarToQueryBuilder source)
    {
        Uploader    = source.Uploader;
        FileType    = source.FileType;
        WallpaperId = source.WallpaperId;
    }

    public ISimilarToQueryBuilder WithUploader(string uploaderUsername) =>
    new SimilarToQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public ISimilarToQueryBuilder WithFileType(FileType fileType) =>
    new SimilarToQueryBuilder( this ) {
        FileType = fileType
    };

    public ISimilarToQueryBuilder WithSimilarWallpaperId(string wallpaperId) =>
    new SimilarToQueryBuilder( this ) {
        WallpaperId = wallpaperId
    };
}
