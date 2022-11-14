using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;

public class ExactResolutionConfiguration : IExactResolutionConfiguration
{
    public HashSet<Resolution> Resolutions { get; }

    internal ExactResolutionConfiguration() { Resolutions = new HashSet<Resolution>(); }

    public IExactResolutionConfiguration Include(Resolution resolution)
    {
        var config = new ExactResolutionConfiguration();

        config.Resolutions.Add( resolution );

        return config;
    }

    public IExactResolutionConfiguration Include(Resolution resolution1, Resolution resolution2)
    {
        var config = new ExactResolutionConfiguration();

        config.Resolutions.AddRange( resolution1, resolution2, true );

        return config;
    }

    public IExactResolutionConfiguration Include(
        Resolution resolution1,
        Resolution resolution2,
        Resolution resolution3
    )
    {
        var config = new ExactResolutionConfiguration();

        config.Resolutions.AddRange( resolution1, resolution2, resolution3, true );

        return config;
    }

    public IExactResolutionConfiguration Include(params Resolution[] resolutions)
    {
        var config = new ExactResolutionConfiguration();

        config.Resolutions.AddRange( true, resolutions );

        return config;
    }
}
