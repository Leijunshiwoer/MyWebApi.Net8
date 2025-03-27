using MyWebApi.Net8.Model;
using MyWpf.Net8.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Net8.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly HttpRestClient client;
        private readonly string serviceName;

        public BaseService(HttpRestClient client, string serviceName)
        {
            this.client = client;
            this.serviceName = serviceName;
        }

        public async Task<ApiResponse<TEntity>> AddAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Post;
            request.Route = $"api/{serviceName}/Add";
            request.Parameter = entity;
            var result = await client.ExcuteAsync<TEntity>(request);
            return result;
        }

        public async Task<ApiResponse<TEntity>> UpdateAsync(TEntity entity)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Post;
            request.Route = $"api/{serviceName}/Update";
            request.Parameter = entity;
            var result = await client.ExcuteAsync<TEntity>(request);
            return result;
        }

        public async Task<ApiResponse> DeleteByIdAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Post;
            request.Route = $"api/{serviceName}/DeleteById?id={id}";
            return await client.ExcuteAsync(request);
        }

        public async Task<ApiResponse> DeleteByGuidAsync(string guid)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Post;
            request.Route = $"api/{serviceName}/DeleteByGuid?guid={guid}";
            return await client.ExcuteAsync(request);
        }

        public async Task<ApiResponse> DeleteMultipleAsync(IList<TEntity> entities)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Post;
            request.Route = $"api/{serviceName}/DeleteMultiple?id=0";
            return await client.ExcuteAsync(request);
        }

        public async Task<ApiResponse<TEntity>> GetSingleByCodeAsync(string code)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Get;
            request.Route = $"api/{serviceName}/GetSingleByCode?code={code}";
            var result = await client.ExcuteAsync<TEntity>(request);
            return result;
        }

        public async Task<ApiResponse<TEntity>> GetSingleByIdAsync(int id)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Get;
            request.Route = $"api/{serviceName}/GetSingleById?id={id}";
            var result = await client.ExcuteAsync<TEntity>(request);
            return result;
        }

        public async Task<ApiResponse<TEntity>> GetSingleByGuidAsync(string guid)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Get;
            request.Route = $"api/{serviceName}/GetSingleByGuid?guid={guid}";
            var result = await client.ExcuteAsync<TEntity>(request);
            return result;
        }

        public async Task<ApiResponse<PagedList<TEntity>>> GetAllFilterPagedAsync(Models.QueryParameter queryParameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Get;
            request.Route = $"api/{serviceName}/GetAllFilterPaged?pageIndex={queryParameter.PageIndex}" +
                $"&pageSize={queryParameter.PageSize}" +
                $"&Id={queryParameter.Id}" +
                $"&Status={queryParameter.Status}" +
                $"&Code={queryParameter.Code}";
            var resut = await client.ExcuteAsync<PagedList<TEntity>>(request);
            return resut;
        }

        public async Task<ApiResponse<List<TEntity>>> GetAllFilterWithoutPagedAsync(Models.QueryParameter queryParameter)
        {
            BaseRequest request = new BaseRequest();
            request.Method = Method.Get;
            request.Route = $"api/{serviceName}/GetAllFilterWithoutPagedQueryPara?Id={queryParameter.Id}" +
                $"&Status={queryParameter.Status}" +
                $"&Code={queryParameter.Code}";
            var result = await client.ExcuteAsync<List<TEntity>>(request);
            return result;
        }
    }
}
