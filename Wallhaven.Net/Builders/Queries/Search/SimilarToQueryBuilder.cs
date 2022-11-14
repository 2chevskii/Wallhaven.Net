using Wallhaven.Net.Builders.Queries.Flags;
using Wallhaven.Net.Builders.Queries.Search.Abstractions;
using Wallhaven.Net.Builders.Queries.Search.Screen;
using Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;
using Wallhaven.Net.Builders.Queries.Search.Sorting;
using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Screen;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search;

public class SimilarToQueryBuilder : ISimilarToQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public Category Categories { get; init; }
    public Purity Purity { get; init; }
    public string WallpaperId { get; private init; }
    public QuerySortingMode SortingMode { get; init; }
    public QuerySortingOrder SortingOrder { get; init; }
    public string RandomSortingSeed { get; init; }
    public TopListRange TopListSortingRange { get; init; }
    public int Page { get; init; }

    public ResolutionQueryMode ResolutionQueryMode { get; init; }
    public HashSet<Resolution> Resolutions { get; }
    public HashSet<AspectRatio> Ratios { get; }

    internal SimilarToQueryBuilder(InitialSearchQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        WallpaperId         = string.Empty;
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
        ResolutionQueryMode = source.ResolutionQueryMode;
        Resolutions         = new HashSet<Resolution>( source.Resolutions );
        Ratios              = new HashSet<AspectRatio>(source.Ratios);
    }

    private SimilarToQueryBuilder(SimilarToQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        WallpaperId         = source.WallpaperId;
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
        ResolutionQueryMode = source.ResolutionQueryMode;
        Resolutions         = new HashSet<Resolution>( source.Resolutions );
        Ratios              = new HashSet<AspectRatio>(source.Ratios);
    }

    public ISimilarToQueryBuilder WithUploader(string uploaderUsername) =>
    new SimilarToQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public ISimilarToQueryBuilder WithFileType(FileType fileType) =>
    new SimilarToQueryBuilder( this ) {
        FileType = fileType
    };

    public ISimilarToQueryBuilder Configure<TFlags>(
        Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags
    ) where TFlags : Enum
    {
        return configureFlags switch {
                   Func<FlagsBuilder<Category>, FlagsBuilder<Category>> configureCategories => new
                   SimilarToQueryBuilder( this ) {
                       Categories = configureCategories(
                           new FlagsBuilder<Category>(
                               Category.Anime | Category.General | Category.People
                           )
                       )
                       .Value
                   },
                   Func<FlagsBuilder<Purity>, FlagsBuilder<Purity>> configurePurity => new
                   SimilarToQueryBuilder( this ) {
                       Purity = configurePurity( new FlagsBuilder<Purity>( Purity.Sfw ) ).Value
                   }
               };
    }

    public ISimilarToQueryBuilder UseSortingBehaviour<TSorting>(
        Func<IBasicSortingBuilder, TSorting> configureSorting
    ) where TSorting : ISortingBuilder<TSorting>
    {
        var input = new BasicSortingBuilder();

        switch (configureSorting)
        {
            case Func<IBasicSortingBuilder, IRandomSortingBuilder> configureRandomSorting:
                var randomResult = (RandomSortingBuilder) configureRandomSorting( input );

                return new SimilarToQueryBuilder( this ) {
                    SortingMode       = QuerySortingMode.Random,
                    SortingOrder      = randomResult.Order,
                    RandomSortingSeed = randomResult.Seed
                };

            case Func<IBasicSortingBuilder, IToplistSortingBuilder> configureToplistSorting:
                var toplistResult = (ToplistSortingBuilder) configureToplistSorting( input );

                return new SimilarToQueryBuilder( this ) {
                    SortingMode         = QuerySortingMode.TopList,
                    SortingOrder        = toplistResult.Order,
                    TopListSortingRange = toplistResult.Range
                };

            default:
                var basicResult =
                (BasicSortingBuilder) (IBasicSortingBuilder) configureSorting( input );

                return new SimilarToQueryBuilder( this ) {
                    SortingMode  = basicResult.Mode,
                    SortingOrder = basicResult.Order
                };
        }
    }

    public ISimilarToQueryBuilder WithPage(int page) =>
    new SimilarToQueryBuilder( this ) {
        Page = page
    };

    public ISimilarToQueryBuilder WithSimilarWallpaperId(string wallpaperId) =>
    new SimilarToQueryBuilder( this ) {
        WallpaperId = wallpaperId
    };

    public ISimilarToQueryBuilder ConfigureAspectRatios(
        Func<IAspectRatiosSearchConfiguration, IAspectRatiosSearchConfiguration>
        configureAspectRatios
    )
    {
        var result =
        (AspectRatiosSearchConfiguration) configureAspectRatios(
            new AspectRatiosSearchConfiguration()
        );

        var builder = new SimilarToQueryBuilder( this );

        builder.Ratios.AddRange( false, result.Ratios.ToArray() );

        return builder;
    }

    public ISimilarToQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IAtLeastResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (AtLeastResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new SimilarToQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.AtLeast
        };

        builder.Resolutions.Clear();
        builder.Resolutions.Add( result.Resolution );

        return builder;
    }

    public ISimilarToQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IExactResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (ExactResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new SimilarToQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.Exact
        };

        builder.Resolutions.Clear();
        builder.Resolutions.AddRange( false, result.Resolutions.ToArray() );

        return builder;
    }
}
