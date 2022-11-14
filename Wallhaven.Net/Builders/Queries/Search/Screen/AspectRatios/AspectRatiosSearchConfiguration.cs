using Wallhaven.Net.Extensions;
using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen;

public class AspectRatiosSearchConfiguration :IAspectRatiosSearchConfiguration
{
    public HashSet<AspectRatio> Ratios { get; }

    internal AspectRatiosSearchConfiguration()
    {
        Ratios = new HashSet<AspectRatio>();
    }

    private AspectRatiosSearchConfiguration(AspectRatiosSearchConfiguration source)
    {
        Ratios = new HashSet<AspectRatio>( source.Ratios );
    }

    public IAspectRatiosSearchConfiguration Include(AspectRatio ratio)
    {
        var configuration = new AspectRatiosSearchConfiguration( this );
        configuration.Ratios.Add( ratio );

        return configuration;
    }

    public IAspectRatiosSearchConfiguration Include(AspectRatio ratio1, AspectRatio ratio2)
    {
        var configuration = new AspectRatiosSearchConfiguration( this );
        configuration.Ratios.AddRange( ratio1, ratio2, true );

        return configuration;
    }

    public IAspectRatiosSearchConfiguration Include(
        AspectRatio ratio1,
        AspectRatio ratio2,
        AspectRatio ratio3
    )
    {
        var configuration = new AspectRatiosSearchConfiguration( this );
        configuration.Ratios.AddRange( ratio1, ratio2, ratio3, true );

        return configuration;
    }

    public IAspectRatiosSearchConfiguration Include(params AspectRatio[] ratios)
    {
        var configuration = new AspectRatiosSearchConfiguration( this );
        configuration.Ratios.AddRange(true, ratios);

        return configuration;
    }
}
