using Wallhaven.Net.Builders.Queries.Flags;
using Wallhaven.Net.Builders.Queries.Search.Abstractions;
using Wallhaven.Net.Builders.Queries.Search.Sorting;
using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common;
using Wallhaven.Net.Models.Common.Sorting;

namespace Wallhaven.Net.Builders.Queries.Search;

public class TagSearchQueryBuilder : ITagSearchQueryBuilder
{
    private HashSet<string> _keywords,
                            _include,
                            _exclude;

    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public Category Categories { get; init; }
    public Purity Purity { get; init; }
    public QuerySortingMode SortingMode { get; init; }
    public QuerySortingOrder SortingOrder { get; init; }
    public string RandomSortingSeed { get; init; }
    public TopListRange TopListSortingRange { get; init; }
    public int Page { get; init; }
    public IReadOnlySet<string> Keywords => _keywords;
    public IReadOnlySet<string> IncludeTags => _include;
    public IReadOnlySet<string> ExcludeTags => _exclude;

    internal TagSearchQueryBuilder(InitialSearchQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        _keywords           = new HashSet<string>();
        _include            = new HashSet<string>();
        _exclude            = new HashSet<string>();
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
    }

    private TagSearchQueryBuilder(TagSearchQueryBuilder source)
    {
        Uploader            = source.Uploader;
        FileType            = source.FileType;
        _keywords           = new HashSet<string>( source._keywords );
        _include            = new HashSet<string>( source._include );
        _exclude            = new HashSet<string>( source._exclude );
        Categories          = source.Categories;
        Purity              = source.Purity;
        SortingMode         = source.SortingMode;
        SortingOrder        = source.SortingOrder;
        RandomSortingSeed   = source.RandomSortingSeed;
        TopListSortingRange = source.TopListSortingRange;
        Page                = source.Page;
    }

    public ITagSearchQueryBuilder WithUploader(string uploaderUsername) =>
    new TagSearchQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public ITagSearchQueryBuilder WithFileType(FileType fileType) =>
    new TagSearchQueryBuilder( this ) {
        FileType = fileType
    };

    public ITagSearchQueryBuilder Configure<TFlags>(
        Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags
    ) where TFlags : Enum
    {
        return configureFlags switch {
                   Func<FlagsBuilder<Category>, FlagsBuilder<Category>> configureCategories => new
                   TagSearchQueryBuilder( this ) {
                       Categories = configureCategories(
                           new FlagsBuilder<Category>(
                               Category.Anime | Category.General | Category.People
                           )
                       )
                       .Value
                   },
                   Func<FlagsBuilder<Purity>, FlagsBuilder<Purity>> configurePurity => new
                   TagSearchQueryBuilder( this ) {
                       Purity = configurePurity( new FlagsBuilder<Purity>( Purity.Sfw ) ).Value
                   }
               };
    }

    /*TODO: Validate input*/
    public ITagSearchQueryBuilder WithKeyword(string keyword, bool append = false)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._keywords.Add( keyword, append );

        return builder;
    }

    public ITagSearchQueryBuilder WithKeywords(
        string keyword1,
        string keyword2,
        bool append = false
    )
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._keywords.AddRange( keyword1, keyword2, append );

        return builder;
    }

    public ITagSearchQueryBuilder WithKeywords(
        string keyword1,
        string keyword2,
        string keyword3,
        bool append = false
    )
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._keywords.AddRange( keyword1, keyword2, keyword3, append );

        return builder;
    }

    // Assumes append=false
    public ITagSearchQueryBuilder WithKeywords(params string[] keywords)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._keywords.AddRange( items: keywords );

        return builder;
    }

    public ITagSearchQueryBuilder MustInclude(string tag, bool append = false)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._include.Add( tag, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustInclude(string tag1, string tag2, bool append = false)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._include.AddRange( tag1, tag2, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustInclude(
        string tag1,
        string tag2,
        string tag3,
        bool append = false
    )
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._include.AddRange( tag1, tag2, tag3, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustInclude(params string[] tags)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._include.AddRange( items: tags );

        return builder;
    }

    public ITagSearchQueryBuilder MustExclude(string tag, bool append = false)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._exclude.Add( tag, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustExclude(string tag1, string tag2, bool append = false)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._exclude.AddRange( tag1, tag2, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustExclude(
        string tag1,
        string tag2,
        string tag3,
        bool append = false
    )
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._exclude.AddRange( tag1, tag2, tag3, append );

        return builder;
    }

    public ITagSearchQueryBuilder MustExclude(params string[] tags)
    {
        var builder = new TagSearchQueryBuilder( this );

        builder._exclude.AddRange( items: tags );

        return builder;
    }

    public ITagSearchQueryBuilder UseSortingBehaviour<TSorting>(
        Func<IBasicSortingBuilder, TSorting> configureSorting
    ) where TSorting : ISortingBuilder<TSorting>
    {
        var input = new BasicSortingBuilder();

        switch (configureSorting)
        {
            case Func<IBasicSortingBuilder, IRandomSortingBuilder> configureRandomSorting:
                var randomResult = (RandomSortingBuilder) configureRandomSorting( input );

                return new TagSearchQueryBuilder( this ) {
                    SortingMode       = QuerySortingMode.Random,
                    SortingOrder      = randomResult.Order,
                    RandomSortingSeed = randomResult.Seed
                };

            case Func<IBasicSortingBuilder, IToplistSortingBuilder> configureToplistSorting:
                var toplistResult = (ToplistSortingBuilder) configureToplistSorting( input );

                return new TagSearchQueryBuilder( this ) {
                    SortingMode         = QuerySortingMode.TopList,
                    SortingOrder        = toplistResult.Order,
                    TopListSortingRange = toplistResult.Range
                };

            default:
                var basicResult =
                (BasicSortingBuilder) (IBasicSortingBuilder) configureSorting( input );

                return new TagSearchQueryBuilder( this ) {
                    SortingMode  = basicResult.Mode,
                    SortingOrder = basicResult.Order
                };
        }
    }

    public ITagSearchQueryBuilder WithPage(int page) =>
    new TagSearchQueryBuilder( this ) {
        Page = page
    };
}
