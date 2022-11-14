namespace Wallhaven.Net.Models.Wallpapers.Searching.Metadata;

public class WallpaperTagSearchMetadata : WallpaperSearchMetadata
{
    public new TagQueryMetadata Query { get; set; }

    // Random searches???
    public string Seed { get; set; }

    public class TagQueryMetadata
    {
        public int Id { get; set; }
        public string Tag { get; set; }
    }
}
