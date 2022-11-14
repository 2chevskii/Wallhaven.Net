using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Flags;

public static partial class FlagsBuilderExtensions
{
    public static FlagsBuilder<Purity> IncludeSfw(this FlagsBuilder<Purity> self) =>
    self.Include( Purity.Sfw );

    public static FlagsBuilder<Purity> IncludeSketchy(this FlagsBuilder<Purity> self) =>
    self.Include( Purity.Sketchy );

    public static FlagsBuilder<Purity> IncludeNsfw(this FlagsBuilder<Purity> self) =>
    self.Include( Purity.Nsfw );

    public static FlagsBuilder<Purity> ExcludeSfw(this FlagsBuilder<Purity> self) =>
    self.Exclude( Purity.Sfw );

    public static FlagsBuilder<Purity> ExcludeSketchy(this FlagsBuilder<Purity> self) =>
    self.Exclude( Purity.Sketchy );

    public static FlagsBuilder<Purity> ExcludeNsfw(this FlagsBuilder<Purity> self) =>
    self.Exclude( Purity.Nsfw );
}
