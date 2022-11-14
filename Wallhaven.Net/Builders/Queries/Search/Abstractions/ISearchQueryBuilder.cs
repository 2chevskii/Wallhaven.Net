using Microsoft.VisualBasic.FileIO;

using Wallhaven.Net.Models.Common;

namespace Wallhaven.Net.Builders.Queries.Search;

public interface ISearchQueryBuilder<T> where T : ISearchQueryBuilder<T>
{
    string Uploader { get; }
    FileType FileType { get; }

    T WithUploader(string uploaderUsername);

    T WithFileType(FileType fileType);
}
