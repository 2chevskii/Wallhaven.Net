using Wallhaven.Net.Builders.Queries.Flags;
using Wallhaven.Net.Builders.Queries.Search.Abstractions;
using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Extensions;

public static class SearchQueryBuilderExtensions
{
    public static T ConfigureCategories<T>(
        this ISearchQueryBuilder<T> builder,
        Func<FlagsBuilder<Category>, FlagsBuilder<Category>> configureCategories
    ) where T : ISearchQueryBuilder<T>
    {
        return builder.Configure( configureCategories );
    }

    public static T ConfigurePurity<T>(
        this ISearchQueryBuilder<T> builder,
        Func<FlagsBuilder<Purity>, FlagsBuilder<Purity>> configurePurity
    ) where T : ISearchQueryBuilder<T>
    {
        return builder.Configure( configurePurity );
    }
}
