using MyWpf.Net8.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWpf.Net8.Services
{
    public interface IDeepSeekService
    {
        Task<ApiResponse> PostDeepSeekResAsync(string content);
    }
}
