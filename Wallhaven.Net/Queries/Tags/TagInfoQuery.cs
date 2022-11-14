namespace Wallhaven.Net.Queries.Tags;

public class TagInfoQuery : IWallhavenQuery
{
    public bool RequiresAuthorization => false;
    public int TagId { get; }

    internal TagInfoQuery(int tagId)
    {
        TagId = tagId;
    }

    public Uri GetRequestUri() => new Uri( "/tag/" + TagId, UriKind.Relative );
}
