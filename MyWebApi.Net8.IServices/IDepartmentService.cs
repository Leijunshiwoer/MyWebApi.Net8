using MyWebApi.Net8.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.IServices
{
    public interface IDepartmentService : IBaseService<Department, DepartmentVo>
    {
        Task<bool> TestTranPropagation2();
    }
}
