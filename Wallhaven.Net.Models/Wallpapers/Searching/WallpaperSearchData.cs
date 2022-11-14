using System.Drawing;

using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Screen;
using Wallhaven.Net.Models.Wallpapers.Common;

namespace Wallhaven.Net.Models.Wallpapers.Searching;

public class WallpaperSearchData
{
    public string Id { get; set; }
    public Uri Url { get; set; }
    public Uri ShortUrl { get; set; }

    public int Views { get; set; }
    public int Favorites { get; set; }
    public string Source { get; set; }
    public Purity Purity { get; set; }
    public Category Category { get; set; }
    public Resolution Resolution { get; set; }
    /*
     * DimensionX
     * DimensionY
     */

    // Source: ratio
    public AspectRatio AspectRatio { get; set; }

    public long FileSize { get; set; }
    public FileType FileType { get; set; }

    // Source created_at
    public DateTime UploadDate { get; set; }
    public IEnumerable<Color> Colors { get; set; }
    public Uri Path { get; set; }

    // Source: thumbs
    public WallpaperThumbnailCollection Thumbnails { get; set; }


}
