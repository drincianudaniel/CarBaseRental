using System.Linq.Expressions;

namespace CarBase.Repositories.Interfaces
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> getAll();
        IQueryable<T> FindAll(Expression<Func<T, object>> criteria1, Expression<Func<T, object>> criteria2, Expression<Func<T, object>> criteria3);
        T FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> criteria1, Expression<Func<T, object>> criteria2, Expression<Func<T, object>> criteria3);
        IQueryable<T> FindAllWhere(Expression<Func<T, object>> criteria1, Expression<Func<T, object>> criteria2, Expression<Func<T, object>> criteria3, Expression<Func<T, bool>> expression);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}