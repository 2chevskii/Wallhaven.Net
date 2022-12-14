using System.Diagnostics.Tracing;
using System.Security.AccessControl;

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

public class InitialSearchQueryBuilder : IInitialSearchQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public Category Categories { get; init; }
    public Purity Purity { get; init; }

    public QuerySortingMode SortingMode { get; init; }
    public QuerySortingOrder SortingOrder { get; init; }
    public string RandomSortingSeed { get; init; }
    public TopListRange TopListSortingRange { get; init; }
    public int Page { get; init; }
    public ResolutionQueryMode ResolutionQueryMode { get; init; }
    public HashSet<Resolution> Resolutions { get; }
    public HashSet<AspectRatio> Ratios { get; }

    internal InitialSearchQueryBuilder()
    {
        Uploader            = string.Empty;
        FileType            = FileType.Unspecified;
        Categories          = Category.Anime | Category.People | Category.General;
        Purity              = Purity.Sfw;
        SortingMode         = QuerySortingMode.UploadDate;
        SortingOrder        = QuerySortingOrder.Descending;
        RandomSortingSeed   = string.Empty;
        TopListSortingRange = TopListRange.Month;
        Page                = 1;
        ResolutionQueryMode = ResolutionQueryMode.Exact;
        Resolutions         = new HashSet<Resolution>();
        Ratios              = new HashSet<AspectRatio>();
    }

    /*Copy constructor*/
    private InitialSearchQueryBuilder(InitialSearchQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
        ResolutionQueryMode = ResolutionQueryMode.Exact;
        Resolutions         = new HashSet<Resolution>( source.Resolutions );
        Ratios              = new HashSet<AspectRatio>( source.Ratios );
    }

    public IInitialSearchQueryBuilder WithUploader(string username)
    {
        return new InitialSearchQueryBuilder( this ) {
            Uploader = username
        };
    }

    public IInitialSearchQueryBuilder WithFileType(FileType fileType)
    {
        return new InitialSearchQueryBuilder( this ) {
            FileType = fileType
        };
    }

    public IInitialSearchQueryBuilder Configure<TFlags>(
        Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags
    ) where TFlags : Enum
    {
        return configureFlags switch {
                   Func<FlagsBuilder<Category>, FlagsBuilder<Category>> configureCategories => new
                   InitialSearchQueryBuilder( this ) {
                       Categories = configureCategories(
                           new FlagsBuilder<Category>(
                               Category.Anime | Category.General | Category.People
                           )
                       )
                       .Value
                   },
                   Func<FlagsBuilder<Purity>, FlagsBuilder<Purity>> configurePurity => new
                   InitialSearchQueryBuilder( this ) {
                       Purity = configurePurity( new FlagsBuilder<Purity>( Purity.Sfw ) ).Value
                   }
               };
    }

    public IInitialSearchQueryBuilder UseSortingBehaviour<TSorting>(
        Func<IBasicSortingBuilder, TSorting> configureSorting
    ) where TSorting : ISortingBuilder<TSorting>
    {
        var input = new BasicSortingBuilder();

        switch (configureSorting)
        {
            case Func<IBasicSortingBuilder, IRandomSortingBuilder> configureRandomSorting:
                var randomResult = (RandomSortingBuilder) configureRandomSorting( input );

                return new InitialSearchQueryBuilder( this ) {
                    SortingMode       = QuerySortingMode.Random,
                    SortingOrder      = randomResult.Order,
                    RandomSortingSeed = randomResult.Seed
                };

            case Func<IBasicSortingBuilder, IToplistSortingBuilder> configureToplistSorting:
                var toplistResult = (ToplistSortingBuilder) configureToplistSorting( input );

                return new InitialSearchQueryBuilder( this ) {
                    SortingMode         = QuerySortingMode.TopList,
                    SortingOrder        = toplistResult.Order,
                    TopListSortingRange = toplistResult.Range
                };

            default:
                var basicResult =
                (BasicSortingBuilder) (IBasicSortingBuilder) configureSorting( input );

                return new InitialSearchQueryBuilder( this ) {
                    SortingMode  = basicResult.Mode,
                    SortingOrder = basicResult.Order
                };
        }
    }

    public IInitialSearchQueryBuilder WithPage(int page) =>
    new InitialSearchQueryBuilder( this ) {
        Page = page
    };

    public IExactTagQueryBuilder AsExactTagQuery() => new ExactTagQueryBuilder( this );

    public ITagSearchQueryBuilder AsTagSearchQuery() => new TagSearchQueryBuilder( this );

    public ISimilarToQueryBuilder AsSimilarToQuery() => new SimilarToQueryBuilder( this );

    public IInitialSearchQueryBuilder ConfigureAspectRatios(
        Func<IAspectRatiosSearchConfiguration, IAspectRatiosSearchConfiguration>
        configureAspectRatios
    )
    {
        var result =
        (AspectRatiosSearchConfiguration) configureAspectRatios(
            new AspectRatiosSearchConfiguration()
        );

        var builder = new InitialSearchQueryBuilder( this );

        builder.Ratios.AddRange( false, result.Ratios.ToArray() );

        return builder;
    }

    public IInitialSearchQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IAtLeastResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (AtLeastResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new InitialSearchQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.AtLeast
        };

        builder.Resolutions.Clear();
        builder.Resolutions.Add( result.Resolution );

        return builder;
    }

    public IInitialSearchQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IExactResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (ExactResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new InitialSearchQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.Exact
        };

        builder.Resolutions.Clear();
        builder.Resolutions.AddRange( false, result.Resolutions.ToArray() );

        return builder;
    }
}
