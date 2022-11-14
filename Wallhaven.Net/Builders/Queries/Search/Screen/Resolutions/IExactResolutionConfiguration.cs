using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

public interface IExactResolutionConfiguration
{
    IExactResolutionConfiguration Include(Resolution resolution);

    IExactResolutionConfiguration Include(Resolution resolution1, Resolution resolution2);

    IExactResolutionConfiguration Include(
        Resolution resolution1,
        Resolution resolution2,
        Resolution resolution3
    );

    IExactResolutionConfiguration Include(params Resolution[] resolutions);
}
