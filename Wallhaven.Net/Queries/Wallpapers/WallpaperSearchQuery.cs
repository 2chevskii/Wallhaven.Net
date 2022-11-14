#define JETBRAINS_ANNOTATIONS
using System.Drawing;

using Flurl;

using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Screen;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Queries.Wallpapers;

public class WallpaperSearchQuery : IWallhavenQuery
{
    public int ExactTagId { get; init; }
    public IEnumerable<string> Keywords { get; init; }
    public IEnumerable<string> IncludeTags { get; init; }
    public IEnumerable<string> ExcludeTags { get; init; }
    public string? Username { get; init; }
    public FileType FileType { get; init; }
    public Category Categories { get; init; }
    public Purity Purity { get; init; }
    public string? SimilarToWallpaperId { get; init; }
    public QuerySortMode Sorting { get; init; }
    public QuerySortingOrder Order { get; init; }
    public TopListRange TopRange { get; init; }
    public ResolutionQueryMode ResolutionQueryMode { get; init; }
    public IEnumerable<Resolution> Resolutions { get; init; }
    public IEnumerable<AspectRatio> Ratios { get; init; }
    public IEnumerable<Color> Colors { get; init; }
    public int Page { get; init; }
    public string? Seed { get; init; }

    public bool RequiresAuthorization => false;

    internal WallpaperSearchQuery() { }

    public Uri GetRequestUri()
    {
        var requestUrl = new Url( "/search" );

        List<string> qParams = new List<string>();

        if ( ExactTagId is not 0 ) { qParams.Add( "id%3A" + ExactTagId ); }
        else
        {
            if ( Keywords.Any() )
            {
                qParams.AddRange( from keyword in Keywords select Uri.EscapeDataString( keyword ) );
            }

            if ( IncludeTags.Any() )
            {
                qParams.AddRange(
                    from tag in IncludeTags select Uri.EscapeDataString( '+' + tag )
                );
            }

            if ( ExcludeTags.Any() )
            {
                qParams.AddRange(
                    from tag in ExcludeTags select Uri.EscapeDataString( '-' + tag )
                );
            }

            if ( SimilarToWallpaperId.IsNotNull() )
            {
                qParams.Add( Uri.EscapeDataString( "like:" + SimilarToWallpaperId ) );
            }
        }

        if ( FileType is not FileType.Unspecified )
        {
            qParams.Add( Uri.EscapeDataString( FileType.ToQueryParam() ) );
        }

        if ( Username.IsNotNull() ) { qParams.Add( Uri.EscapeDataString( '@' + Username ) ); }

        /* Add q= param if there is data */

        if ( qParams.Any() )
        {
            requestUrl.SetQueryParam( "q", qParams.JoinUriSpace(), isEncoded: true );
        }

        requestUrl.SetQueryParam( "categories", Categories.ToQueryParam() )
                  .SetQueryParam( "purity", Purity.ToQueryParam() )
                  .SetQueryParam( "sorting", Sorting.ToQueryParam() )
                  .SetQueryParam( "order", Order.ToQueryParam() );

        if ( Sorting is QuerySortMode.TopList )
        {
            requestUrl.SetQueryParam( "topRange", TopRange.ToQueryParam() );
        }

        if ( Resolutions.Any() )
        {
            if ( ResolutionQueryMode is ResolutionQueryMode.Exact )
            {
                requestUrl.SetQueryParam(
                    "resolutions",
                    Resolutions.Select( resolution => resolution.ToString() ).JoinComma()
                );
            }
            else { requestUrl.SetQueryParam( "atleast", Resolutions.First().ToString() ); }
        }

        if ( Ratios.Any() )
        {
            requestUrl.SetQueryParam( "ratios", Ratios.Select( x => x.ToString() ).JoinComma() );
        }

        if ( Colors.Any() )
        {
            // TODO: Convert to hex string
            requestUrl.SetQueryParam( "colors", Colors.Select( x => x.ToHexString() ).JoinComma() );
        }

        if ( Page is not 0 ) { requestUrl.SetQueryParam( "page", Page.ToString() ); }

        if ( Sorting is QuerySortMode.Random && Seed is not null )
        {
            requestUrl.SetQueryParam( "seed", Seed );
        }

        return requestUrl.ToUri();
    }
}
