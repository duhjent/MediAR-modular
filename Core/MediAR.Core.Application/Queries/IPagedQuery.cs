namespace MediAR.Core.Application.Queries
{
    interface IPagedQuery
    {
        int? Page { get; }

        int? PageSize { get; }
    }
}
