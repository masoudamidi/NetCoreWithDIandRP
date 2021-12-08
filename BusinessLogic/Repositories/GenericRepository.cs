using System.Linq.Expressions;
using DataAccess.Data;
using BusinessLogic.Interfaces;
using Microsoft.EntityFrameworkCore;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    protected readonly NetCoreWithDIandRPContext _context;
    internal DbSet<T> dbSet;
    public GenericRepository(NetCoreWithDIandRPContext context)
    {
        _context = context;
        dbSet = context.Set<T>();
    }
    public virtual IEnumerable<T> All()
    {
        throw new NotImplementedException();
    }

    public virtual T GetById(Guid id)
    {
        return dbSet.Find(id);
    }

    public virtual bool Add(T entity)
    {
        dbSet.Add(entity);
        return true;
    }

    public virtual bool Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public virtual bool Upsert(T entity)
    {
        throw new NotImplementedException();
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return dbSet.Where(predicate).ToList();
    }

    public virtual List<T> ExecuteStored(string query)
    {
        var r = dbSet.FromSqlRaw(query);
        return r.ToList();
    }

    public virtual List<T> ExecWithStoreProcedure(string query, params object[] parameters)
    {
        return dbSet.FromSqlRaw(query, parameters).ToList();
    }
}