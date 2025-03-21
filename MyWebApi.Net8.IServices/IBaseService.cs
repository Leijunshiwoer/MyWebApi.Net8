using MyWebApi.Net8.Model;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.IServices
{
   public interface IBaseService<TEntity,TVo> where TEntity : class
    {
        Task<List<TVo>> Query();
        Task<long> Add(TEntity entity);

        ISqlSugarClient Db { get; }

        Task<List<TEntity>> QuerySplit(Expression<Func<TEntity, bool>> whereExpression, string orderByFields = null);

        Task<List<long>> AddSplit(TEntity entity);
    }
   
}
