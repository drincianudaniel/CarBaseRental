using CarBase.Models;
using CarBase.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CarBase.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected VehicleContext LocationContext { get; set; }

        public RepositoryBase(VehicleContext locationContext)
        {
            this.LocationContext = locationContext;
        }

        public IQueryable<T> getAll()
        {
            return this.LocationContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindAll(Expression<Func<T, object>> criteria1, Expression<Func<T, object>> criteria2, Expression<Func<T, object>> criteria3)
        {
            return this.LocationContext.Set<T>().Include(criteria1).Include(criteria2).Include(criteria3).AsNoTracking();

        }

        public T FindByCondition(Expression<Func<T, bool>> expression, Expression<Func<T, object>> criteria1, Expression<Func<T, object>> criteria2, Expression<Func<T, object>> criteria3)
        {
            return this.LocationContext.Set<T>().Include(criteria1).Include(criteria2).Include(criteria3).Where(expression).FirstOrDefault();
        }

        public void Create(T entity)
        {
            this.LocationContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            this.LocationContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            this.LocationContext.Set<T>().Remove(entity);
        }
    }
}