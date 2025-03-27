using AutoMapper;
using MyWebApi.Net8.Common.Attributes;
using MyWebApi.Net8.Common;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository;
using MyWebApi.Net8.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorkflowCore.Models;

namespace MyWebApi.Net8.Services
{
    public class UserService : BaseService<User, UserVo>, IUserService
    {
        private readonly IDepartmentService _departmentService;

        public UserService(IMapper mapper, IBaseRepository<User> repository, IDepartmentService departmentService) : base(mapper, repository)
        {
            _departmentService = departmentService;
        }


        /// <summary>
        /// 测试使用同事务
        /// </summary>
        /// <returns></returns>
        [UseTran(Propagation = Propagation.Required)]
        public async Task<bool> TestTranPropagation()
        {
            await Console.Out.WriteLineAsync($"db context id : {base.Db.ContextID}");
            var sysUserInfos = await base.Query();

            TimeSpan timeSpan = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var id = timeSpan.TotalSeconds.ObjToLong();
            var insertSysUserInfo = await base.Add(new User()
            {
                Id = id,
                Name = $"user name {id}",
                Status = 0,
                CreateTime = DateTime.Now,
                UpdateTime = DateTime.Now,
                CriticalModifyTime = DateTime.Now,
                LastErrorTime = DateTime.Now,
                ErrorCount = 0,
                Enable = true,
                TenantId = 0,
            });

            await _departmentService.TestTranPropagation2();

            return true;
        }
    }
}
