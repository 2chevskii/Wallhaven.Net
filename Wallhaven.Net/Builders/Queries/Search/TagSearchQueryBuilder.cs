using System.Diagnostics.Tracing;

using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search;

public class TagSearchQueryBuilder : ITagSearchQueryBuilder
{
    private HashSet<string> _keywords,
                            _include,
                            _exclude;

    public string Uploader { get; private init; }
    public FileType FileType { get; private init; }
    public IReadOnlySet<string> Keywords => _keywords;
    public IReadOnlySet<string> IncludeTags => _include;
    public IReadOnlySet<string> ExcludeTags => _exclude;

    internal TagSearchQueryBuilder(IInitialSearchQueryBuilder source)
    {
        Uploader  = source.Uploader;
        FileType  = source.FileType;
        _keywords = new HashSet<string>();
        _include  = new HashSet<string>();
        _exclude  = new HashSet<string>();
    }

    private TagSearchQueryBuilder(TagSearchQueryBuilder source)
    {
        Uploader  = source.Uploader;
        FileType  = source.FileType;
        _keywords = new HashSet<string>( source._keywords );
        _include  = new HashSet<string>( source._include );
        _exclude  = new HashSet<string>( source._exclude );
    }

    public ITagSearchQueryBuilder WithUploader(string uploaderUsername) =>
    new TagSearchQueryBuilder( this ) {
        Uploader = uploaderUsername
    };

    public ITagSearchQueryBuilder WithFileType(FileType fileType) =>
    new TagSearchQueryBuilder( this ) {
        FileType = fileType
    };

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
}
