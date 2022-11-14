using System.Collections;

using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Models.Wallpapers.Common;

public class WallpaperThumbnailCollection : IReadOnlyDictionary<ThumbnailSize, Uri>
{
    public Uri Large { get; set; }
    public Uri Original { get; set; }
    public Uri Small { get; set; }

    public int Count => 3;

#pragma warning disable CS8524
    public Uri this[ThumbnailSize key] => key switch {
                                              ThumbnailSize.Large    => Large,
                                              ThumbnailSize.Original => Original,
                                              ThumbnailSize.Small    => Small,
                                          };
#pragma warning restore CS8524

    public IEnumerable<ThumbnailSize> Keys
    {
        get
        {
            yield return ThumbnailSize.Large;
            yield return ThumbnailSize.Original;
            yield return ThumbnailSize.Small;
        }
    }

    public IEnumerable<Uri> Values
    {
        get
        {
            yield return Large;
            yield return Original;
            yield return Small;
        }
    }

    public IEnumerator<KeyValuePair<ThumbnailSize, Uri>> GetEnumerator()
    {
        IEnumerable<KeyValuePair<ThumbnailSize, Uri>> _()
        {
            yield return new KeyValuePair<ThumbnailSize, Uri>( ThumbnailSize.Large, Large );
            yield return new KeyValuePair<ThumbnailSize, Uri>( ThumbnailSize.Original, Original );
            yield return new KeyValuePair<ThumbnailSize, Uri>( ThumbnailSize.Small, Small );
        }

        return _().GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public bool ContainsKey(ThumbnailSize key) => true;

    public bool TryGetValue(ThumbnailSize key, out Uri value)
    {
        value = this[key];

        return true;
    }
}
