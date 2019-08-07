using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;
using System.Linq;

namespace LazyCMS.EntityFrameworkCore
{
    /// <summary>
    /// 仓储扩展
    /// </summary>
    public static class RepositoryExtensions
    {
        public static List<TEntity> GetList<TEntity, TKey>(this IRepository<TEntity, TKey> repository,
            Expression<Func<TEntity, bool>> predicate)
            where TEntity : class, IEntity<TKey>
        {
            var query = repository.AsQueryable();
            return query.Where(predicate).ToList();
        }
    }
}
