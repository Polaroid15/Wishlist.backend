namespace WL.Application.Common.Models;

public class PaginatedList<TEntity> where TEntity : class
{
    public int Page { get; }

    public int PageSize { get; }

    public long Count { get; }

    public IEnumerable<TEntity> Data { get; }

    public PaginatedList(int page, int pageSize, long count, IEnumerable<TEntity> data)
    {
        Page = page;
        PageSize = pageSize;
        Count = count;
        Data = data;
    }
}