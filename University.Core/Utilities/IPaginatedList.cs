namespace University.Core.Utilities;

public interface IPaginatedList
{
    int PageIndex { get; }
    int TotalPages { get; }
    bool HasPreviousPage { get; }
    bool HasNextPage { get; }
    string SearchString { get; }
}