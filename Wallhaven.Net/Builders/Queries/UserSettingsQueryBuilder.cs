using Wallhaven.Net.Queries.Users;

namespace Wallhaven.Net.Builders.Queries;

public class UserSettingsQueryBuilder : IBuilder<UserSettingsQuery>
{
    public bool Validate() => true;

    public bool Validate(out IEnumerable<Exception> errors)
    {
        errors = Array.Empty<Exception>();

        return true;
    }

    public UserSettingsQuery Build() => new UserSettingsQuery(); /*No validation here because it's redundant*/
}
