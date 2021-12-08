using System.Linq.Expressions;

namespace BusinessLogic.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> All();
        T GetById(Guid id);
        bool Add(T entity);
        bool Delete(Guid id);
        bool Upsert(T entity);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        List<T> ExecuteStored(string query);
        List<T> ExecWithStoreProcedure(string query, params object[] parameters);
    }
}
