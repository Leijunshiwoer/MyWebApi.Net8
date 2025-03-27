using DeepSeek.Core.Models;
using DeepSeek.Core;
using Microsoft.AspNetCore.Mvc;
using MyWpf.Net8.Models;
using MyWebApi.Net8.Model.Models;

namespace MyWebApi.Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeepSeekController : ControllerBase
    {
        private readonly DeepSeekClient _deepSeekClient;

        public DeepSeekController(DeepSeekClient deepSeekClient)
        {
            _deepSeekClient = deepSeekClient;
        }
        [HttpPost("Chat")]
        public async Task<ApiResponse> Chat([FromBody] UserMessage userMessage)
        {
            var request = new ChatRequest
            {
                //Model = "deepseek-chat",
                Messages = new List<Message>
                    {
                        new Message
                        {
                            Content = userMessage.Content
                        }
                    }
            };

            var response = await _deepSeekClient.ChatAsync(request, new System.Threading.CancellationToken());
            if (response != null)
            {
                var reply = response.Choices.FirstOrDefault()?.Message?.Content;
                return new ApiResponse() { Message=reply,Status=true };
            }
            else
            {
                return new ApiResponse() { Message = "Error calling DeepSeek API", Status = false };

            }
        }
    }

}
