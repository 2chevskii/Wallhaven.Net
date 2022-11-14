using System.Drawing;

using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Extensions;

public static class QueryParamExtensions
{
    public static string ToQueryParam(this FileType fileType)
    {
#pragma warning disable CS8524
        return fileType switch {
                   FileType.Unspecified          => throw new InvalidOperationException(),
                   FileType.Jpeg or FileType.Jpg => "type:jpg",
                   FileType.Png                  => "type:png"
               };
#pragma warning restore CS8524
    }

    public static string ToQueryParam(this Purity purity)
    {
        return Convert.ToString( (int) purity, 2 );
    }

    public static string ToQueryParam(this Category category)
    {
        return Convert.ToString( (int) category, 2 );
    }

    public static string ToQueryParam(this QuerySortingMode sortingMode)
    {
        return sortingMode switch {
                   QuerySortingMode.Favorites => "favorites",
                   QuerySortingMode.Hot       => "hot",
                   QuerySortingMode.Random    => "random",
                   QuerySortingMode.Views     => "views",
                   QuerySortingMode.Relevance => "relevance",
                   QuerySortingMode.TopList   => "toplist"
               };
    }

    public static string ToQueryParam(this QuerySortingOrder order)
    {
        return order switch {
                   QuerySortingOrder.Ascending  => "asc",
                   QuerySortingOrder.Descending => "desc"
               };
    }

    public static string ToQueryParam(this TopListRange topRange)
    {
        return topRange switch {
                   TopListRange.Day         => "1d",
                   TopListRange.ThreeDays   => "3d",
                   TopListRange.Week        => "1w",
                   TopListRange.ThreeMonths => "3m",
                   TopListRange.SixMonths   => "6m",
                   TopListRange.Year        => "1y"
               };
    }

    public static string JoinUriSpace(this IEnumerable<string> self)
    {
        return string.Join( '+', self );
    }

    public static string JoinComma(this IEnumerable<string> self)
    {
        return string.Join( ',', self );
    }

    public static string ToHexString(this Color color)
    {
        return string.Concat(
            color.R.ToString( "x" ),
            color.G.ToString( "x" ),
            color.B.ToString( "x" )
        );
    }
}
