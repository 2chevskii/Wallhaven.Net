using Wallhaven.Net.Builders.Queries.Flags;
using Wallhaven.Net.Builders.Queries.Search.Screen;
using Wallhaven.Net.Builders.Queries.Search.Screen.Resolutions;
using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search.Abstractions;

public interface ISearchQueryBuilder<T> where T : ISearchQueryBuilder<T>
{
    T WithUploader(string uploaderUsername);

    T WithFileType(FileType fileType);

    T Configure<TFlags>(Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags)
    where TFlags : Enum;

    T UseSortingBehaviour<TSorting>(Func<IBasicSortingBuilder, TSorting> configureSorting)
    where TSorting : ISortingBuilder<TSorting>;

    T ConfigureAspectRatios(
        Func<IAspectRatiosSearchConfiguration, IAspectRatiosSearchConfiguration>
        configureAspectRatios
    );

    T ConfigureResolutions(
        Func<IResolutionConfiguration, IAtLeastResolutionConfiguration> configureResolutions
    );

    T ConfigureResolutions(
        Func<IResolutionConfiguration, IExactResolutionConfiguration> configureResolutions
    );

    T WithPage(int page);
}
