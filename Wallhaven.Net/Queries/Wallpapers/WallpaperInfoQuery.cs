namespace Wallhaven.Net.Queries.Wallpapers;

public class WallpaperInfoQuery : IWallhavenQuery
{
    public bool RequiresAuthorization => false;
    public string WallpaperId { get; }

    internal WallpaperInfoQuery(string wallpaperId)
    {
        WallpaperId = wallpaperId;
    }

    public Uri GetRequestUri() => new Uri( "/w/" + WallpaperId, UriKind.Relative );
}
