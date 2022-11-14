using Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

namespace Wallhaven.Net.Builders.Queries.Search.Screen;

public interface IResolutionConfiguration
{
    IAtLeastResolutionConfiguration AtLeast();

    IExactResolutionConfiguration Which();
}
