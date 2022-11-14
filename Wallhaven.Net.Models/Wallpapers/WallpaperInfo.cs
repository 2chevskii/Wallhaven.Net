using Wallhaven.Net.Models.Tags;
using Wallhaven.Net.Models.Wallpapers.Common;
using Wallhaven.Net.Models.Wallpapers.Searching;

namespace Wallhaven.Net.Models.Wallpapers;

public class WallpaperInfo : WallpaperSearchData
{
    public WallpaperUploaderInfo Uploader { get; set; }
    public IEnumerable<TagInfo> Tags { get; set; }
}
