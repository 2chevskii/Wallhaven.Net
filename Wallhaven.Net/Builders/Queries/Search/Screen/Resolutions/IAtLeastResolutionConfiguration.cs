using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

public interface IAtLeastResolutionConfiguration
{
    IAtLeastResolutionConfiguration Of(Resolution resolution);
}
