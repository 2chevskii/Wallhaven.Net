using Wallhaven.Net.Models.Common.Screen;

namespace Wallhaven.Net.Builders.Queries.Search.Screen;

public interface IAspectRatiosSearchConfiguration
{
    IAspectRatiosSearchConfiguration Include(AspectRatio ratio);

    IAspectRatiosSearchConfiguration Include(AspectRatio ratio1, AspectRatio ratio2);

    IAspectRatiosSearchConfiguration Include(
        AspectRatio ratio1,
        AspectRatio ratio2,
        AspectRatio ratio3
    );

    IAspectRatiosSearchConfiguration Include(params AspectRatio[] ratios);
}
