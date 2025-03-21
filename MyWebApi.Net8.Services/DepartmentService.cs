using AutoMapper;
using MyWebApi.Net8.Common;
using MyWebApi.Net8.Common.Attributes;
using MyWebApi.Net8.IServices;
using MyWebApi.Net8.Model;
using MyWebApi.Net8.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebApi.Net8.Services
{
    public class DepartmentService : BaseService<Department, DepartmentVo>, IDepartmentService
    {

        private readonly IBaseRepository<Department> _repository;
        public DepartmentService(IMapper mapper, IBaseRepository<Department> repository) : base(mapper, repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// 测试使用同事务
        /// </summary>
        /// <returns></returns>
        [UseTran(Propagation = Propagation.Required)]
        public async Task<bool> TestTranPropagation2()
        {
            TimeSpan timeSpan = DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var id = timeSpan.TotalSeconds.ObjToLong();
            var insertDepartment = await _repository.Add(new Department()
            {
                Id = id,
                Name = $"department name {id}",
                CodeRelationship = "",
                OrderSort = 0,
                Status = true,
                IsDeleted = false,
                Pid = 0
            });

            await Console.Out.WriteLineAsync($"db context id : {base.Db.ContextID}");

            return true;
        }
    }
}
