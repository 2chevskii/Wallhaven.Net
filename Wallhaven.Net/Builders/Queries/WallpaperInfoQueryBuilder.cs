using Wallhaven.Net.Queries.Wallpapers;

namespace Wallhaven.Net.Builders.Queries;

public class WallpaperInfoQueryBuilder : IBuilder<WallpaperInfoQuery>
{
    public string WallpaperId { get; }

    private WallpaperInfoQueryBuilder(string wallpaperId = "")
    {
        WallpaperId = wallpaperId;
    }

    public static WallpaperInfoQueryBuilder Create() => new WallpaperInfoQueryBuilder();

    // ReSharper disable once SuggestVarOrType_Elsewhere
    public bool Validate() => Validate( out var _ );

    public bool Validate(out IEnumerable<Exception> errors)
    {
        if ( string.IsNullOrWhiteSpace( WallpaperId ) )
        {
            errors = new[] {new Exception()};

            return false;
        }

        errors = Array.Empty<Exception>();
        return true;
    }

    public WallpaperInfoQuery Build()
    {
        if ( !Validate( out IEnumerable<Exception> errors ) )
        {
            throw new AggregateException( errors );
        }

        return new WallpaperInfoQuery( WallpaperId );
    }

    public WallpaperInfoQueryBuilder WithId(string wallpaperId)
    {
        if ( string.IsNullOrWhiteSpace( wallpaperId ) )
        {
            throw new ArgumentNullException( nameof( wallpaperId ) );
        }

        // TODO: Validate id [a-z0-9]+

        return new WallpaperInfoQueryBuilder( wallpaperId );
    }
}
