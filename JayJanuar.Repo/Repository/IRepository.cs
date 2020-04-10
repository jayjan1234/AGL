using System;
using System.Linq;
using System.Linq.Expressions;

namespace JayJanuar.Repo.Repository
{
    public interface IRepository<TEntity>
    {
        //use Iqueryable in case in the future we wouls like to extend data source into database
        IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeProperties);

    }
}
