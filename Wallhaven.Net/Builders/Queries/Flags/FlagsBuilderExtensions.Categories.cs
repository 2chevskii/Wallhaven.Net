using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Flags;

public static partial class FlagsBuilderExtensions
{
    public static FlagsBuilder<Category> IncludePeople(this FlagsBuilder<Category> self) =>
    self.Include( Category.People );

    public static FlagsBuilder<Category> IncludeAnime(this FlagsBuilder<Category> self) =>
    self.Include( Category.Anime );

    public static FlagsBuilder<Category> IncludeGeneral(this FlagsBuilder<Category> self) =>
    self.Include( Category.General );

    public static FlagsBuilder<Category> ExcludePeople(this FlagsBuilder<Category> self) =>
    self.Exclude( Category.People );

    public static FlagsBuilder<Category> ExcludeAnime(this FlagsBuilder<Category> self) =>
    self.Exclude( Category.Anime );

    public static FlagsBuilder<Category> ExcludeGeneral(this FlagsBuilder<Category> self) =>
    self.Exclude( Category.General );
}
