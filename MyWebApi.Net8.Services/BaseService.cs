using AutoMapper;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository;
using MyWebApi.Net8.Repository.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Services
{
    public class BaseService<TEntity, TVo> : IBaseService<TEntity, TVo> where TEntity : class, new()
    {
        private readonly IMapper _mapper;
        private readonly IBaseRepository<TEntity> _repository;
        public ISqlSugarClient Db => _repository.Db;

        public BaseService(IMapper mapper,IBaseRepository<TEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }
        public async Task<List<TVo>> Query()
        {
          
            var entities= await _repository.Query();
            var vos = _mapper.Map<List<TVo>>(entities);
            return vos;
        }


        public async Task<long> Add(TEntity entity)
        {
            //var entity = _mapper.Map<TEntity>(vo);
            return await _repository.Add(entity);
        }

        public async Task<List<TEntity>> QuerySplit(Expression<Func<TEntity, bool>> whereExpression, string orderByFields = null)
        {
            return await _repository.QuerySplit(whereExpression, orderByFields);
        }

        public async Task<List<long>> AddSplit(TEntity entity)
        {
            return await _repository.AddSplit(entity);
        }
    }

}
