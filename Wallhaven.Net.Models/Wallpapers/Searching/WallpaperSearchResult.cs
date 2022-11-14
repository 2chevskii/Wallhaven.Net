using Wallhaven.Net.Models.Wallpapers.Searching.Metadata;

namespace Wallhaven.Net.Models.Wallpapers.Searching;

public class WallpaperSearchResult
{
    public IEnumerable<WallpaperSearchData> Data { get; set; }

    // Source: meta
    public WallpaperSearchMetadata Metadata { get; set; }
}
