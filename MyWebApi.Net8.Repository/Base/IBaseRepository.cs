using MyWebApi.Net8.Model;
using SqlSugar;
using System.Linq.Expressions;

namespace MyWebApi.Net8.Repository.Base
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        ISqlSugarClient Db { get; }

        Task<long> Add(TEntity entity);
        Task<List<long>> AddSplit(TEntity entity);
        Task<List<TEntity>> Query();
        Task<List<TEntity>> QuerySplit(Expression<Func<TEntity, bool>> whereExpression, string orderByFields = null);
    }

}