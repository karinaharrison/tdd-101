namespace TDD101.Workshops.CRUD.CQRS.Framework
{
    public interface IQueryExecutor
    {
        T Execute<T>(IQuery<T> query);
    }
}