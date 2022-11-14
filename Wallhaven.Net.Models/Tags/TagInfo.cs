using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Models.Tags;

public class TagInfo
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Alias { get; set; }

    public int CategoryId { get; set; }

    // Source: category
    public string CategoryName { get; set; }

    public Purity Purity { get; set; }

    public DateTime CreatedAt { get; set; }
}
