using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Screen;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Models.Users;

public class UserSettings
{
    // Source: thumb_size
    public ThumbnailSize ThumbnailSize { get; set; }

    public int PerPage { get; set; }

    // Source: string[]
    public Purity Purity { get; set; }

    // Source: string[]
    public Category Categories { get; set; }

    public IEnumerable<Resolution> Resolutions { get; set; }

    public IEnumerable<AspectRatio> AspectRatios { get; set; }

    public TopListRange TopListRange { get; set; }

    // Source: tag_blacklist
    public string[] BlacklistedTags { get; set; }

    // Source: user_blacklist
    public string[] BlacklistedUsers { get; set; }
}
