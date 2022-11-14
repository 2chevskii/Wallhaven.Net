using Wallhaven.Net.Builders.Queries.Flags;
using Wallhaven.Net.Builders.Queries.Search.Sorting.Abstractions;
using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search.Abstractions;

public interface ISearchQueryBuilder<T> where T : ISearchQueryBuilder<T>
{
    /*string Uploader { get; }
    FileType FileType { get; }
    Category Categories { get; }
    Purity Purity { get; }
    QuerySortingMode SortingMode { get; }
    QuerySortingOrder SortingOrder { get; }
    string RandomSortingSeed { get; }
    TopListRange TopListSortingRange { get; }
    int Page { get; }*/

    T WithUploader(string uploaderUsername);

    T WithFileType(FileType fileType);

    T Configure<TFlags>(Func<FlagsBuilder<TFlags>, FlagsBuilder<TFlags>> configureFlags)
    where TFlags : Enum;

    T UseSortingBehaviour<TSorting>(Func<IBasicSortingBuilder, TSorting> configureSorting)
    where TSorting : ISortingBuilder<TSorting>;

    T WithPage(int page);
}
