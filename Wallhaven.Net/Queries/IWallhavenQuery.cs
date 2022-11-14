namespace Wallhaven.Net.Queries;

public interface IWallhavenQuery
{
    bool RequiresAuthorization { get; }
    Uri GetRequestUri();
}
