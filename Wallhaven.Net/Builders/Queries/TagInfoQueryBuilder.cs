using Wallhaven.Net.Queries.Tags;

namespace Wallhaven.Net.Builders.Queries;

public class TagInfoQueryBuilder : IBuilder<TagInfoQuery>
{
    public int TagId { get; }

    private TagInfoQueryBuilder(int tagId = 0) { TagId = tagId; }

    public static TagInfoQueryBuilder Create() => new TagInfoQueryBuilder();

    public bool Validate() => Validate( out var _ );

    public bool Validate(out IEnumerable<Exception> errors)
    {
        if ( TagId <= 0 )
        {
            errors = new[] {new Exception() /*TODO: Custom 'missing required param' exception*/};

            return false;
        }

        errors = Array.Empty<Exception>();

        return true;
    }

    public TagInfoQuery Build() => new TagInfoQuery(TagId);

    public TagInfoQueryBuilder WithId(int tagId)
    {
        if ( tagId <= 0 )
        {
            throw new ArgumentOutOfRangeException(
                nameof( tagId ),
                "Tag ID cannot be less than 1"
            );
        }

        return new TagInfoQueryBuilder( tagId );
    }
}
