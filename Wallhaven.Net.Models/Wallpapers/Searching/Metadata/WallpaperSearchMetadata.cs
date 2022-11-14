namespace Wallhaven.Net.Models.Wallpapers.Searching.Metadata;

public class WallpaperSearchMetadata
{
    public int CurrentPage { get; set; }
    public int LastPage { get; set; }
    public int PerPage { get; set; }
    public int Total { get; set; }
    public string? Query { get; set; }

}
