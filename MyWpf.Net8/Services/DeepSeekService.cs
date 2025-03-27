using MyWebApi.Net8.Model.Models;
using MyWpf.Net8.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Net8.Services
{
    public class DeepSeekService : IDeepSeekService
    {
        private readonly HttpRestClient client;
        public DeepSeekService(HttpRestClient client)
        {
            this.client = client;
        }

        public async Task<ApiResponse> PostDeepSeekResAsync(string content)
        {
            BaseRequest request = new BaseRequest();
            request.Parameter = new UserMessage() {Content=content };
            request.Method = Method.Post;
            request.Route = $"api/DeepSeek/Chat";
            var result = await client.ExcuteAsync(request);
            return result;
        }
    }
}
