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

public class ExactTagQueryBuilder : IExactTagQueryBuilder
{
    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public Category Categories { get; init; }
    public Purity Purity { get; init; }
    public int TagId { get; init; }
    public QuerySortingMode SortingMode { get; init; }
    public QuerySortingOrder SortingOrder { get; init; }
    public string RandomSortingSeed { get; init; }
    public TopListRange TopListSortingRange { get; init; }
    public int Page { get; init; }
    public ResolutionQueryMode ResolutionQueryMode { get; init; }
    public HashSet<Resolution> Resolutions { get; }
    public HashSet<AspectRatio> Ratios { get; }

    internal ExactTagQueryBuilder(InitialSearchQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        TagId               = 0;
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

    private ExactTagQueryBuilder(ExactTagQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        TagId               = source.TagId;
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
        ResolutionQueryMode = source.ResolutionQueryMode;
        Resolutions         = new HashSet<Resolution>( source.Resolutions );
        Ratios              = new HashSet<AspectRatio>( source.Ratios );
    }

    public IExactTagQueryBuilder WithUploader(string uploaderUsername) =>
    new ExactTagQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public IExactTagQueryBuilder WithFileType(FileType fileType) =>
    new ExactTagQueryBuilder( this ) {
        FileType = fileType
    };

    public IExactTagQueryBuilder Configure<TFlags>(
        Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags
    ) where TFlags : Enum
    {
        return configureFlags switch {
                   Func<FlagsBuilder<Category>, FlagsBuilder<Category>> configureCategories => new
                   ExactTagQueryBuilder( this ) {
                       Categories = configureCategories(
                           new FlagsBuilder<Category>(
                               Category.Anime | Category.General | Category.People
                           )
                       )
                       .Value
                   },
                   Func<FlagsBuilder<Purity>, FlagsBuilder<Purity>> configurePurity => new
                   ExactTagQueryBuilder( this ) {
                       Purity = configurePurity( new FlagsBuilder<Purity>( Purity.Sfw ) ).Value
                   }
               };
    }

    public IExactTagQueryBuilder UseSortingBehaviour<TSorting>(
        Func<IBasicSortingBuilder, TSorting> configureSorting
    ) where TSorting : ISortingBuilder<TSorting>
    {
        var input = new BasicSortingBuilder();

        switch (configureSorting)
        {
            case Func<IBasicSortingBuilder, IRandomSortingBuilder> configureRandomSorting:
                var randomResult = (RandomSortingBuilder) configureRandomSorting( input );

                return new ExactTagQueryBuilder( this ) {
                    SortingMode       = QuerySortingMode.Random,
                    SortingOrder      = randomResult.Order,
                    RandomSortingSeed = randomResult.Seed
                };

            case Func<IBasicSortingBuilder, IToplistSortingBuilder> configureToplistSorting:
                var toplistResult = (ToplistSortingBuilder) configureToplistSorting( input );

                return new ExactTagQueryBuilder( this ) {
                    SortingMode         = QuerySortingMode.TopList,
                    SortingOrder        = toplistResult.Order,
                    TopListSortingRange = toplistResult.Range
                };

            default:
                var basicResult =
                (BasicSortingBuilder) (IBasicSortingBuilder) configureSorting( input );

                return new ExactTagQueryBuilder( this ) {
                    SortingMode  = basicResult.Mode,
                    SortingOrder = basicResult.Order
                };
        }
    }

    public IExactTagQueryBuilder WithPage(int page) =>
    new ExactTagQueryBuilder( this ) {
        Page = page
    };

    public IExactTagQueryBuilder WithTag(int tagId) =>
    new ExactTagQueryBuilder( this ) {
        TagId = tagId
    };

    public IExactTagQueryBuilder ConfigureAspectRatios(
        Func<IAspectRatiosSearchConfiguration, IAspectRatiosSearchConfiguration>
        configureAspectRatios
    )
    {
        var result =
        (AspectRatiosSearchConfiguration) configureAspectRatios(
            new AspectRatiosSearchConfiguration()
        );

        var builder = new ExactTagQueryBuilder( this );

        builder.Ratios.AddRange( false, result.Ratios.ToArray() );

        return builder;
    }

    public IExactTagQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IAtLeastResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (AtLeastResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new ExactTagQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.AtLeast
        };

        builder.Resolutions.Clear();
        builder.Resolutions.Add( result.Resolution );

        return builder;
    }

    public IExactTagQueryBuilder ConfigureResolutions(
        Func<IResolutionConfiguration, IExactResolutionConfiguration> configureResolutions
    )
    {
        var result =
        (ExactResolutionConfiguration) configureResolutions( new ResolutionConfiguration() );

        var builder = new ExactTagQueryBuilder( this ) {
            ResolutionQueryMode = ResolutionQueryMode.Exact
        };

        builder.Resolutions.Clear();
        builder.Resolutions.AddRange( false, result.Resolutions.ToArray() );

        return builder;
    }
}
