using MyWpf.Net8.Models;
using Newtonsoft.Json;
using RestSharp;

namespace MyWpf.Net8.Services
{
    public class HttpRestClient
    {
        private readonly string webUrl;

        //请求客户端
        protected readonly RestClient client;

        //通过构造函数注入一个基地址
        public HttpRestClient(string webUrl)
        {
            this.webUrl = webUrl;
            client = new RestClient();
        }

        public async Task<ApiResponse> ExcuteAsync(BaseRequest baseRequest)
        {
            var request = new RestRequest(webUrl + baseRequest.Route, baseRequest.Method);

            request.AddHeader("Content-Type", baseRequest.ContentType);
            if (baseRequest.Parameter != null)
                
              //  request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
              request.AddBody(baseRequest.Parameter);
            var response = await client.ExecuteAsync(request);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return JsonConvert.DeserializeObject<ApiResponse>(response.Content);
            else
            {
                return new ApiResponse()
                {   
                    Status = false,
                    Message = response.ErrorMessage + "  ****  " + response.Content.ToString()
                };
            }
        }


        public async Task<ApiResponse<T>> ExcuteAsync<T>(BaseRequest baseRequest)
        {
            try
            {
                var request = new RestRequest(webUrl + baseRequest.Route,baseRequest.Method);
                request.AddHeader("Content-Type", baseRequest.ContentType);

                if (baseRequest.Parameter != null)
                    // request.AddParameter("param", JsonConvert.SerializeObject(baseRequest.Parameter), ParameterType.RequestBody);
                    //client.BaseUrl = new Uri(webUrl + baseRequest.Route);
                    request.AddBody(baseRequest.Parameter);
                var response = await client.ExecuteAsync(request);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    return JsonConvert.DeserializeObject<ApiResponse<T>>(response.Content);
                else
                    return new ApiResponse<T>()
                    {
                        Status = false,
                        Message = response.ErrorMessage + "***" + response.Content.ToString()
                    };
            }
            catch (Exception ex)
            {
                return new ApiResponse<T>()
                {
                    Status = false,
                    Message = ex.Message.ToString()
                };
            }
        }
    }
}
     