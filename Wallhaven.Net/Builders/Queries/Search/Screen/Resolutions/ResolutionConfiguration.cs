namespace Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

public class ResolutionConfiguration : IResolutionConfiguration
{

    public IAtLeastResolutionConfiguration AtLeast() => new AtLeastResolutionConfiguration();

    public IExactResolutionConfiguration Which() => new ExactResolutionConfiguration();
}
