namespace Wallhaven.Net.Builders.Queries.Search;

public interface ISimilarToQueryBuilder : ISearchQueryBuilder<ISimilarToQueryBuilder>
{
    string WallpaperId { get; }

    ISimilarToQueryBuilder WithSimilarWallpaperId(string wallpaperId);
}
