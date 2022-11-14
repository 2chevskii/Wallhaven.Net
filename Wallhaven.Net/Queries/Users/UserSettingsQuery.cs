namespace Wallhaven.Net.Queries.Users;

// https://wallhaven.cc/api/v1/settings?apikey=<API KEY>

public class UserSettingsQuery : IWallhavenQuery
{
    public bool RequiresAuthorization => true;

    public Uri GetRequestUri() => new Uri("/settings", UriKind.Relative);
}
