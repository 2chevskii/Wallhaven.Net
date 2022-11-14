using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

public class AtLeastResolutionConfiguration :IAtLeastResolutionConfiguration
{
    public Resolution Resolution { get; }

    internal AtLeastResolutionConfiguration()
    {

    }

    private AtLeastResolutionConfiguration(Resolution resolution)
    {
        Resolution = resolution;
    }

    public IAtLeastResolutionConfiguration Of(Resolution resolution) =>
    new AtLeastResolutionConfiguration( resolution );
}
