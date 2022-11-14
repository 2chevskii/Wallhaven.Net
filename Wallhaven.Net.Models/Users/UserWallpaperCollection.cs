namespace Wallhaven.Net.Models.Users;

public class UserWallpaperCollection
{
    public int Id { get; set; }

    public string Label { get; set; }

    public int Views { get; set; }

    // Source: int public
    public bool IsPublic { get; set; }

    public int Count { get; set; }
}
