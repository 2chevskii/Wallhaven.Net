using Wallhaven.Net.Builders.Queries.Search;
using Wallhaven.Net.Builders.Queries.Search.Abstractions;

namespace Wallhaven.Net;

public static class Whvn
{
    public static IInitialSearchQueryBuilder Search()
    {
        return new InitialSearchQueryBuilder();
    }
}
